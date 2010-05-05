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
    /// <summary>
    /// A visual component which can be placed on the lab bench and manipulated
    /// </summary>
    public class Component : Icon
    {
        private Dictionary<String, Behavior<InteractiveFrameworkElement>> behaviors = 
            new Dictionary<String,Behavior<InteractiveFrameworkElement>>();

        private List<Connection> mConnectionList = new List<Connection>();

        // default properties
        private String mResistivity = "none";

        /// <summary>Class constructor</summary>
        /// <param name="mResistivity">Type of component: insulator, conductor, input, or output</param>
        /// <param name="icon">Image representing this component</param>
        public Component(String mResistivity, ImagePNG icon)
            : base(icon)
        { setBehavior(); this.mResistivity = mResistivity; }

        /// <summary>Class constructor</summary>
        /// <param name="icon">Image representing this component</param>
        public Component(ImagePNG icon)
            : base(icon)
        { setBehavior(); }

        /// <summary>Default class constructor</summary>
        public Component()
            : base(new ImagePNG("default.png"))
        { ; }

        private void setBehavior()
        {
            newBehavior("Snap", new SnapBehavior());
            newBehavior("Deleteable", new DeletableBehavior());
            newBehavior("MoveToTopOnTouch", new MoveToTopOnTouchBehavior());
        }

        /// <summary>Toggles on/off touch input behaviors</summary>
        /// <param name="mName">Canonical name of the behavior</param>
        /// <param name="mBehavior">Reference to the behavior that should be toggled</param>
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

        /// <summary>Set the pose on the canvas of this component</summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="angle">angle about the horizontal</param>
        public void setPose(double x, double y, double angle)
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

                try
                {
                    LessonCreator.ActiveLesson.LabBench.Canvas.Children.Remove(mConnection.wire);
                }
                catch (Exception ex)
                {
                    LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Remove(mConnection.wire);
                }
                
                Line mLine = new Line();
                mLine.X1 = start.X; mLine.Y1 = start.Y;
                mLine.X2 = end.X; mLine.Y2 = end.Y;

                mLine.StrokeThickness = 25;
                mLine.Stroke = Brushes.PowderBlue;
                mLine.StrokeEndLineCap = PenLineCap.Round;

                DraggableBorder mDraggableBorder = new DraggableBorder();
                mDraggableBorder.IsTranslateEnabled = false; mDraggableBorder.IsRotateEnabled = false;
                mDraggableBorder.IsMoveToTopOnTouchEnabled = false;
                mDraggableBorder.Child = mLine;

                try{
                    LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mDraggableBorder);
                }
                catch (Exception ex)
                {
                    LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Add(mDraggableBorder);
                }

                mConnection.wire = mDraggableBorder;
            }
        }

        /// <summary>Add a new touch input behavior to this component</summary>
        /// <param name="mName">Canonical name of the behavior</param>
        /// <param name="mBehavior">Reference to the behavior that should be added</param>
        public void newBehavior(String mName, Behavior<InteractiveFrameworkElement> mBehavior) {
            behaviors.Add(mName, mBehavior);
            this.Attach(mBehavior);
        }

        /// <summary>Add a new connection to this component</summary>
        /// <param name="mConnection">Connection to add</param>
        public void addConnection(Connection mConnection)
        {
            mConnectionList.Add(mConnection);
        }

        /// <summary>Collection of connection from/to this component</summary>
        public List<Connection> Connections
        {
            get { return mConnectionList; }
        }
        
        /// <summary>Remove all behaviors from this component</summary>
        public void clear()
        {
            foreach (String mBehavior in behaviors.Keys)
            {
                Detach(behaviors[mBehavior]);
            }
        }

        /// <summary>Return the component type</summary>
        public String Resistivity {
            set{ mResistivity = value; }
            get{ return mResistivity; }
        }

        public SerializableItem getSerialData()
        {
            SerializableItem ret = new SerializableItem();
            ret.x = x;
            ret.y = y;
            ret.iconName = mImageName;
            ret.angle = angle;
            ret.name = mResistivity;

            return ret;
        }
    }
}
