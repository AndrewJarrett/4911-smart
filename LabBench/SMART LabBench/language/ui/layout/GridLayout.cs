using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using libSMARTMultiTouch.Controls;
using System.Windows.Media;
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.control;
using System.Windows;
using System.Windows.Shapes;

namespace LabBench.language.ui.layout
{
    public class GridLayout
    {
        public static Canvas source;
        private static List<InteractiveBorder> mInteractiveBorders = new List<InteractiveBorder>(56*42); 
        private static InteractiveBorder mOverlay;
        private static CreateObjectBehavior mCreateObjectBehavior;
        private static Boolean isCreateMode;

        public GridLayout(Canvas mCanvas)
        {
            source = mCanvas;
            generate();
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

        private void generate()
        {
            for(int i=0; i<56; i++) {
                for (int j = 0; j < 42; j++)
                {
                    InteractiveBorder mInteractiveBorder = new InteractiveBorder();
                    mInteractiveBorder.BorderBrush = Brushes.LightGray;
                    mInteractiveBorder.BorderThickness = new System.Windows.Thickness(1);
                    mInteractiveBorder.Background = new SolidColorBrush(Colors.White);

                    mInteractiveBorder.Height = 150; mInteractiveBorder.Width = 200;

                    TranslateTransform mTranslateTransform = new TranslateTransform();
                    mTranslateTransform.X = i * 25;
                    mTranslateTransform.Y = j * 25;

                    mInteractiveBorder.RenderTransform = mTranslateTransform;

                    RNTBehavior mRNTBehavior = new RNTBehavior();
                    mRNTBehavior.IsRotateEnabled = false; mRNTBehavior.IsTranslateEnabled = false;

                    mInteractiveBorder.Attach(mRNTBehavior);

                    //mInteractiveBorder.Attach(new CreateObjectBehavior());

                    //DebugBehavior mDebugBehavior = new DebugBehavior(mTranslateTransform.X, mTranslateTransform.Y);
                    //mInteractiveBorder.Attach(mDebugBehavior);

                    mInteractiveBorders.Add(mInteractiveBorder);
                    source.Children.Add(mInteractiveBorder);
                }
            }
            (mInteractiveBorders.First()).Background = Brushes.LightGray;
            (mInteractiveBorders.First()).BorderThickness = new Thickness(0);

            mOverlay = new InteractiveBorder();
            mOverlay.Width = 1400; mOverlay.Height = 1050;
            mOverlay.Background = Brushes.Transparent;

            mCreateObjectBehavior = new CreateObjectBehavior();
           // mOverlay.Attach(mCreateObjectBehavior);
            isCreateMode = false;

            source.Children.Add(mOverlay);
        }

        public static void create(Point start, Point end)
        {
            //if (start.X > end.X)
            //{
            //    Point t = new Point(start.X, start.Y);
            //    start.X = end.X; start.Y = end.Y;
            //    end.X = t.X; end.Y = t.Y;
            //}

            //InteractiveBorder mInteractiveBorder = new InteractiveBorder();
            //mInteractiveBorder.Height = 25;

            

            //mInteractiveBorder.Width = Math.Sqrt(Math.Pow(end.X - start.X,2) + Math.Pow(end.Y - start.Y,2));

            //TransformGroup mTransform = new TransformGroup();

            //TranslateTransform mTranslateTransform = new TranslateTransform();
            //mTranslateTransform.X = start.X;
            //mTranslateTransform.Y = start.Y;


            //mInteractiveBorder.RenderTransform = mTranslateTransform;

            //RotateTransform mRotateTransform = new RotateTransform();
            //mRotateTransform.Angle = Math.Atan2(end.Y - start.Y, end.X - start.X) * 180.0 / Math.PI;
            //mRotateTransform.CenterX = 0;
            //mRotateTransform.CenterY = 0;

            //mTransform.Children.Add(mRotateTransform);
            //mTransform.Children.Add(mTranslateTransform);

            //mInteractiveBorder.RenderTransform = mTransform;

            //RNTBehavior mRNTBehavior = new RNTBehavior();
            //mRNTBehavior.IsRotateEnabled = false; mRNTBehavior.IsTranslateEnabled = false;

            //mInteractiveBorder.Attach(mRNTBehavior);
            //mInteractiveBorder.Attach(new SnapBehavior());

            //mInteractiveBorder.Background = Brushes.PowderBlue;

            //mInteractiveBorders.Add(mInteractiveBorder);
            ////Grid.SetZIndex(mInteractiveBorder, Int16.MaxValue);
            //source.Children.Add(mInteractiveBorder);


            Line line = new Line();
            line.X1 = start.X;
            line.X2 = end.X;
            line.Y1 = start.Y;
            line.Y2 = end.Y;
            line.Stroke = Brushes.PowderBlue;
            line.StrokeThickness = 25;

            DraggableBorder mDraggableBorder = new DraggableBorder();
            mDraggableBorder.IsRotateEnabled = false;
            //mDraggableBorder.RenderTransform = new TranslateTransform(start.X, start.Y);
            
            mDraggableBorder.Child = line;

            mDraggableBorder.Attach(new SnapBehavior());

            mDraggableBorder.Attach(new DeletableBehavior());
            source.Children.Add(mDraggableBorder);
        }

        internal static void create(Line line)
        {
            DraggableBorder mDraggableBorder = new DraggableBorder();
            mDraggableBorder.IsRotateEnabled = false;
            //mDraggableBorder.RenderTransform = new TranslateTransform(start.X, start.Y);

            mDraggableBorder.Child = line;

            //mDraggableBorder.Attach(new DeletableBehavior());
            source.Children.Add(mDraggableBorder);
        }

        public static void toggleCreate()
        {
            if (isCreateMode)
            {
                mOverlay.Detach(mCreateObjectBehavior);
                isCreateMode = false;
            }
            else
            {
                mOverlay.Attach(mCreateObjectBehavior);
                isCreateMode = true;
            }
        }
    }
}
