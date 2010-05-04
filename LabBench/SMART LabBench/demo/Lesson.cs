using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabBench.language;
using System.Windows.Controls;
using LabBench.language.ui.layout;

namespace LabBench.demo
{
    class Lesson
    {
        private LabBenchLayout mLabBench;
        private Circuit mCircuit;
        private PhysicsEngine mPhysicsEngine;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="mCanvas">active canvas</param>
        public Lesson(Canvas mCanvas)
        {
            mLabBench = new LabBenchLayout(mCanvas);
            mCircuit = new Circuit();
            mPhysicsEngine = new PhysicsEngine(mCircuit);
        }

        /// <summary>
        /// create the default UI layout
        /// </summary>
        public void initialize()
        {
            mLabBench.createLayout();
        }

        /// <summary>
        /// accessor to the LabBench
        /// </summary>
        public LabBenchLayout LabBench
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
        /// accessor to the PhysicsEngine
        /// </summary>
        public PhysicsEngine Engine
        {
            get { return mPhysicsEngine; }
        }
    }
}
