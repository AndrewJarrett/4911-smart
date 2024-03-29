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
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using LabBench.demo;

namespace LabBench.language.ui.control
{
    /// <summary>
    /// behavior allowing UI element to enter/exit wiring mode
    /// </summary>
    public class CreateObjectBehavior : Behavior<InteractiveFrameworkElement>
    {
        private FrameworkElement m_element;
        private TranslateTransform m_translateTransform;
        private ScaleTransform m_scaleTransform;

        private Point start, end;
        private Line line;
        private InteractiveBorder db;

        private Ellipse mEllipseStart;
        private Ellipse mEllipseMove;

        private Component src;

        /// <summary>
        /// start up function
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            m_element = base.AssociatedObject.FrameworkElement;
            m_translateTransform = base.AssociatedObject.TranslateTransform;
            m_scaleTransform = base.AssociatedObject.ScaleTransform;
            base.AssociatedObject.TouchDown += new TouchContactEventHandler(AssociatedObject_TouchDown);
            base.AssociatedObject.TouchMove += new TouchContactEventHandler(AssociatedObject_TouchMove);
            base.AssociatedObject.TouchUp += new TouchContactEventHandler(AssociatedObject_TouchUp);

            start.X = -1; start.Y = -1; line = null; db = null;
        }

        /// <summary>
        /// touch event handler for moving UI element
        /// </summary>
        /// <param name="sender">UI element</param>
        /// <param name="e">touch event</param>
        public void AssociatedObject_TouchMove(object sender, TouchContactEventArgs e)
        {
            if (e != null)
            {
                if (mEllipseStart != null)
                {
                    if (mEllipseMove != null)
                    {
                        try
                        {
                            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mEllipseMove);
                        }
                        catch (Exception ex)
                        {
                            LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Remove(mEllipseMove);
                        }
                    }

                    Point move = e.TouchContact.Position;
                    move.X = Math.Round(move.X / 25) * 25;
                    move.Y = Math.Round(move.Y / 25) * 25;

                    mEllipseMove = new Ellipse();
                    mEllipseMove.Width = 10;
                    mEllipseMove.Height = 10;
                    mEllipseMove.Fill = new SolidColorBrush(Colors.Red);
                    try
                    {
                        LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mEllipseMove);
                    }
                    catch (Exception ex)
                    {
                        LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Add(mEllipseMove);
                    }
                    Canvas.SetLeft(mEllipseMove, move.X - 5);
                    Canvas.SetTop(mEllipseMove, move.Y - 5);
                    Grid.SetZIndex(mEllipseMove, int.MaxValue);
                }
            }
        }

        /// <summary>
        /// touch event handler for pressing down on UI element
        /// </summary>
        /// <param name="sender">UI element</param>
        /// <param name="e">touch event</param>
        public void AssociatedObject_TouchDown(object sender, TouchContactEventArgs e)
        {
            if (e != null)
            {
                start = e.TouchContact.Position;

                if (start.X > 100 && start.X < 175 && start.Y > 0 && start.Y < 75)
                {
                    try
                    {
                        GridLayout.demote();
                    }
                    catch (Exception ex)
                    {
                        PlayerGridLayout.demote();
                    }
                    return;
                }


                if (mEllipseStart != null)
                {
                    try
                    {
                        LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mEllipseStart);
                    }
                    catch (Exception ex)
                    {
                        LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Remove(mEllipseStart);
                    }
                }

                start = e.TouchContact.Position;
                try
                {
                    src = LessonCreator.ActiveLesson.Circuit.componentAtCursor(start);
                }
                catch (Exception ex)
                {
                    src = LessonPlayer.ActiveLesson.Circuit.componentAtCursor(start);
                }
                
                if(src != null)
                {

                    start.X = Math.Round(start.X / 25) * 25;
                    start.Y = Math.Round(start.Y / 25) * 25;

                    mEllipseStart = new Ellipse();
                    mEllipseStart.Width = 10;
                    mEllipseStart.Height = 10;
                    mEllipseStart.Fill = new SolidColorBrush(Colors.Red);
                    try{
                        LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mEllipseStart);
                    }
                    catch (Exception ex){
                        LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Add(mEllipseStart);
                    }
                    Grid.SetZIndex(mEllipseStart, int.MaxValue);
                    Canvas.SetLeft(mEllipseStart, start.X - 5);
                    Canvas.SetTop(mEllipseStart, start.Y - 5);
                }
            }
        }

        /// <summary>
        /// touch event handler for releasing UI element
        /// </summary>
        /// <param name="sender">UI element</param>
        /// <param name="e">touch event</param>
        public void AssociatedObject_TouchUp(object sender, TouchContactEventArgs e)
        {
            if (e != null)
            {
                if (mEllipseStart != null)
                {
                    try
                    {
                        LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mEllipseStart);
                        LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mEllipseMove);
                    }
                    catch (Exception ex)
                    {
                        LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Remove(mEllipseStart);
                        LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Remove(mEllipseMove);
                    }
                    mEllipseStart = null;

                    end = e.TouchContact.Position;
                    Component dst;
                    try
                    {
                        dst = LessonCreator.ActiveLesson.Circuit.componentAtCursor(end);
                    }
                    catch (Exception ex)
                    {
                        dst = LessonPlayer.ActiveLesson.Circuit.componentAtCursor(end);
                    }
                    if (dst != null)
                    {

                        end.X = Math.Round(end.X / 25) * 25;
                        end.Y = Math.Round(end.Y / 25) * 25;

                        try
                        {
                            LessonCreator.ActiveLesson.Circuit.connectComponents(src, dst);
                        }
                        catch (Exception ex)
                        {
                            LessonPlayer.ActiveLesson.Circuit.connectComponents(src, dst);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// closing function
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.TouchUp -= new TouchContactEventHandler(AssociatedObject_TouchUp);
            base.AssociatedObject.TouchMove -= new TouchContactEventHandler(AssociatedObject_TouchMove);
            base.AssociatedObject.TouchDown -= new TouchContactEventHandler(AssociatedObject_TouchDown);
        }
    }
}
