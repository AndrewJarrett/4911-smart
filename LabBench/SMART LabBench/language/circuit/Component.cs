using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabBench.language.ui;
using System.Windows.Interactivity;
using libSMARTMultiTouch;
using LabBench.language.ui.control;
using libSMARTMultiTouch.Behaviors;
using libSMARTMultiTouch.Controls;
using LabBench.demo;
using System.Windows.Shapes;
using System.Windows;
using LabBench.language.circuit;
using System.Windows.Media;

namespace LabBench.language
{
    public class Component : Icon
    {
        private Dictionary<String, Behavior<InteractiveFrameworkElement>> behaviors = 
            new Dictionary<String,Behavior<InteractiveFrameworkElement>>();

        private List<Connection> mConnectionList = new List<Connection>();

        public Component(ImagePNG icon)
            : base(icon)
        { setBehavior(); }

        public Component()
            : base(new ImagePNG("default.png"))
        { ; }

        void setBehavior()
        {
            newBehavior("Snap", new SnapBehavior());
            newBehavior("Deleteable", new DeletableBehavior());
            newBehavior("MoveToTopOnTouch", new MoveToTopOnTouchBehavior());
        }

        public void toggleBehavior(String mName, Behavior<InteractiveFrameworkElement> mBehavior)
        {
            if (behaviors[mName] != null)
            {
                behaviors[mName] = mBehavior;
                this.Attach(mBehavior);
            }
            else
            {
                this.Detach(behaviors[mName]);
                behaviors[mName] = null;
            }
        }

        new public void setPose(double x, double y, double angle)
        {
            base.setPose(x, y, angle);

            List<Connection> mWhiteList = new List<Connection>();
            List<Connection> mBlackList = new List<Connection>();

            foreach (Connection mConnection in mConnectionList)
            {
                Point start = new Point(0,0), end = new Point(0,0);

                if (this == mConnection.src)
                {
                    start = new Point((int)(getX() + (Width / 2)), (int)(getY() + (Height / 2)));
                    end = new Point((int)((Line)mConnection.wire.Child).X2, (int)((Line)mConnection.wire.Child).Y2);

                }
                else //if (this == mConnection.dst)
                {
                    start = new Point((int)((Line)mConnection.wire.Child).X1, (int)((Line)mConnection.wire.Child).Y1);
                    end = new Point((int)(getX() + (Width / 2)), (int)(getY() + (Height / 2)));

                }

                LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mConnection.wire);
                
                Line mLine = new Line();
                mLine.X1 = start.X; mLine.Y1 = start.Y;
                mLine.X2 = end.X; mLine.Y2 = end.Y;

                mLine.StrokeEndLineCap = PenLineCap.Round;
                mLine.StrokeThickness = 25;
                mLine.Stroke = Brushes.PowderBlue;

                DraggableBorder mDraggableBorder = new DraggableBorder();
                mDraggableBorder.IsTranslateEnabled = false; mDraggableBorder.IsRotateEnabled = false;
                mDraggableBorder.Child = mLine;

                LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mDraggableBorder);

                mConnection.wire = mDraggableBorder;
            }
        }

        public void newBehavior(String mName, Behavior<InteractiveFrameworkElement> mBehavior) {
            behaviors.Add(mName, mBehavior);
            this.Attach(mBehavior);
        }

        public void addConnection(Connection mConnection)
        {
            mConnectionList.Add(mConnection);
        }

        public List<Connection> Connections
        {
            get { return mConnectionList; }
        }

        public void clear()
        {
            foreach (String mBehavior in behaviors.Keys)
            {
                Detach(behaviors[mBehavior]);
            }
        }
    }
}
