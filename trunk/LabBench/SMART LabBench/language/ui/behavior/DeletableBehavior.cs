﻿using System;
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
            this.mCanvas = GridLayout.source;
        }

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
                if (m_translateTransform.X < 50 && m_translateTransform.Y < 50)
                {
                    mCanvas.Children.Remove(m_element);
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