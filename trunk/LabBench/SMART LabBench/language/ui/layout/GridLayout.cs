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
    /// <summary>
    /// a data structure that defines a grid layout with buttons
    /// </summary>
    public class GridLayout
    {
        private static List<InteractiveBorder> mInteractiveBorders = new List<InteractiveBorder>(56*42); 
        private static InteractiveBorder mOverlay;
        private static CreateObjectBehavior mCreateObjectBehavior;
        private static Boolean isCreateMode;
        private static Icon mWireTool;
        private static LessonChooser lessonChooser;

        /// <summary>
        /// default constructor
        /// </summary>
        public GridLayout()
        {
            createLayout();
        }

        /// <summary>
        /// create the layout in its entirety
        /// </summary>
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

            // validate button
            Icon mValidateButton = new Icon(new ImagePNG("ui/validate.png"));
            TransformGroup m3TransformGroup = new TransformGroup();
            m3TransformGroup.Children.Add(new ScaleTransform(0.4, 0.4));
            m3TransformGroup.Children.Add(new TranslateTransform(780, -62.5));
            mValidateButton.RenderTransform = m3TransformGroup;
            mValidateButton.Attach(new ValidateCircuitBehavior());
            mValidateButton.Attach(new TouchBounceBehavior());

            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mValidateButton);

            // save button
            Icon mSaveButton = new Icon(new ImagePNG("ui/save.png"));
            TransformGroup m2TransformGroup = new TransformGroup();
            m2TransformGroup.Children.Add(new ScaleTransform(0.4, 0.4));
            m2TransformGroup.Children.Add(new TranslateTransform(580, -62.5));
            mSaveButton.RenderTransform = m2TransformGroup;
            mSaveButton.Attach(new TouchBounceBehavior());

            TouchInputManager.AddTouchContactDownHandler(mSaveButton, new TouchContactEventHandler(Button_SaveLesson));

            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mSaveButton);

            //load button
            Icon mLoadButton = new Icon(new ImagePNG("ui/save.png"));
            TransformGroup m7TransformGroup = new TransformGroup();
            m7TransformGroup.Children.Add(new ScaleTransform(0.4, 0.4));
            m7TransformGroup.Children.Add(new TranslateTransform(680, -62.5));
            mLoadButton.RenderTransform = m7TransformGroup;
            mLoadButton.Attach(new TouchBounceBehavior());

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

        /// <summary>
        /// set the icon of the wire tool button
        /// </summary>
        /// <param name="mIcon">Icon to represent the button</param>
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

        /// <summary>
        /// create a new Wire between two points
        /// </summary>
        /// <param name="start">starting point</param>
        /// <param name="end">ending point</param>
        public static void createWire(Point start, Point end)
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

        /// <summary>
        /// toggle Wiring mode on/off
        /// </summary>
        public static void toggleWiringMode()
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

        /// <summary>
        /// lower overlay
        /// </summary>
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
            if (lessonChooser != null && lessonChooser.open)
            {
                lessonChooser.open = false;
                lessonChooser.clearLessons();
            }
            else
            {
                lessonChooser = new LessonChooser(LessonCreator.ActiveLesson.LabBench.Canvas, 500, 200);
                lessonChooser.open = true;
            }
        }

    }
}
