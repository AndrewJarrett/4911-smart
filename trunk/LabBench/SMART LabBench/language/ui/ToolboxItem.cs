using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using libSMARTMultiTouch.Controls;

namespace LabBench.language.ui
{
    class ToolboxItem : libSMARTMultiTouch.ICloneable
    {
        private InteractiveBorder mInteractiveBorder;

        public ToolboxItem()
        {
            this.mInteractiveBorder = new InteractiveBorder();
            this.mInteractiveBorder.Width = 75; this.mInteractiveBorder.Height = 75;
            this.mInteractiveBorder.Background = new SolidColorBrush(Colors.Red);
        }

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
