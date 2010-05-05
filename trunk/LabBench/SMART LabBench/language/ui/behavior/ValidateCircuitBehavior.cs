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
    public class ValidateCircuitBehavior : Behavior<InteractiveFrameworkElement>
    {
        private FrameworkElement m_element;
        private TranslateTransform m_translateTransform;
        private ScaleTransform m_scaleTransform;

        private Canvas mCanvas;

        public ValidateCircuitBehavior() {
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
                try
                {
                    GridLayout.toggleApplyPhysicsButton(LessonCreator.ActiveLesson.Engine.applyPhysics());
                }
                catch (Exception ex)
                {
                    PlayerGridLayout.toggleApplyPhysicsButton(LessonPlayer.ActiveLesson.Engine.applyPhysics());
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
