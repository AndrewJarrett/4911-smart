using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using libSMARTMultiTouch.Controls;

namespace LabBench.language.ui
{
    /// <summary>
    /// Item that is to be stored in the toolbox and is cloneable
    /// </summary>
    class ToolboxItem : libSMARTMultiTouch.ICloneable
    {
        private InteractiveBorder mInteractiveBorder;

        /// <summary>
        /// default constructor
        /// </summary>
        public ToolboxItem()
        {
            this.mInteractiveBorder = new InteractiveBorder();
            this.mInteractiveBorder.Width = 75; this.mInteractiveBorder.Height = 75;
            this.mInteractiveBorder.Background = new SolidColorBrush(Colors.Red);
        }

        /// <summary>
        /// clone the blueprint object
        /// </summary>
        /// <returns>cloned object</returns>
        public Object Clone()
        {
            DraggableBorder r = new DraggableBorder();
            r.Width = mInteractiveBorder.Width;
            r.Height = mInteractiveBorder.Height;
            r.Background = mInteractiveBorder.Background;

            return r;
        }
    }
}
