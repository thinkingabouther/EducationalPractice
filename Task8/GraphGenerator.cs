using System;
using System.Collections.Generic;

namespace Task8
{
    public static class GraphGenerator
    {
        public static Graph GenerateGraph()
        {
            Random rnd = new Random();
            int nodesNumber = rnd.Next(1, 9);
            Graph graph = new Graph();
            List<String> namesList = new List<string>();
            for (int i = 0; i < nodesNumber; i++)
            {
                string currName;
                do
                {
                    currName = NodesNamesArray[rnd.Next(NodesNamesArray.Length)];
                } while (namesList.Contains(currName));
                
                namesList.Add(currName);
                graph.AddNode(new Node(currName));
            }

            int maxBranchesNum = graph.Nodes.Count * (graph.Nodes.Count - 1) / 2;
            int branchesNum = rnd.Next(1, maxBranchesNum);
            for (int i = 0; i < branchesNum; i++)
            {
                bool flag;
                do
                {
                    int index1 = rnd.Next(graph.Nodes.Count);
                    int index2;
                    do
                    {
                        index2 = rnd.Next(graph.Nodes.Count);
                    } while (index1 == index2);
                    try
                    {
                        graph.AddBranch(graph.Nodes[index1], graph.Nodes[index2]);
                        flag = true;
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                } while (!flag);
            }

            return graph;

        }

        private static readonly string[] NodesNamesArray =
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r"
        };

        public static Graph GenerateIsoGraph(Graph inputGraph)
        {
            Random rnd = new Random();
            Graph newGraph = new Graph();
            foreach (Node inputGraphNode in inputGraph.Nodes)
            {
                newGraph.AddNode(inputGraphNode);
            }
            foreach (Branch branch in inputGraph.Branches)
            {
                newGraph.AddBranch(newGraph.Nodes[newGraph.Nodes.IndexOf(branch.Node1)], newGraph.Nodes[newGraph.Nodes.IndexOf(branch.Node2)]);
            }
            int index1 = rnd.Next(inputGraph.Nodes.Count);
            int index2;
            do
            {
                index2 = rnd.Next(inputGraph.Nodes.Count);
            } while (index1 == index2);

            var tempNode = newGraph.Nodes[index1];
            var newNode = (Node)tempNode.Clone();
            
            for (int i = 0; i < newGraph.Nodes.Count; i++)
            {
                if (newGraph.Nodes[i].IncedentNodes.Contains(tempNode))
                {
                    newGraph.Nodes[i].IncedentNodes.Add(newNode);
                    newGraph.Nodes[i].IncedentNodes.Remove(tempNode);
                }
            }
            newGraph.Nodes.RemoveAt(index1);
            newGraph.AddNode(newNode);
            
            var tempNode1 = newGraph.Nodes[index2];
            var newNode1 = (Node)tempNode1.Clone();
            
            for (int i = 0; i < newGraph.Nodes.Count; i++)
            {
                if (newGraph.Nodes[i].IncedentNodes.Contains(tempNode1))
                {
                    newGraph.Nodes[i].IncedentNodes.Add(newNode1);
                    newGraph.Nodes[i].IncedentNodes.Remove(tempNode1);
                }
            }

            newGraph.Nodes.RemoveAt(index2);
            newGraph.AddNode(newNode1);
            return newGraph;
        }
    }
}