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

namespace LabBench.language.ui.control
{
    public class DebugBehavior : Behavior<InteractiveFrameworkElement>
    {
        private FrameworkElement m_element;
        private TranslateTransform m_translateTransform;
        private ScaleTransform m_scaleTransform;
        private TextBlock label = new TextBlock();

        protected override void OnAttached()
        {
            base.OnAttached();
            m_element = base.AssociatedObject.FrameworkElement;
            m_translateTransform = base.AssociatedObject.TranslateTransform;
            m_scaleTransform = base.AssociatedObject.ScaleTransform;
            //base.AssociatedObject.RotateTransformUpdated += new EventHandler(AssociatedObject_RotateTransformUpdated);
            base.AssociatedObject.TranslateTransformUpdated += new EventHandler(AssociatedObject_TranslateTransformUpdated);
            base.AssociatedObject.TouchUp += new TouchContactEventHandler(AssociatedObject_TouchUp);
            ((InteractiveBorder)m_element).Child = label;
            ((InteractiveBorder)m_element).Background = new SolidColorBrush(Colors.Red);

            label.Text = "Position : (0,0)";
        }

        public void AssociatedObject_TouchUp(object sender, EventArgs e)
        {
            if (e != null)
            {
                m_translateTransform.X = Math.Round(m_translateTransform.X / 25) * 25;
                m_translateTransform.Y = Math.Round(m_translateTransform.Y / 25) * 25;
                label.Text = "Position : (" + m_translateTransform.X + "," + m_translateTransform.Y + ")";
            }
        }

        public void AssociatedObject_TranslateTransformUpdated(object sender, EventArgs e)
        {
            if (e != null)
            {
                //m_translateTransform.X = Math.Round(m_translateTransform.X / 10) * 10;
                //m_translateTransform.Y = Math.Round(m_translateTransform.Y / 10) * 10;
                label.Text = "Position : (" + m_translateTransform.X + "," + m_translateTransform.Y + ")";
                //TranslateTransform rt = new TranslateTransform();
                //rt.X = m_translateTransform.X;
                //rt.Y = m_translateTransform.Y;
                //((InteractiveBorder)m_element).RenderTransform = rt;
            }
        }


        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.RotateTransformUpdated -= new EventHandler(AssociatedObject_TranslateTransformUpdated);
        }
    }
}
