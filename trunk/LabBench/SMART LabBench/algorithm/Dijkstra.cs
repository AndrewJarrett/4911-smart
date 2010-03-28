using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LabBench.language.graph;
using LabBench.language.circuit;

namespace LabBench.algorithm
{

    public class Dijkstra<T>
    {
        private Graph<T> graph;
        private T source;

        private Dictionary<GraphNode<T>, int> distance;
        private Dictionary<GraphNode<T>, GraphNode<T>> previous;

        public Dijkstra(Graph<T> graph, T source)
        {
            this.graph = graph; this.source = source;
            distance = new Dictionary<GraphNode<T>, int>(graph.Count);
            previous = new Dictionary<GraphNode<T>, GraphNode<T>>(graph.Count);
            build();
        }

        public void build() {

            foreach(GraphNode<T> v in graph.Nodes) {
                distance.Add(v, int.MaxValue); // infinity
                previous.Add(v, null);
            }

            distance[graph.Get(source)] = 0;

            NodeList<T> Q = graph.Nodes;

            while (Q.Count > 0)
            {
                GraphNode<T> u = (GraphNode<T>) Q.First();
                foreach (GraphNode<T> n in Q)
                {
                    if (distance[n] < distance[u])
                        u = n;
                }

                if (distance[u] == int.MaxValue)
                    break;

                Q.Remove(u);

                foreach (GraphNode<T> v in u.Neighbors)
                {
                    int alt = distance[u] + u.Costs[u.Neighbors.IndexOf(v)];
                    if (alt < distance[v])
                    {
                        distance[v] = alt;
                        previous[v] = u;
                    }
                }
            }
        }

        // will return empty queue if no path to target exists from source
        public Queue<GraphNode<T>> shortestPathTo(GraphNode<T> target)
        {
            Queue<GraphNode<T>> sequence = new Queue<GraphNode<T>>();
            GraphNode<T> u = target;

            while (previous[u] != null)
            {
                sequence.Enqueue(u);
                u = previous[u];
            }

            return (Queue<GraphNode<T>>) sequence.Reverse();
        }

    }

}
