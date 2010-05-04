using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabBench.language;
using System.Windows.Controls;
using LabBench.language.ui.layout;

namespace LabBench.demo
{
    /// <summary>
    /// a lesson that can be played by the user
    /// </summary>
    class PlayableLesson
    {
        private PlayerLabBenchLayout mLabBench;
        private Circuit mCircuit;
        private PhysicsEngine mPhysicsEngine;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mCanvas">Canvas that all UI elements are drawn to</param>
        public PlayableLesson(Canvas mCanvas)
        {
            mLabBench = new PlayerLabBenchLayout(mCanvas);
            mCircuit = new Circuit();
            mPhysicsEngine = new PhysicsEngine(mCircuit);
        }

        /// <summary>
        /// initialize the UI layout
        /// </summary>
        public void initialize()
        {
            mLabBench.createLayout();
        }

        /// <summary>
        /// accessor to the LabBench
        /// </summary>
        public PlayerLabBenchLayout LabBench
        {
            set { mLabBench = value; }
            get { return mLabBench; }
        }

        /// <summary>
        /// accessor to the Circuit
        /// </summary>
        public Circuit Circuit
        {
            set { mCircuit = value; }
            get { return mCircuit; }
        }

        /// <summary>
        /// accessor to the Physics Engine
        /// </summary>
        public PhysicsEngine Engine
        {
            get { return mPhysicsEngine; }
        }
    }
}
