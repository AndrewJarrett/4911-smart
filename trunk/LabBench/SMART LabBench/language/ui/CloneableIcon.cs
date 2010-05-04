using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using libSMARTMultiTouch.Controls;
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.control;

namespace LabBench.language.ui
{
    /// <summary>
    /// Icon that can be cloned
    /// </summary>
    class CloneableIcon : libSMARTMultiTouch.ICloneable
    {
        private Icon mIcon;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mIcon">Icon to be cloned</param>
        public CloneableIcon(Icon mIcon)
        {
            this.mIcon = mIcon;
        }

        #region ICloneable Members

        /// <summary>
        /// create a new clone
        /// </summary>
        /// <returns>cloned object</returns>
        public object Clone()
        {
            Icon r = new Icon(mIcon.getSource());//new Icon(mIcon.getX(), mIcon.getY(), mIcon.getAngle(), mIcon.getSource());
            r.Attach(new TouchBounceBehavior());
            return r;
        }

        #endregion
    }
}
