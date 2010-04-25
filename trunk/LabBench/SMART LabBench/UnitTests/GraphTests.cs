using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LabBench
{
    [TestFixture]
    class GraphTests
    {
        private language.graph.Graph<int> graph;

        [Test]
        public void createNode()
        {
            List<language.graph.Node<int>> nodes = new List<language.graph.Node<int>>();

            language.graph.Node<int> testNode1 = new language.graph.Node<int>();
            language.graph.Node<int> testNode2 = new language.graph.Node<int>(10);
            language.graph.Node<int> testNode3 = new language.graph.Node<int>(5, new language.graph.NodeList<int>(4));

            nodes.Add(testNode1);
            nodes.Add(testNode2);
            nodes.Add(testNode3);

            foreach (language.graph.Node<int> node in nodes)
            {
                Assert.NotNull(node);
            }
        }

        [Test]
        public void createNodeList()
        {
            List<language.graph.NodeList<int>> nodeLists = new List<language.graph.NodeList<int>>();

            language.graph.NodeList<int> testNodeList1 = new language.graph.NodeList<int>();
            language.graph.NodeList<int> testNodeList2 = new language.graph.NodeList<int>(3);

            nodeLists.Add(testNodeList1);
            nodeLists.Add(testNodeList2);

            foreach (language.graph.NodeList<int> nodeList in nodeLists)
            {
                Assert.NotNull(nodeList);
            }
        }

        [Test]
        public void createGraphNode()
        {
            List<language.graph.GraphNode<int>> graphNodes = new List<language.graph.GraphNode<int>>();

            language.graph.GraphNode<int> testGraphNode1 = new language.graph.GraphNode<int>();

            graphNodes.Add(testGraphNode1);

            foreach (language.graph.GraphNode<int> graphNode in graphNodes)
            {
                Assert.NotNull(graphNode);
            }
        }

        [Test]
        public void createGraph()
        {
            language.graph.Graph<int> test1 = new language.graph.Graph<int>();

            Assert.NotNull(test1);
        }

        [Test]
        public void populateGraph()
        {
            language.graph.Graph<int> testGraph = new language.graph.Graph<int>();

            language.graph.NodeList<int> neighbors = new LabBench.language.graph.NodeList<int>(3);
            neighbors.Add(new language.graph.GraphNode<int>(22));
            neighbors.Add(new language.graph.GraphNode<int>(25));
            neighbors.Add(new language.graph.GraphNode<int>(27));

            language.graph.GraphNode<int> root = new LabBench.language.graph.GraphNode<int>(30, neighbors);

            testGraph.AddNode(root);
            testGraph.AddNode(10);
            testGraph.AddNode(13);
            testGraph.AddNode(15);
            testGraph.AddNode(new language.graph.GraphNode<int>(16));
            testGraph.AddNode(new language.graph.GraphNode<int>(18));

            Assert.True(testGraph.Contains(22));
            Assert.True(testGraph.Contains(25));
            Assert.True(testGraph.Contains(27));

            Assert.True(testGraph.Contains(10));
            Assert.True(testGraph.Contains(13));
            Assert.True(testGraph.Contains(15));
            Assert.True(testGraph.Contains(16));
            Assert.True(testGraph.Contains(18));

            Assert.True(testGraph.Contains(30));

            graph = testGraph;
        }

        [Test]
        public void testEdges()
        {
            graph.AddDirectedEdge(graph.Get(22), graph.Get(25), 10);
            graph.AddDirectedEdge(graph.Get(22), graph.Get(27), 15);
            graph.AddDirectedEdge(graph.Get(25), graph.Get(27), 2);
            graph.AddDirectedEdge(graph.Get(27), graph.Get(10), 1);
            graph.AddDirectedEdge(graph.Get(10), graph.Get(18), 8);            
            graph.AddDirectedEdge(graph.Get(10), graph.Get(16), 2);
            graph.AddDirectedEdge(graph.Get(16), graph.Get(22), 15);
            graph.AddDirectedEdge(graph.Get(18), graph.Get(22), 1);

            Assert.Greater(graph.Get(22).Neighbors.Count, 1);
            Assert.Greater(graph.Get(25).Neighbors.Count, 0);
            Assert.Greater(graph.Get(27).Neighbors.Count, 0);
            Assert.Greater(graph.Get(10).Neighbors.Count, 1);
            Assert.Greater(graph.Get(16).Neighbors.Count, 0);
            Assert.Greater(graph.Get(18).Neighbors.Count, 0);

            algorithm.Dijkstra<int> algorithm = new algorithm.Dijkstra<int>(graph, 30);
            Queue<language.graph.GraphNode<int>> path = algorithm.shortestPathTo(graph.Get(22));
            while (path.Count > 1)
            {
                Assert.AreNotEqual(path.Dequeue(), graph.Get(22));
            }
            if (path.Count == 1)
            {
                Assert.AreEqual(path.Dequeue(), graph.Get(22));
            }

            algorithm.Dijkstra<int> failAlgorithm = new algorithm.Dijkstra<int>(graph, 13);
            Queue<language.graph.GraphNode<int>> failPath = algorithm.shortestPathTo(graph.Get(22));
            Assert.AreEqual(failPath.Count, 0);

            graph.Remove(25);
            graph.Remove(27);
            Assert.AreEqual(graph.Get(22).Neighbors.Count, 0);
        }
    }
}
