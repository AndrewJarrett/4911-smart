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
    /// <summary>
    /// Factory for creating Components of the same type
    /// </summary>
    class ComponentFactory
    {
        private String mComponentName;
        private TouchCloner mTouchCloner;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mComponentName">name of the component</param>
        /// <param name="mCanvas">canvas to clone the component to</param>
        /// <param name="mBase">type icon</param>
        /// <param name="mClone">component icon</param>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
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

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mComponentName">name of component</param>
        /// <param name="mCanvas">canvas to draw component to</param>
        /// <param name="mComponent">component to clone</param>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public ComponentFactory(String mComponentName, Canvas mCanvas, Component mComponent, double x, double y)
            : this(mComponentName, mCanvas, mComponent, mComponent, x, y)
        { ; }

        public TouchCloner Source {
            get { return mTouchCloner; }
        }

    }

}
