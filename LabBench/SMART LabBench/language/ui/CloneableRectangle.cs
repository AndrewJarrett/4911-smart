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
    /// <summary>
    /// Rectangle that can be cloned
    /// </summary>
    class ClonableRectangle : libSMARTMultiTouch.ICloneable
    {
        private InteractiveBorder mInteractiveBorder;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mInteractiveBorder">Rectangle to be cloned</param>
        public ClonableRectangle(InteractiveBorder mInteractiveBorder)
        {
            this.mInteractiveBorder = mInteractiveBorder;
        }

        /// <summary>
        /// create a new clone
        /// </summary>
        /// <returns>cloned object</returns>
        public Object Clone()
        {
            DraggableBorder r = new DraggableBorder();
            SnapBehavior rc = new SnapBehavior();
            
            r.Attach(rc);
            r.Width = mInteractiveBorder.Width;
            r.Height = mInteractiveBorder.Height;
            r.Background = mInteractiveBorder.Background;
            return r;
        }
    }
}
