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
            if (mCircuit.Nodes.Count < 5)
            {
                switchState(false, mCircuit.Nodes);
                return false;
            }

            Component mPowerSource = null;

            foreach (Node<Component> n in mCircuit.Nodes)
            {
                if (n.Value != mCircuit.Sink && n.Value != mCircuit.Source)
                {
                    if (n.Value.Resistivity == "input")
                    {
                        mPowerSource = n.Value;
                        mCircuit.AddUndirectedEdge(mCircuit.Source, mPowerSource, 0);
                        break;
                    }
                }
            }

            // circuit doesn't have a power source
            if (mPowerSource == null)
            {
                switchState(false, mCircuit.Nodes);
                return false;
            }

            Component mLastComponent = null;

            for (int index = mCircuit.Nodes.Count - 1; index >= 0; index--)
            {
                Component mCurrentComponent = mCircuit.Nodes[index].Value;
                if (mCurrentComponent.Resistivity == "conductor")
                {
                    if (mCircuit.Get(mCurrentComponent).Neighbors.Contains(mCircuit.Get(mPowerSource)))
                    {
                        mLastComponent = mCircuit.Nodes[index].Value;
                        break;
                    }
                }
            }

            if (mLastComponent != null)
            {
                //MessageBox.Show("Found an anchor.");
                mCircuit.RemoveUndirectedEdge(mLastComponent, mPowerSource, 0);
                mCircuit.AddUndirectedEdge(mLastComponent, mPowerSource, 200);
                //MessageBox.Show("count : " + mCircuit.Get(mLastComponent).Costs[mCircuit.Get(mLastComponent).Neighbors.IndexOf(mCircuit.Get(mPowerSource))]);
                //MessageBox.Show("count : " + mCircuit.Get(mPowerSource).Costs[mCircuit.Get(mPowerSource).Neighbors.IndexOf(mCircuit.Get(mLastComponent))]);
                mCircuit.AddUndirectedEdge(mLastComponent, mCircuit.Sink, 0);

            }

            Dijkstra<Component> mAlgoritm = new Dijkstra<Component>(mCircuit, mCircuit.Source);
            Queue<GraphNode<Component>> mShortestPath = mAlgoritm.shortestPathTo(mCircuit.Sink);

            String message = "< ";
            foreach (GraphNode<Component> mNode in mShortestPath.Reverse())
            {
                message += mNode.Value.Resistivity + " ";
            }
            message += " >";
            MessageBox.Show(message);

            foreach (GraphNode<Component> mNode in mShortestPath)
            {
                if (mNode.Value.Resistivity == "insulator")
                {
                    switchState(false, mCircuit.Nodes);
                    return false;
                }
            }

            bool isValid = false;

            if (mShortestPath.Count > 1)
            {
                MessageBox.Show("Hurrah!" + mShortestPath.Count);
                isValid = true;

                Component mLightBulb = null;

                foreach (GraphNode<Component> mNode in mShortestPath)
                {
                    if (mNode.Value.Resistivity == "output")
                    {
                        mLightBulb = mNode.Value;
                        MessageBox.Show("Found a light bulb in the circuit");
                    }
                }

                if (mLightBulb != null)
                {
                    switchOutput("light_bulb_on.png", mLightBulb);
                }           
            }

            mCircuit.RemoveUndirectedEdge(mCircuit.Source, mPowerSource, 0);
            if (mLastComponent != null)
            {
                mCircuit.RemoveUndirectedEdge(mLastComponent, mCircuit.Sink, 0);
                mCircuit.RemoveUndirectedEdge(mLastComponent, mPowerSource, 200);
                mCircuit.AddUndirectedEdge(mLastComponent, mPowerSource, 0);
            }

            if (!isValid) switchState(false, mCircuit.Nodes);

            return isValid;
        }

        private void switchState(bool mState, NodeList<Component> mComponentList)
        {
            Component mLightBulb = null;

            foreach (GraphNode<Component> mNode in mComponentList)
            {
                if (mNode.Value.Resistivity == "output")
                {
                    mLightBulb = mNode.Value;
                    //MessageBox.Show("Found a light bulb in the circuit");
                }
            }

            if (mLightBulb != null)
            {
                if (!mState)
                {
                    switchOutput("light_bulb_off.png", mLightBulb);
                }
                else
                {
                    switchOutput("light_bulb_on.png", mLightBulb);
                }
            }  
        }

        private void switchOutput(String mOutput, Component mLightBulb)
        {
            Component mLightBulbOn = new Component(mLightBulb.Resistivity, new ImagePNG(mOutput));
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
            try
            {
                LessonCreator.ActiveLesson.LabBench.Canvas.Children.Add(mLightBulbOn);
                LessonCreator.ActiveLesson.LabBench.Canvas.UpdateLayout();
            }
            catch (Exception ex)
            {
                LessonPlayer.ActiveLesson.LabBench.Canvas.Children.Add(mLightBulbOn);
                LessonPlayer.ActiveLesson.LabBench.Canvas.UpdateLayout();
            }
            mLightBulbOn.UpdateLayout();
            mLightBulbOn.Focus();
            Grid.SetZIndex(mLightBulbOn, Grid.GetZIndex(mLightBulbOn) + 1);
        }
    }

}
