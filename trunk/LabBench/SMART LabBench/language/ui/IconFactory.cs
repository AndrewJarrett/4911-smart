using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libSMARTMultiTouch.Controls;
using System.Windows.Media;
using System.Windows.Controls;

namespace LabBench.language.ui
{
    class IconFactory
    {
        public IconFactory(Canvas mCanvas, Icon mBase, Icon mClone, double x, double y)
        {
            TouchCloner mTouchCloner = new TouchCloner(mBase);
            mTouchCloner.Source = new CloneableIcon(mClone);

            TranslateTransform mTranslateTransform = new TranslateTransform();
            mTranslateTransform.X = x;
            mTranslateTransform.Y = y;
            mTouchCloner.RenderTransform = mTranslateTransform;

            mCanvas.Children.Add(mTouchCloner);
        }

        public IconFactory(Canvas mCanvas, Icon mIcon, double x, double y)
            : this(mCanvas, mIcon, mIcon, x, y)
        { ; }
    }
}
