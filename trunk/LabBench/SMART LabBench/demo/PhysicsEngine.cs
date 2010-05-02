using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LabBench.algorithm;
using LabBench.language;
using System.Windows.Forms;

namespace LabBench.demo
{
    class PhysicsEngine
    {
        private Circuit mCircuit;

        public PhysicsEngine(Circuit mCircuit)
        {
            this.mCircuit = mCircuit;
        }

        public bool validate()
        {
            Dijkstra<Component> mAlgoritm = new Dijkstra<Component>(mCircuit, mCircuit.Source);

            if ((mAlgoritm.shortestPathTo(mCircuit.Sink)).Count > 0)
            {
                MessageBox.Show("Hurrah!");
            }
            else
            {
                MessageBox.Show("Booo!");
            }

            return true;
        }
    }
}
