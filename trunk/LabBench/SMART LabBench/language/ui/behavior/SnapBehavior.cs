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
using libSMARTMultiTouch.Behaviors;
using LabBench.language.ui.layout;

namespace LabBench.language.ui.control
{
    public class SnapBehavior : Behavior<InteractiveFrameworkElement>
    {
        private FrameworkElement m_element;
        private TranslateTransform m_translateTransform;
        private ScaleTransform m_scaleTransform;
        private RotateTransform m_rotateTransform;

        private const int SNAP_LEVEL = 25;

        protected override void OnAttached()
        {
            base.OnAttached();
            m_element = base.AssociatedObject.FrameworkElement;
            m_translateTransform = base.AssociatedObject.TranslateTransform;
            m_rotateTransform = base.AssociatedObject.RotateTransform;
            m_scaleTransform = base.AssociatedObject.ScaleTransform;
            base.AssociatedObject.TouchUp += new TouchContactEventHandler(AssociatedObject_TouchUp);
            base.AssociatedObject.TouchMove += new TouchContactEventHandler(AssociatedObject_TouchMove);
            base.AssociatedObject.RestPositionReached += new EventHandler(AssociatedObject_RestPositionReached);
        }

        public void AssociatedObject_RestPositionReached(object sender, EventArgs e)
        {
            if (e != null)
            {
                m_translateTransform.X = Math.Round(m_translateTransform.X / SNAP_LEVEL) * SNAP_LEVEL;
                m_translateTransform.Y = Math.Round(m_translateTransform.Y / SNAP_LEVEL) * SNAP_LEVEL;
                if (typeof(Component) == m_element.GetType())
                {
                    ((Component)m_element).setPose(m_translateTransform.X, m_translateTransform.Y, m_rotateTransform.Angle);
                }
            }
        }

        public void AssociatedObject_TouchUp(object sender, TouchContactEventArgs e)
        {
            if (e != null)
            {
                m_translateTransform.X = Math.Round(m_translateTransform.X / SNAP_LEVEL) * SNAP_LEVEL;
                m_translateTransform.Y = Math.Round(m_translateTransform.Y / SNAP_LEVEL) * SNAP_LEVEL;
                if (typeof(Component) == m_element.GetType())
                {
                    ((Component)m_element).setPose(m_translateTransform.X, m_translateTransform.Y, m_rotateTransform.Angle);
                }
            }
        }

        public void AssociatedObject_TouchMove(object sender, TouchContactEventArgs e)
        {
            if (e != null)
            {
                if (typeof(Component) == m_element.GetType())
                {
                    ((Component)m_element).setPose(m_translateTransform.X, m_translateTransform.Y, m_rotateTransform.Angle);
                }
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.TouchUp -= new TouchContactEventHandler(AssociatedObject_TouchUp);
            base.AssociatedObject.TouchMove -= new TouchContactEventHandler(AssociatedObject_TouchMove);
            base.AssociatedObject.RestPositionReached -= new EventHandler(AssociatedObject_RestPositionReached);
        }
    }
}
