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

        public Lesson(Canvas mCanvas)
        {
            mLabBench = new LabBenchLayout(mCanvas);
            mCircuit = new Circuit();
        }

        public void initialize()
        {
            mLabBench.createLayout();
        }

        public LabBenchLayout LabBench
        {
            set { mLabBench = value; }
            get { return mLabBench; }
        }

        public Circuit Circuit
        {
            set { mCircuit = value; }
            get { return mCircuit; }
        }
    }
}
