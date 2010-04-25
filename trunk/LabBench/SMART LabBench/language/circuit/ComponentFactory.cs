using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabBench.language.ui;
using System.Windows.Controls;
using System.Windows.Media;
using libSMARTMultiTouch.Controls;

namespace LabBench.language.circuit
{
    class ComponentFactory
    {
        private String mComponentName;
        private TouchCloner mTouchCloner;

        public ComponentFactory(String mComponentName, Canvas mCanvas, Icon mBase, Component mClone, double x, double y)
        {
            TransformGroup mTransformGroup = new TransformGroup();

            mTouchCloner = new TouchCloner(mBase);
            mTouchCloner.Source = new CloneableComponent(mClone);

            mTransformGroup.Children.Add(new ScaleTransform(0.5, 0.5));
            mTransformGroup.Children.Add(new TranslateTransform(x, y));

            mTouchCloner.RenderTransform = mTransformGroup;

            mCanvas.Children.Add(mTouchCloner);

        }

        public ComponentFactory(String mComponentName, Canvas mCanvas, Component mComponent, double x, double y)
            : this(mComponentName, mCanvas, mComponent, mComponent, x, y)
        { ; }

        public TouchCloner Source {
            get { return mTouchCloner; }
        }

    }

}
