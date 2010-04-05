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
                    mInteractiveBorder.BorderBrush = Brushes.Red;
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

                    //DebugBehavior mDebugBehavior = new DebugBehavior(mTranslateTransform.X, mTranslateTransform.Y);
                    //mInteractiveBorder.Attach(mDebugBehavior);

                    mInteractiveBorders.Add(mInteractiveBorder);
                    source.Children.Add(mInteractiveBorder);
                }
            }
            (mInteractiveBorders.First()).Background = Brushes.LightGray;
            (mInteractiveBorders.First()).BorderThickness = new Thickness(0);
        }
    }
}
