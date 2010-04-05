using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using libSMARTMultiTouch.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.control;
using LabBench.language.ui.layout;

namespace LabBench.demo
{

    class Sandbox
    {
        private Canvas mCanvas;

        private GridLayout mGrid;

        public Sandbox(Canvas mCanvas)
        {
            this.mCanvas = mCanvas;
        }

        public void activate()
        {
            mGrid = new GridLayout(mCanvas);
            //mGrid.generate();

            InteractiveBorder mInteractiveBorder = new InteractiveBorder();
            mInteractiveBorder.Width = 150; mInteractiveBorder.Height = 150;
            mInteractiveBorder.Background = new SolidColorBrush(Colors.Red);

            Rectangle mRectangle = new Rectangle();
            mRectangle.Height = mInteractiveBorder.Height;
            mRectangle.Width = mInteractiveBorder.Width;
            mRectangle.Fill = new SolidColorBrush(Colors.Red);

            SnapBehavior mSnapBehavior = new SnapBehavior();
            mInteractiveBorder.Attach(mSnapBehavior);

            RNTBehavior mRNTBehavior = new RNTBehavior();
            mRNTBehavior.IsRotateEnabled = true; mRNTBehavior.IsTranslateEnabled = true;
            mInteractiveBorder.Attach(mRNTBehavior);

            DebugBehavior mDebugBehavior = new DebugBehavior();
            mInteractiveBorder.Attach(mDebugBehavior);

            FlickBehavior mFlickBehavior = new FlickBehavior();
            mInteractiveBorder.Attach(mFlickBehavior);

            mCanvas.Children.Add(mInteractiveBorder);
        }
    }
}
