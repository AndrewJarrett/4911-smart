using System.Linq;
using LabBench.language.graph;
using LabBench.demo;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using libSMARTMultiTouch.Controls;
using LabBench.language.circuit;
using System.Collections.Generic;
using System;

namespace LabBench.language
{
    /// <summary>
    /// Circuit of Components represented as a Graph
    /// </summary>
    public class Circuit : Graph<Component>
    {
        private Component source = new Component(), sink = new Component();

        /// <summary>
        /// class constructor
        /// </summary>
        public Circuit() : base()
        {
            AddNode(source); AddNode(sink);
            AddUndirectedEdge(Get(source), Get(sink), 100); // open
        }

        /// <summary>
        /// delete all components in the circuit
        /// </summary>
        public void deleteCircuit()
        {
            while (Nodes.Count > 0)
            {
                removeComponent(Nodes.Last().Value);
            }
            AddNode(source); AddNode(sink);
            AddUndirectedEdge(Get(source), Get(sink), 100);
        }

        /// <summary>
        /// retrieve the component that exists at the location of the touch input
        /// </summary>
        /// <param name="mPosition">position of the touch input on the canvas</param>
        /// <returns>component at the touch point, else null</returns>
        public Component componentAtCursor(Point mPosition)
        {
            int x = (int) mPosition.X, y = (int) mPosition.Y;
            foreach (Node<Component> n in Nodes)
            {
                if (n.Value != source && n.Value != sink)
                {
                    //MessageBox.Show("cursors @ (" + mPosition.X + "," + mPosition.Y + ")\n"
                    //                + "component @ (" + n.Value.getX() + "," + n.Value.getY() + ")\n"
                    //                + "bounds @ (" + (n.Value.getX() + n.Value.getSource().Source.Width) + ","
                    //                + (n.Value.getY() + n.Value.getSource().Source.Height) + ")");

                    Size mSize = n.Value.RenderSize;
                    Point mPoint = n.Value.RenderTransformOrigin;

                    //MessageBox.Show("component @ (" + mPoint.X + "," + mPoint.Y + ")");
                    //MessageBox.Show("render size : " + mSize.Width + "x" + mSize.Height);

                    int lbX = (int) n.Value.getX(), lbY = (int) n.Value.getY();
                    //int ubX = (int)(lbX + n.Value.getSource().Source.Width), ubY = (int)(lbY + n.Value.getSource().Source.Height);
                    int ubX = (int)(lbX + mSize.Width), ubY = (int)(lbY + mSize.Height);

                    if (x > lbX && x < ubX)
                    {
                        if (y > lbY && y < ubY)
                        {
                            return n.Value;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// remove a component from the Circuit
        /// </summary>
        /// <param name="mComponent">Component to be removed</param>
        public void removeComponent(Component mComponent)
        {
            mComponent.clear();
            foreach (Connection mConnection in mComponent.Connections)
            {
                try
                {
                    LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mConnection.wire);
                }
                catch (Exception ex)
                {
                    LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Remove(mConnection.wire);
                }
                RemoveUndirectedEdge(Get(mConnection.src), Get(mConnection.dst), 0);
                if (mComponent == mConnection.src)
                {
                    //MessageBox.Show("deleting @ dst");
                    mConnection.dst.Connections.Remove(mConnection);
                }
                else
                {
                    //MessageBox.Show("deleting @ src");
                    mConnection.src.Connections.Remove(mConnection);
                }
            }

            try
            {
                LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mComponent);
            }
            catch (Exception ex)
            {
                LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Remove(mComponent);
            }
            Remove(mComponent);
            
        }

        /// <summary>
        /// connect two Components together (UI and Graph)
        /// </summary>
        /// <param name="src">source Component</param>
        /// <param name="dst">destination Component</param>
        public void connectComponents(Component src, Component dst) //, Point start, Point end)
        {
            if (src != dst)
            {
                Point start = new Point((int)(src.getX() + (src.Width / 2)), (int)(src.getY() + (src.Height / 2)));
                Point end = new Point((int)(dst.getX() + (dst.Width / 2)), (int)(dst.getY() + (dst.Height / 2)));

                Line mLine = new Line();
                mLine.X1 = start.X; mLine.Y1 = start.Y;
                mLine.X2 = end.X; mLine.Y2 = end.Y;
                mLine.StrokeThickness = 25;
                mLine.StrokeEndLineCap = PenLineCap.Round;
                mLine.Stroke = Brushes.PowderBlue;// new LinearGradientBrush(Colors.Red, Colors.Black, Math.Atan2(end.Y - start.Y, end.X - start.X));

                DraggableBorder mDraggableBorder = new DraggableBorder();
                mDraggableBorder.IsRotateEnabled = false;
                mDraggableBorder.IsTranslateEnabled = false;
                mDraggableBorder.IsMoveToTopOnTouchEnabled = false;
                mDraggableBorder.Child = mLine;

                try
                {
                    LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mDraggableBorder);
                }
                catch (Exception ex)
                {
                    LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Add(mDraggableBorder);
                }

                Connection mConnection = new Connection(src, dst, mDraggableBorder);

                src.addConnection(mConnection); dst.addConnection(mConnection);

                AddUndirectedEdge(Get(src), Get(dst), 0);
            }
        }

        /// <summary>
        /// accessor to source Component
        /// </summary>
        public Component Source
        {
            get { return source; }
        }

        /// <summary>
        /// accessor to sink Component
        /// </summary>
        public Component Sink
        {
            get { return sink; }
        }
    }
}
