using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using libSMARTMultiTouch.Controls;

namespace LabBench.language.ui
{
    class CloneableIcon : libSMARTMultiTouch.ICloneable
    {
        private Icon mIcon;

        public CloneableIcon(Icon mIcon)
        {
            this.mIcon = mIcon;
        }

        #region ICloneable Members

        public object Clone()
        {
            Icon r = new Icon(mIcon.getX(), mIcon.getY(), mIcon.getAngle(), mIcon.getSource());
            return r;
        }

        #endregion
    }
}
