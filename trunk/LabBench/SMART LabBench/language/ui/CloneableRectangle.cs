using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libSMARTMultiTouch.Controls;

namespace LabBench.language.ui
{
    class ClonableRectangle : libSMARTMultiTouch.ICloneable
    {
        private InteractiveBorder mInteractiveBorder;

        public ClonableRectangle(InteractiveBorder mInteractiveBorder)
        {
            this.mInteractiveBorder = mInteractiveBorder;
        }

        public Object Clone()
        {
            DraggableBorder r = new DraggableBorder();
            //RotateColorBehavior rc = new RotateColorBehavior();
            //r.Attach(rc);
            r.Width = mInteractiveBorder.Width;
            r.Height = mInteractiveBorder.Height;
            r.Background = mInteractiveBorder.Background;

            return r;
        }
    }
}
