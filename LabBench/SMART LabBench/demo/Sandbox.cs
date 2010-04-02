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

namespace LabBench.demo
{

    class Sandbox
    {
        private Canvas mCanvas;

        public Sandbox(Canvas mCanvas)
        {
            this.mCanvas = mCanvas;
        }

        public void activate()
        {
            InteractiveBorder mInteractiveBorder = new InteractiveBorder();
            mInteractiveBorder.Width = 150; mInteractiveBorder.Height = 150;
            mInteractiveBorder.Background = new SolidColorBrush(Colors.Red);

            Rectangle mRectangle = new Rectangle();
            mRectangle.Height = mInteractiveBorder.Height;
            mRectangle.Width = mInteractiveBorder.Width;
            mRectangle.Fill = new SolidColorBrush(Colors.Red);

            DebugBehavior dbg = new DebugBehavior();
            mInteractiveBorder.Attach(dbg);

            RNTBehavior rnt = new RNTBehavior();
            rnt.IsRotateEnabled = true; rnt.IsTranslateEnabled = true;

            mInteractiveBorder.Attach(rnt);

            mCanvas.Children.Add(mInteractiveBorder);
        }
    }
}
