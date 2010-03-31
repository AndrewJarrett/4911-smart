using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabBench.language.graph;

namespace LabBench.language
{
    public class Circuit : Graph<Component>
    {
        private Component source, sink;

        public Circuit() : base()
        {
            AddNode(source); AddNode(sink);
            AddDirectedEdge(Get(source), Get(sink), int.MaxValue); // open
        }

    }
}
