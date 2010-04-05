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
        private TouchCloner mTouchCloner;

        public IconFactory(ToolboxCategory category, Canvas mCanvas, Icon mBase, Icon mClone, double x, double y)
        {
            TransformGroup trans = new TransformGroup();

            mTouchCloner = new TouchCloner(mBase);
            mTouchCloner.Source = new CloneableIcon(mClone);

            trans.Children.Add(new ScaleTransform(0.5, 0.5));
            trans.Children.Add(new TranslateTransform(x, y));

            mTouchCloner.RenderTransform = trans;

            mCanvas.Children.Add(mTouchCloner);

        }

        public IconFactory(ToolboxCategory mCategory, Canvas mCanvas, Icon mIcon, double x, double y)
            : this(mCategory, mCanvas, mIcon, mIcon, x, y)
        { ; }

        public TouchCloner Source {
            get { return mTouchCloner; }
        }
    }
}
