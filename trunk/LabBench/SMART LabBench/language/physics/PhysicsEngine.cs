using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LabBench.algorithm;
using LabBench.language;
using LabBench.language.graph;
using LabBench.language.circuit;
using System.Windows.Media;
using libSMARTMultiTouch.Behaviors;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace LabBench.demo
{
    class PhysicsEngine
    {
        private Circuit mCircuit;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="mCircuit">Circuit to which the physics are applied</param>
        public PhysicsEngine(Circuit mCircuit)
        {
            this.mCircuit = mCircuit;
        }

        /// <summary>
        /// Validates the circuit and if valid, applies physics.
        /// </summary>
        /// <returns>true if the circuit is valid, else false</returns>
        public bool applyPhysics()
        {
            if (mCircuit.Nodes.Count < 4)
                return false;

            foreach (Node<Component> n in mCircuit.Nodes)
            {
                if (n.Value != mCircuit.Sink && n.Value != mCircuit.Source)
                {
                    if (n.Value.Resistivity == "input")
                    {
                        mCircuit.addDirectedEdge(mCircuit.Source, n.Value, 0);
                        break;
                    }
                }
            }

            mCircuit.addDirectedEdge(mCircuit.Nodes.Last().Value, mCircuit.Sink, 0);


            Dijkstra<Component> mAlgoritm = new Dijkstra<Component>(mCircuit, mCircuit.Source);

            if ((mAlgoritm.shortestPathTo(mCircuit.Sink)).Count > 1)
            {
                //MessageBox.Show("Hurrah!" + mAlgoritm.shortestPathTo(mCircuit.Sink).Count);

                Component mLightBulb = null;

                foreach (GraphNode<Component> mNode in mCircuit.Nodes)
                {
                    if (mNode.Value.Resistivity == "output")
                    {
                        mLightBulb = mNode.Value;
                    }
                }

                if (mLightBulb != null)
                {

                    Component mLightBulbOn = new Component(mLightBulb.Resistivity, new ImagePNG("light_bulb_on.png"));
                    mCircuit.AddNode(mLightBulbOn);

                    foreach (Connection mConnection in mLightBulb.Connections)
                    {
                        if (mConnection.src == mLightBulb)
                        {
                            Component mMatchedComponent = null;
                            foreach (Connection mCopyConnection in mConnection.dst.Connections)
                            {
                                if (mCopyConnection.src == mLightBulb)
                                    mMatchedComponent = mConnection.dst;
                            }
                            //mConnection.src = mLightBulbOn;
                            mCircuit.connectComponents(mLightBulbOn, mConnection.dst);
                        }
                        else if (mConnection.dst == mLightBulb)
                        {
                            Component mMatchedComponent = null;
                            foreach (Connection mCopyConnection in mConnection.src.Connections)
                            {
                                if (mCopyConnection.dst == mLightBulb)
                                    mMatchedComponent = mConnection.src;
                            }
                            //mConnection.dst = mLightBulbOn;
                            mCircuit.connectComponents(mConnection.src, mLightBulbOn);
                        }
                    }


                    mLightBulbOn.setPose(mLightBulb.getX(), mLightBulb.getY(), mLightBulb.getAngle());

                    TransformGroup mTransformGroup = new TransformGroup();
                    mTransformGroup.Children.Add(new RotateTransform(mLightBulb.getAngle()));
                    mTransformGroup.Children.Add(new TranslateTransform(mLightBulb.getX(), mLightBulb.getY()));

                    mLightBulbOn.LayoutTransform = mTransformGroup;
                    
                    mLightBulbOn.IsTranslateEnabled = true; mLightBulbOn.IsRotateEnabled = true;
                    //mLightBulbOn.RenderTransformOrigin = new Point(mLightBulb.getX(), mLightBulb.getY());
                    //mLightBulbOn.RenderTransform = mTransformGroup;
                    mLightBulbOn.AnimateTranslate(mLightBulb.getX(), mLightBulb.getY(), 0.5, 0.5, new TimeSpan(1));
                    mLightBulbOn.IsMoveToTopOnTouchEnabled = true;
                    mLightBulbOn.Focus();

                   

                    mCircuit.removeComponent(mLightBulb);
                    LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mLightBulbOn);
                    LessonCreator.ActiveLesson.LabBench.Canvas.UpdateLayout();
                    mLightBulbOn.UpdateLayout();
                    mLightBulbOn.Focus();
                    Grid.SetZIndex(mLightBulbOn, Grid.GetZIndex(mLightBulbOn) + 1);
                }           
            }
            else
            {
                //MessageBox.Show("Booo!");
            }

            return true;
        }
    }
}
