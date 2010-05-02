using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LabBench.algorithm;
using LabBench.language;
using System.Windows.Forms;
using LabBench.language.graph;

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
            if (mCircuit.Nodes.Count < 4)
                return false;

            foreach (Node<Component> n in mCircuit.Nodes)
            {
                if (n.Value != mCircuit.Sink && n.Value != mCircuit.Source)
                {
                    mCircuit.addDirectedEdge(mCircuit.Source, n.Value, 0);
                    break;
                }
            }

            mCircuit.addDirectedEdge(mCircuit.Nodes.Last().Value, mCircuit.Sink, 0);


            Dijkstra<Component> mAlgoritm = new Dijkstra<Component>(mCircuit, mCircuit.Source);

            if ((mAlgoritm.shortestPathTo(mCircuit.Sink)).Count > 0)
            {
                MessageBox.Show("Hurrah!" + mAlgoritm.shortestPathTo(mCircuit.Sink).Count);
            }
            else
            {
                MessageBox.Show("Booo!");
            }

            return true;
        }
    }
}
