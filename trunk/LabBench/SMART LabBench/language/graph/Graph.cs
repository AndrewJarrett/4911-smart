using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LabBench.language.graph
{
    /// <summary>
    /// a Graph data structure
    /// </summary>
    /// <typeparam name="T">type of element</typeparam>
    public class Graph<T> : IEnumerable<T>
    {
        private NodeList<T> nodeSet;

        /// <summary>
        /// default constructor
        /// </summary>
        public Graph() : this(null) { }

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="nodeSet">list of Nodes to populate Graph</param>
        public Graph(NodeList<T> nodeSet)
        {
            if (nodeSet == null)
                this.nodeSet = new NodeList<T>();
            else
                this.nodeSet = nodeSet;
        }

        /// <summary>
        /// add a directed edge to the Graph
        /// </summary>
        /// <param name="from">source</param>
        /// <param name="to">destination</param>
        /// <param name="cost">weight</param>
        public void AddDirectedEdge(T from, T to, int cost)
        {
            AddDirectedEdge(Get(from), Get(to), cost);
        }


        /// <summary>
        /// add a Node to the Graph
        /// </summary>
        /// <param name="node">a node</param>
        public void AddNode(GraphNode<T> node)
        {
            // adds a node to the graph
            nodeSet.Add(node);
        }

        /// <summary>
        /// add an Element to the Graph
        /// </summary>
        /// <param name="value">an element</param>
        public void AddNode(T value)
        {
            // adds a node to the graph
            nodeSet.Add(new GraphNode<T>(value));
        }

        /// <summary>
        /// add a directed edge to the Graph
        /// </summary>
        /// <param name="from">source</param>
        /// <param name="to">destination</param>
        /// <param name="cost">weight</param>
        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }

        /// <summary>
        /// add an undirected edge to the Graph
        /// </summary>
        /// <param name="from">source</param>
        /// <param name="to">destination</param>
        /// <param name="cost">weight</param>
        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);

            to.Neighbors.Add(from);
            to.Costs.Add(cost);
        }

        /// <summary>
        /// add an undirected edge to the Graph
        /// </summary>
        /// <param name="from">value of source</param>
        /// <param name="to">value of destination</param>
        /// <param name="cost">weight</param>
        public void AddUndirectedEdge(T from, T to, int cost)
        {
            AddUndirectedEdge(Get(from), Get(to), cost);
        }

        /// <summary>
        /// remove an undirected edge from the Graph
        /// </summary>
        /// <param name="from">source</param>
        /// <param name="to">destination</param>
        /// <param name="cost">weight</param>
        public void RemoveUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Remove(to);
            from.Costs.Remove(cost);

            to.Neighbors.Remove(from);
            to.Costs.Remove(cost);
        }

        /// <summary>
        /// remove an undirected edge from the Graph
        /// </summary>
        /// <param name="from">value of source</param>
        /// <param name="to">value of destination</param>
        /// <param name="cost">weight</param>
        public void RemoveUndirectedEdge(T from, T to, int cost)
        {
            RemoveUndirectedEdge(Get(from), Get(to), cost);
        }

        /// <summary>
        /// remove a directed edge from the Graph
        /// </summary>
        /// <param name="from">source</param>
        /// <param name="to">destination</param>
        /// <param name="cost">weight</param>
        public void RemoveDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Remove(to);
            from.Costs.Remove(cost);
        }

        /// <summary>
        /// remove a directed edge from the Graph
        /// </summary>
        /// <param name="from">value of source</param>
        /// <param name="to">value of destination</param>
        /// <param name="cost">weight</param>
        public void RemoveDirectedEdge(T from, T to, int cost)
        {
            Get(from).Neighbors.Remove(Get(to));
            Get(from).Costs.Remove(cost);
        }

        /// <summary>
        /// check if the element exists in the Graph
        /// </summary>
        /// <param name="value">element to be found</param>
        /// <returns>true if found, else false</returns>
        public bool Contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }

        /// <summary>
        /// return a node from the Graph
        /// </summary>
        /// <param name="value">element stored in that node</param>
        /// <returns>the node with that element, else null</returns>
        public GraphNode<T> Get(T value)
        {
            if (Contains(value))
                return (GraphNode<T>) nodeSet.FindByValue(value);
            else
                return null;
        }

        /// <summary>
        /// remove a node from the Graph
        /// </summary>
        /// <param name="value">element stored in that node</param>
        /// <returns>true if it was removed, else false</returns>
        public bool Remove(T value)
        {
            // first remove the node from the nodeset
            GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
            if (nodeToRemove == null)
                // node wasn't found
                return false;

            // otherwise, the node was found
            nodeSet.Remove(nodeToRemove);

            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (GraphNode<T> gnode in nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    // remove the reference to the node and associated cost
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        /// <summary>
        /// the list of Nodes in the Graph
        /// </summary>
        public NodeList<T> Nodes
        {
            get { return nodeSet; }
        }

        /// <summary>
        /// the number of Nodes in the Graph
        /// </summary>
        public int Count
        {
            get { return nodeSet.Count; }
        }



        #region IEnumerable<T> Members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
