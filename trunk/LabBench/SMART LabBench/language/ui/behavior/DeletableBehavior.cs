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
using LabBench.demo;

namespace LabBench.language.ui.control
{
    public class DeletableBehavior : Behavior<InteractiveFrameworkElement>
    {
        private FrameworkElement m_element;
        private TranslateTransform m_translateTransform;
        private ScaleTransform m_scaleTransform;

        private Canvas mCanvas;

        public DeletableBehavior(Canvas mCanvas)
        {
            this.mCanvas = mCanvas;
        }

        public DeletableBehavior() {
            try
            {
                this.mCanvas = LessonCreator.ActiveLesson.LabBench.Canvas;
            }
            catch (Exception ex)
            {
                this.mCanvas = LessonPlayer.ActiveLesson.LabBench.Canvas;
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            m_element = base.AssociatedObject.FrameworkElement;
            m_translateTransform = base.AssociatedObject.TranslateTransform;
            m_scaleTransform = base.AssociatedObject.ScaleTransform;
            base.AssociatedObject.TouchUp += new TouchContactEventHandler(AssociatedObject_TouchUp);
        }

        public void AssociatedObject_TouchUp(object sender, TouchContactEventArgs e)
        {
            if (e != null)
            {
                if (e.TouchContact.Position.X < 75 && e.TouchContact.Position.Y < 75)
                {
                    mCanvas.Children.Remove(m_element);
                    if(typeof(Component) == m_element.GetType())
                        LessonCreator.ActiveLesson.Circuit.removeComponent((Component)m_element);
                }
            }
        }


        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.TouchUp -= new TouchContactEventHandler(AssociatedObject_TouchUp);
        }
    }
}
