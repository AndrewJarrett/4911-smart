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

namespace LabBench.language.ui.layout
{
    public class FixedGrid
    {
        private Canvas mCanvas;
        private List<InteractiveBorder> mInteractiveBorders = new List<InteractiveBorder>(49); 

        public FixedGrid(Canvas mCanvas)
        {
            this.mCanvas = mCanvas;
        }

        public void generate() {
            for(int i=0; i<7; i++) {
                for (int j = 0; j < 7; j++)
                {
                    InteractiveBorder mInteractiveBorder = new InteractiveBorder();
                    //mInteractiveBorder.BorderBrush = Brushes.Red;
                    //mInteractiveBorder.BorderThickness = new System.Windows.Thickness(2);
                    mInteractiveBorder.Background = new SolidColorBrush(Colors.White);

                    mInteractiveBorder.Height = 150; mInteractiveBorder.Width = 200;

                    TranslateTransform mTranslateTransform = new TranslateTransform();
                    mTranslateTransform.X = i * 200;
                    mTranslateTransform.Y = j * 150;

                    mInteractiveBorder.RenderTransform = mTranslateTransform;

                    RNTBehavior mRNTBehavior = new RNTBehavior();
                    mRNTBehavior.IsRotateEnabled = false; mRNTBehavior.IsTranslateEnabled = false;

                    mInteractiveBorder.Attach(mRNTBehavior);

                    DebugBehavior mDebugBehavior = new DebugBehavior();
                    mInteractiveBorder.Attach(mDebugBehavior);

                    mInteractiveBorders.Add(mInteractiveBorder);

                    mCanvas.Children.Add(mInteractiveBorder);
                }
            }
        }
    }
}
