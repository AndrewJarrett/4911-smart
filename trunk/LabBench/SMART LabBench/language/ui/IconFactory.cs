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
        public IconFactory(Canvas mCanvas, Icon mIcon, double x, double y)
        {
            TouchCloner mTouchCloner = new TouchCloner(mIcon);
            mTouchCloner.Source = new CloneableIcon(mIcon);

            TranslateTransform mTranslateTransform = new TranslateTransform();
            mTranslateTransform.X = x;
            mTranslateTransform.Y = y;
            mTouchCloner.RenderTransform = mTranslateTransform;

            mCanvas.Children.Add(mTouchCloner);
        }
    }
}
