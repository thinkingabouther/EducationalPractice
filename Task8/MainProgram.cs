using System;
using System.Collections.Generic;
using System.Linq;

namespace Task8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Graph graph1 = new Graph();
            Graph graph2 = new Graph();
            int numberOfNodes, numberOfBranches;
            bool flag = false;
            do
            {
                numberOfNodes = Utilities.ConsoleInputParse.Int("Input the number of nodes", "Input error, should be integer");
                if (numberOfNodes < 1 || numberOfNodes > 9)
                {
                    Console.WriteLine("Number of nodes should be positive and should be less than 10");
                }
                else flag = true;
            } while (!flag);
            
            flag = false;
            do
            {
                numberOfBranches = Utilities.ConsoleInputParse.Int("Input the number of branches", "Input error, should be integer");
                if (numberOfBranches < 1)
                {
                    Console.WriteLine("Number of branches should be positive");
                }
                else flag = true;
            } while (!flag);
            
            Graph.FillWithNodes(graph1, numberOfNodes);
            Graph.FillWithNodes(graph2, numberOfNodes, numberOfNodes);
            List<Graph> graphs = new List<Graph>();
            graphs.Add(graph1);
            graphs.Add(graph2);
            for (int k = 0; k < 2; k++)
            {
                Console.WriteLine($"Input info about {k+1} graph");

                for (int i = 0; i < numberOfBranches; i++)
                {
                    bool ok = false;
                    int n1, n2;
                    do
                    {
                        n1 = Utilities.ConsoleInputParse.Int(
                            $"Input info about {i + 1} branch. Input number of first node",
                            "input error, try again");
                        if (n1 < 0 || n1 > numberOfNodes - 1)
                        {
                            Console.WriteLine("Incorrect number! Try again");
                        }
                        else ok = true;
                    } while (!ok);

                    ok = false;
                    do
                    {
                        n2 = Utilities.ConsoleInputParse.Int(
                            $"Input info about {i + 1} branch. Input number of second node",
                            "input error, try again");
                        if (n2 < 0 || n2 > numberOfNodes - 1)
                        {
                            Console.WriteLine("Incorrect number! Try again");
                        }
                        else ok = true;
                    } while (!ok);

                    graphs[k].AddBranch(n1, n2);
                }
            }

            foreach (Graph graph in graphs)
            {
                graph.ProcessIncedentNodes();
            }
            Console.WriteLine("1 graph nodes names:");
            foreach (Node node in graph1.Nodes)
            {
                Console.Write(node.Name + " ");
            }
            Console.WriteLine();
            Console.WriteLine("2 graph nodes names:");
            foreach (Node node in graph1.Nodes)
            {
                Console.Write(node.Name + " ");
            }
            Console.WriteLine();
            Console.WriteLine("The correlation is:");
            Console.WriteLine(Graph.GetCorreleation(graph1, graph2, Graph.Isomeric(graph1, graph2)));

//            Graph graph1 = new Graph();
//            Node a = new Node("a");
//            Node b = new Node("b");
//            Node c = new Node("c");
//            Node a1 = new Node("a1");
//            
//            graph1.AddNode(a);
//            graph1.AddNode(b);
//            graph1.AddNode(c);
//            graph1.AddNode(a1);
//            
//            graph1.AddBranch(c, b);
//            graph1.AddBranch(a, c);
//            graph1.AddBranch(c, a1);
//            
//            graph1.ProcessIncedentNodes(); 
//            
//            Graph graph2 = new Graph();
//            Node d = new Node("d");
//            Node e = new Node("e");
//            Node f = new Node("f");
//            Node d1 = new Node("d1");
//            
//            
//            graph2.AddNode(e);
//            graph2.AddNode(d);
//            graph2.AddNode(f);
//            graph2.AddNode(d1);
//            
//            graph2.AddBranch(d, f);
//            graph2.AddBranch(d, e);
//            graph2.AddBranch(d1, d);
//            
//            graph2.ProcessIncedentNodes();
//
//            Console.WriteLine(Graph.GetCorreleation(graph1, graph2, Graph.Isomeric(graph1, graph2)));
//
//            var graph3 = GraphGenerator.GenerateGraph();
//            foreach (var node in graph3.Nodes)
//            {
//                Console.WriteLine(node);
//            }
//
//            var graph4 = GraphGenerator.GenerateIsoGraph(graph3);
//            foreach (Node node in graph4.Nodes)
//            {
//                Console.WriteLine(node);
//            }
//            
//            Console.WriteLine(Graph.GetCorreleation(graph3, graph4, Graph.Isomeric(graph3, graph4)));

        }
    }
} 