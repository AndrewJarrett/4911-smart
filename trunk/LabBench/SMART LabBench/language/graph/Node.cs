using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabBench.language.graph {
    
    /// <summary>
    /// Generic node data structure
    /// </summary>
    /// <typeparam name="T">type of element</typeparam>
    public class Node<T> {
        // Private member-variables
        private T data;
        private NodeList<T> neighbors = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public Node() {}

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="data">element to be stored in node</param>
        public Node(T data) : this(data, null) {}

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="data">element to be stored in node</param>
        /// <param name="neighbors">list of neighbors to this node</param>
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        /// <summary>
        /// element stored in this node
        /// </summary>
        public T Value {
            get {
                return data;
            }
       
            set {
                data = value;
            }
        }

        /// <summary>
        /// list of neighbors to this node
        /// </summary>
        protected NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }
}
