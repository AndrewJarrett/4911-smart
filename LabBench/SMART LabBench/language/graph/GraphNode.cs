using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabBench.language.graph
{
    /// <summary>
    /// A node in the Graph data structure
    /// </summary>
    /// <typeparam name="T">type of element</typeparam>
    public class GraphNode<T> : Node<T>
    {
        private List<int> costs;

        public GraphNode() : base() { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

        /// <summary>
        /// List of neighboring GraphNodes
        /// </summary>
        new public NodeList<T> Neighbors {
            get {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>();

                return base.Neighbors;
            }
        }

        /// <summary>
        /// Weight of edges from this node to another GraphNode
        /// </summary>
        public List<int> Costs {
            get {
                if (costs == null)
                    costs = new List<int>();

                return costs;
            }
        }
    }
}
