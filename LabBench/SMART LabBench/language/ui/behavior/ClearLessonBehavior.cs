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
    /// <summary>
    /// behavior that allows UI elements to clear the lesson
    /// </summary>
    public class ClearLessonBehavior : Behavior<InteractiveFrameworkElement>
    {
        private FrameworkElement m_element;
        private TranslateTransform m_translateTransform;
        private ScaleTransform m_scaleTransform;

        private Canvas mCanvas;

        /// <summary>
        /// default constructor
        /// </summary>
        public ClearLessonBehavior() {
            try
            {
                this.mCanvas = LessonCreator.ActiveLesson.LabBench.Canvas;
            }
            catch (Exception e)
            {
                this.mCanvas = LessonPlayer.ActiveLesson.LabBench.Canvas;
            }
        }

        /// <summary>
        /// start up function
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            m_element = base.AssociatedObject.FrameworkElement;
            m_translateTransform = base.AssociatedObject.TranslateTransform;
            m_scaleTransform = base.AssociatedObject.ScaleTransform;
            base.AssociatedObject.TouchUp += new TouchContactEventHandler(AssociatedObject_TouchUp);
        }

        /// <summary>
        /// processes releasing the UI element
        /// </summary>
        /// <param name="sender">the UI element</param>
        /// <param name="e">the touch event</param>
        public void AssociatedObject_TouchUp(object sender, TouchContactEventArgs e)
        {
            if (e != null)
            {
                LessonCreator.ActiveLesson.Circuit.deleteCircuit();
            }
        }

        /// <summary>
        /// closing function
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.TouchUp -= new TouchContactEventHandler(AssociatedObject_TouchUp);
        }
    }
}
