﻿using System.Linq;
using LabBench.language.graph;
using LabBench.demo;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using libSMARTMultiTouch.Controls;
using LabBench.language.circuit;
using System.Collections.Generic;

namespace LabBench.language
{
    public class Circuit : Graph<Component>
    {
        private Component source = new Component(), sink = new Component();

        public Circuit() : base()
        {
            AddNode(source); AddNode(sink);
            AddDirectedEdge(Get(source), Get(sink), int.MaxValue); // open
        }

        public void deleteCircuit()
        {
            MessageBox.Show("size : " + Nodes.Count);
            while(Nodes.Count > 2) {
                Node<Component> n = Nodes.Last();
                if(n.Value != source && n.Value != sink) {
                    //LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(n.Value);
                    //Remove(n.Value);
                    removeComponent(n.Value);
                }
            }
            MessageBox.Show("size : " + Nodes.Count);
        }

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

                    int lbX = (int) n.Value.getX(), lbY = (int) n.Value.getY();
                    int ubX = (int)(lbX + n.Value.getSource().Source.Width), ubY = (int)(lbY + n.Value.getSource().Source.Height);

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

        public void removeComponent(Component mComponent)
        {
            mComponent.clear();
            foreach (Connection mConnection in mComponent.Connections)
            {
                LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mConnection.wire);
                RemoveUndirectedEdge(Get(mConnection.src), Get(mConnection.dst), 0);
                if (mComponent == mConnection.src)
                {
                    MessageBox.Show("deleting @ dst");
                    mConnection.dst.Connections.Remove(mConnection);
                }
                else
                {
                    MessageBox.Show("deleting @ src");
                    mConnection.src.Connections.Remove(mConnection);
                }
            }

            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mComponent);
            Nodes.Remove(Get(mComponent));
            
        }

        public void connectComponents(Component src, Component dst) //, Point start, Point end)
        {
            Point start = new Point((int)(src.getX() + (src.Width / 2)), (int)(src.getY() + (src.Height / 2)));
            Point end = new Point((int)(dst.getX() + (dst.Width / 2)), (int)(dst.getY() + (dst.Height / 2)));

            Line mLine = new Line();
            mLine.X1 = start.X; mLine.Y1 = start.Y;
            mLine.X2 = end.X; mLine.Y2 = end.Y;
            mLine.Stroke = Brushes.PowderBlue;
            mLine.StrokeThickness = 25;

            DraggableBorder mDraggableBorder = new DraggableBorder();
            mDraggableBorder.IsRotateEnabled = false;
            mDraggableBorder.IsTranslateEnabled = false;
            mDraggableBorder.Child = mLine;

            LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mDraggableBorder);

            Connection mConnection = new Connection(src, dst, mDraggableBorder);

            src.addConnection(mConnection); dst.addConnection(mConnection);

            AddUndirectedEdge(Get(src), Get(dst), 0);
        }
    }
}
