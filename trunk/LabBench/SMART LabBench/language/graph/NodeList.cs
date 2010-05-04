using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace LabBench.language.graph                 
{
    /// <summary>
    /// list data structure for generic Nodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NodeList<T> : Collection<Node<T>>
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public NodeList() : base() { }

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="initialSize">initial capacity</param>
        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        /// <summary>
        /// find node by the element it stores
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }
}
