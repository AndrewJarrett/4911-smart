using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using libSMARTMultiTouch.Controls;
using System.Windows.Media;
using libSMARTMultiTouch.Behaviors;
using libSMARTMultiTouch.Input;
using LabBench.language.ui.control;
using System.Windows;
using System.Windows.Shapes;
using LabBench.demo;
using System.Windows.Media.Imaging;

namespace LabBench.language.ui.layout
{
    public class GridLayout
    {
        private static List<InteractiveBorder> mInteractiveBorders = new List<InteractiveBorder>(56*42); 
        private static InteractiveBorder mOverlay;
        private static CreateObjectBehavior mCreateObjectBehavior;
        private static Boolean isCreateMode, lessonChooserOpen;
        private static Icon mWireTool;
        private static LessonChooser lessonChooser;

        public GridLayout()
        {
            createLayout();
        }

        public static void shade(int x, int y, int w, int h) {
            int index = (x/25) * 42 + (y/25);

            if (index > -1 && index < 42*56)
            {
                mInteractiveBorders[index].Background = Brushes.Gray;

                for (int i = 0; i < w / 25; i++)
                {
                    for (int j = 0; j < h / 25; j++)
                    {
                        int k = ((x / 25) + i) * 42 + ((y / 25) + j);
                        mInteractiveBorders[k].Background = Brushes.LightGray;
                        mInteractiveBorders[k].BorderThickness = new Thickness(0);
                    }
                }
            }
        }

        public static void unshade(int x, int y, int w, int h)
        {
            int index = (x / 25) * 42 + (y / 25);

            if (index > -1 && index < 42*56)
            {
                mInteractiveBorders[index].Background = Brushes.White;

                for (int i = 0; i < w / 25; i++)
                {
                    for (int j = 0; j < h / 25; j++)
                    {
                        int k = ((x / 25) + i) * 42 + ((y / 25) + j);
                        mInteractiveBorders[k].Background = Brushes.White;
                        mInteractiveBorders[k].BorderThickness = new Thickness(1);
                    }
                }
            }
        }

        private void createLayout()
        {

            ImageBrush mImageBrush = new ImageBrush();
            mImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/resources/images/ui/grid.png"));
            LessonCreator.ActiveLesson.LabBench.Canvas.Background = mImageBrush;

            // trash button
            Icon mTrashCan = new Icon(new ImagePNG("ui/trash.png"));
            TransformGroup mTransformGroup = new TransformGroup();
            mTransformGroup.Children.Add(new ScaleTransform(0.4, 0.4));
            mTransformGroup.Children.Add(new TranslateTransform(-62.5, -62.5));
            mTrashCan.RenderTransform = mTransformGroup;
            //mTrashCan.Attach(new TouchBounceBehavior());

            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mTrashCan);


            // save button
            Icon mSaveButton = new Icon(new ImagePNG("ui/save.png"));
            TransformGroup m2TransformGroup = new TransformGroup();
            m2TransformGroup.Children.Add(new ScaleTransform(0.4, 0.4));
            m2TransformGroup.Children.Add(new TranslateTransform(580, -62.5));
            mSaveButton.RenderTransform = m2TransformGroup;

            TouchInputManager.AddTouchContactDownHandler(mSaveButton, new TouchContactEventHandler(Button_SaveLesson));

            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mSaveButton);

            //load button
            Icon mLoadButton = new Icon(new ImagePNG("ui/save.png"));
            TransformGroup m3TransformGroup = new TransformGroup();
            m3TransformGroup.Children.Add(new ScaleTransform(0.4, 0.4));
            m3TransformGroup.Children.Add(new TranslateTransform(680, -62.5));
            mLoadButton.RenderTransform = m3TransformGroup;
            lessonChooserOpen = false;

