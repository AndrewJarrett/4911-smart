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
using System.Collections.ObjectModel;

namespace LabBench.language.ui.control
{
    public class CreateObjectBehavior : Behavior<InteractiveFrameworkElement>
    {
        private FrameworkElement m_element;
        private TranslateTransform m_translateTransform;
        private ScaleTransform m_scaleTransform;

        private Point start, end;

        protected override void OnAttached()
        {
            base.OnAttached();
            m_element = base.AssociatedObject.FrameworkElement;
            m_translateTransform = base.AssociatedObject.TranslateTransform;
            m_scaleTransform = base.AssociatedObject.ScaleTransform;
            base.AssociatedObject.TouchUp += new TouchContactEventHandler(AssociatedObject_TouchUp);
            base.AssociatedObject.TouchDown += new TouchContactEventHandler(AssociatedObject_TouchDown);
        }

        public void AssociatedObject_TouchDown(object sender, TouchContactEventArgs e)
        {
            if (e != null)
            {
                start = e.TouchContact.Position;
            }
        }


        public void AssociatedObject_TouchUp(object sender, TouchContactEventArgs e)
        {
            if (e != null)
            {
                end = e.TouchContact.Position;

                GridLayout.create(start, end);
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
