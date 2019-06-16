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
            Node a = new Node("a");
            Node b = new Node("b");
            Node c = new Node("c");
            Node a1 = new Node("a1");
            
            graph1.AddNode(a);
            graph1.AddNode(b);
            graph1.AddNode(c);
            graph1.AddNode(a1);
            
            graph1.AddBranch(new Branch(c, b));
            graph1.AddBranch(new Branch(a, c));
            graph1.AddBranch(new Branch(c, a1));
            
            graph1.ProcessIncedentNodes(); 
            
            Graph graph2 = new Graph();
            Node d = new Node("d");
            Node e = new Node("e");
            Node f = new Node("f");
            Node d1 = new Node("d1");
            
            
            graph2.AddNode(e);
            graph2.AddNode(d);
            graph2.AddNode(f);
            graph2.AddNode(d1);
            
            graph2.AddBranch(new Branch(d, f));
            graph2.AddBranch(new Branch(d, e));
            graph2.AddBranch(new Branch(d1, d));
            
            graph2.ProcessIncedentNodes(); 

            Console.WriteLine(Graph.Isomeric(graph1, graph2));
            foreach (Node graph2Node in graph2.Nodes)
            {
                Console.WriteLine(graph2Node);
            }
            foreach (Node graph1Node in graph1.Nodes)
            {
                Console.WriteLine(graph1Node);
            }
        }
    }
} 