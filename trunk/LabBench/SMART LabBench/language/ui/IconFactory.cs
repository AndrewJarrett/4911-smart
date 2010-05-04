using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libSMARTMultiTouch.Controls;
using System.Windows.Media;
using System.Windows.Controls;

namespace LabBench.language.ui
{
    /// <summary>
    /// Factory for cloning Icons
    /// </summary>
    class IconFactory
    {
        private TouchCloner mTouchCloner;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mCanvas">Canvas to clone to</param>
        /// <param name="mBase">Icon button</param>
        /// <param name="mClone">Icon to be clone</param>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public IconFactory(Canvas mCanvas, Icon mBase, Icon mClone, double x, double y)
        {
            TransformGroup trans = new TransformGroup();

            mTouchCloner = new TouchCloner(mBase);
            mTouchCloner.Source = new CloneableIcon(mClone);

            trans.Children.Add(new ScaleTransform(0.5, 0.5));
            trans.Children.Add(new TranslateTransform(x, y));

            mTouchCloner.RenderTransform = trans;

            mCanvas.Children.Add(mTouchCloner);

        }

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mCanvas">Canvas to clone to</param>
        /// <param name="mIcon">Icon to be cloned</param>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public IconFactory(Canvas mCanvas, Icon mIcon, double x, double y)
            : this(mCanvas, mIcon, mIcon, x, y)
        { ; }

        /// <summary>
        /// the cloner
        /// </summary>
        public TouchCloner Source {
            get { return mTouchCloner; }
        }
    }
}
