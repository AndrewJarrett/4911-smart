using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LabBench.DataStructures;

namespace LabBench.Algorithms
{

    public class Dijkstra<T>
    {
        private Graph<ID> graph;
        private Node<ID> source;

        public Dijkstra(Graph<ID> graph, Node<ID> source)
        {
            this.graph = graph; this.source = source;
        }

        public NodeList<ID> run() {
            NodeList<ID> distance = new NodeList<ID>(graph.Count());



            return distance;
        }

    }

}
