using System;

namespace Task10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var graph = new Graph();
            var node1 = new Node("a", "value1");
            var node2 = new Node("b", "value2");
            var node3 = new Node("c", "value3");
            var node4 = new Node("d", "value3");
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            Console.WriteLine(graph.GetAllNodes());
            graph.DeleteNodesWithValue("value3");
            Console.WriteLine(graph.GetAllNodes());



        }
    }
}