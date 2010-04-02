using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libSMARTMultiTouch.Controls;
using System.Windows;
using libSMARTMultiTouch.Input;
using System.Windows.Controls;
using LabBench.language.ui.control;
using libSMARTMultiTouch.Behaviors;

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
            DebugBehavior rc = new DebugBehavior();
            
            r.Attach(rc);
            r.Width = mInteractiveBorder.Width;
            r.Height = mInteractiveBorder.Height;
            r.Background = mInteractiveBorder.Background;
            return r;
        }
    }
}
