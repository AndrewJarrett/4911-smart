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
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.layout;

namespace LabBench.language.ui.control
{
    public class ToggleBehavior : Behavior<InteractiveFrameworkElement>
    {
        private FrameworkElement m_element;
        private TranslateTransform m_translateTransform;
        private ScaleTransform m_scaleTransform;

        private Boolean isOn = false;

        protected override void OnAttached()
        {
            base.OnAttached();
            m_element = base.AssociatedObject.FrameworkElement;
            m_translateTransform = base.AssociatedObject.TranslateTransform;
            m_scaleTransform = base.AssociatedObject.ScaleTransform;
            base.AssociatedObject.TouchUp += new TouchContactEventHandler(AssociatedObject_TouchUp);
        }

        public void AssociatedObject_TouchUp(object sender, EventArgs e)
        {
            if (e != null)
            {
                if (isOn)
                {
                    ((InteractiveBorder)m_element).Background = Brushes.Transparent;
                    isOn = false;
                }
                else
                {
                    Color color = new Color();
                    color.R = 0x22;
                    color.G = 0x22;
                    color.B = 0x22;
                    color.A = 0x22;
                    ((InteractiveBorder)m_element).Background = new SolidColorBrush(color);
                    isOn = true;
                }
                GridLayout.shade((int) m_translateTransform.X, (int) m_translateTransform.Y, 0, 0);
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.TouchUp -= new TouchContactEventHandler(AssociatedObject_TouchUp);
        }
    }
}
