using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libSMARTMultiTouch.Controls;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Interactivity;
using libSMARTMultiTouch;
using System.Windows;
using libSMARTMultiTouch.Input;
using LabBench.language.ui.layout;

namespace LabBench.language.ui.control
{
    public class DebugBehavior : Behavior<InteractiveFrameworkElement>
    {
        private FrameworkElement m_element;
        private TranslateTransform m_translateTransform;
        private ScaleTransform m_scaleTransform;
        private TextBlock label = new TextBlock();

        private double mInitialX = 0, mInitialY = 0;

        public DebugBehavior(double x, double y)
        {
            mInitialX = x; mInitialY = y;
        }

        public DebugBehavior()
            : this(0, 0)
        { ; }

        protected override void OnAttached()
        {
            base.OnAttached();
            m_element = base.AssociatedObject.FrameworkElement;
            m_translateTransform = base.AssociatedObject.TranslateTransform;
            m_scaleTransform = base.AssociatedObject.ScaleTransform;
            base.AssociatedObject.TranslateTransformUpdated += new EventHandler(AssociatedObject_TranslateTransformUpdated);
            base.AssociatedObject.TouchUp += new TouchContactEventHandler(AssociatedObject_TouchUp);
            base.AssociatedObject.TouchDown += new TouchContactEventHandler(AssociatedObject_TouchDown);
            ((InteractiveBorder)m_element).Child = label;
            label.Text = "Position : (" +  mInitialX + "," + mInitialY + ")";
        }

        public void AssociatedObject_TouchUp(object sender, EventArgs e)
        {
            if (e != null)
            {
                label.Text = "Position : (" + m_translateTransform.X + "," + m_translateTransform.Y + ")";
                GridLayout.shade((int)m_translateTransform.X, (int)m_translateTransform.Y, (int)m_element.Width, (int)m_element.Height);
            }
        }

        public void AssociatedObject_TranslateTransformUpdated(object sender, EventArgs e)
        {
            if (e != null)
            {
                label.Text = "Position : (" + m_translateTransform.X + "," + m_translateTransform.Y + ")";
            }
        }

        public void AssociatedObject_TouchDown(object sender, EventArgs e)
        {
            if (e != null)
            {
                GridLayout.unshade((int)m_translateTransform.X, (int)m_translateTransform.Y, (int)m_element.Width, (int)m_element.Height);
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.TouchDown -= new TouchContactEventHandler(AssociatedObject_TouchDown);
            base.AssociatedObject.TouchUp -= new TouchContactEventHandler(AssociatedObject_TouchUp);
        }


    }
}