            TouchInputManager.AddTouchContactDownHandler(mLoadButton, new TouchContactEventHandler(Button_LoadLesson));

            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mLoadButton);

            Icon mDeleteButton = new Icon(new ImagePNG("ui/delete.png"));
            mTransformGroup = new TransformGroup();
            mTransformGroup.Children.Add(new ScaleTransform(0.4, 0.4));
            mTransformGroup.Children.Add(new TranslateTransform(475, -62.5));
            mDeleteButton.RenderTransform = mTransformGroup;

            mDeleteButton.Attach(new ClearLessonBehavior());
            mDeleteButton.Attach(new TouchBounceBehavior());
            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mDeleteButton);



            mOverlay = new InteractiveBorder();
            mOverlay.Width = 1400; mOverlay.Height = 1050;
            mOverlay.Background = Brushes.Transparent;

            mCreateObjectBehavior = new CreateObjectBehavior();
            isCreateMode = false;

            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mOverlay);
            Grid.SetZIndex(mOverlay, int.MinValue);

            setWireToolButton("wire.png");
            
            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mWireTool);
        }

        private static void setWireToolButton(String mIcon)
        {
            mWireTool = new Icon(new ImagePNG("ui/" + mIcon));
            TransformGroup mTransformGroup = new TransformGroup();
            mTransformGroup.Children.Add(new ScaleTransform(0.5, 0.5));
            mTransformGroup.Children.Add(new TranslateTransform(37.5, -62.25));
            mWireTool.RenderTransform = mTransformGroup;
            mWireTool.Attach(new ToggleBehavior());
            //mWireTool.Attach(new TouchBounceBehavior());
        }

        public static void create(Point start, Point end)
        {
            Line line = new Line();
            line.X1 = start.X;
            line.X2 = end.X;
            line.Y1 = start.Y;
            line.Y2 = end.Y;
            line.Stroke = Brushes.PowderBlue;
            line.StrokeThickness = 25;

            DraggableBorder mDraggableBorder = new DraggableBorder();
            mDraggableBorder.IsRotateEnabled = false;
            mDraggableBorder.IsTranslateEnabled = false;
            
            mDraggableBorder.Child = line;

            mDraggableBorder.Attach(new SnapBehavior());

            mDraggableBorder.Attach(new DeletableBehavior());
            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mDraggableBorder);
        }

        public static void toggleCreate()
        {
            if (isCreateMode)
            {
                LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mWireTool);
                setWireToolButton("wire.png");
                LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mWireTool);
                mOverlay.Detach(mCreateObjectBehavior);
                Grid.SetZIndex(mOverlay, int.MinValue);
                isCreateMode = false;
            }
            else
            {
                LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mWireTool);
                setWireToolButton("cancel.png");
                LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mWireTool);
                mOverlay.Attach(mCreateObjectBehavior);
                Grid.SetZIndex(mOverlay, int.MaxValue / 2);
                //Grid.SetZIndex(mWireTool, int.MaxValue);
                isCreateMode = true;
            }
        }

        public static void demote()
        {
            Grid.SetZIndex(mOverlay, int.MinValue);
        }

        /// <summary>
        /// Saves the current lesson creator session as a new Lesson file.
        /// </summary>
        private void Button_SaveLesson(object sender, TouchContactEventArgs e)
        {
            SerializedLesson toSave = new SerializedLesson(LessonCreator.ActiveLesson.LabBench.Canvas);

            String directory = "lessons";
            int cnt = 0;
            foreach (string lessonName in System.IO.Directory.GetFiles(directory))
            {
                if (lessonName != ".svn")
                    cnt++;
            }
            String path = directory + "/lesson_" + cnt + ".bin";
            toSave.saveFile(path);

        }

        /// <summary>
        /// Opens or closes the lesson chooser, which in turn loads or creates new lessons.
        /// </summary>
        private void Button_LoadLesson(object sender, TouchContactEventArgs e)
        {
            if (lessonChooserOpen)
            {
                lessonChooserOpen = false;
                lessonChooser.clearLessons();
            }
            else
            {
                lessonChooserOpen = true;
                lessonChooser = new LessonChooser(LessonCreator.ActiveLesson.LabBench.Canvas, 500, 200);
            }
        }

    }
}
