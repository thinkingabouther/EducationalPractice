using System;
using System.Collections.Generic;

namespace Task10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Graph graph = new Graph();
                int numberOfNodes, numberOfBranches;
                bool flag = false;
                do
                {
                    numberOfNodes = Utilities.ConsoleInputParse.Int("Input the number of nodes",
                        "Input error, should be integer");
                    if (numberOfNodes < 1 || numberOfNodes > 10)
                    {
                        Console.WriteLine("Number of nodes should be positive and should be less than 10");
                    }
                    else flag = true;
                } while (!flag);

                for (int i = 0; i < numberOfNodes; i++)
                {
                    Console.WriteLine($"Input the name of {i + 1} node");
                    var curName = Console.ReadLine();
                    var curValue = Utilities.ConsoleInputParse.Int($"Input the value of {curName} node");
                    graph.AddNode(new Node(curName, curValue));
                }

                flag = false;
                do
                {
                    numberOfBranches = Utilities.ConsoleInputParse.Int("Input the number of branches",
                        "Input error, should be integer");
                    if (numberOfBranches < 0)
                    {
                        Console.WriteLine("Number of branches should be positive");
                    }
                    else flag = true;
                } while (!flag);

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

                    graph.AddBranch(n1, n2);
                }

                Console.WriteLine();
                Console.WriteLine("Graph consist of nodes:");
                foreach (Node graphNode in graph.Nodes)
                {
                    Console.WriteLine($"node {graphNode.Name} with value {graphNode.Value}");
                }

                Console.WriteLine("branches");
                foreach (Branch branch in graph.Branches)
                {
                    Console.WriteLine(branch);
                }

                var valueToDelete = Utilities.ConsoleInputParse.Int("Input value to delete");
                graph.DeleteNodesWithValue(valueToDelete);
                Console.WriteLine();

                if (graph.Nodes.Length < 1) Console.WriteLine("There are no nodes left after deleting");
                else
                {

                    Console.WriteLine("After deleting nodes graph consist of nodes:");
                    foreach (Node graphNode in graph.Nodes)
                    {
                        Console.WriteLine($"node {graphNode.Name} with value {graphNode.Value}");
                    }

                    if (graph.Branches.Length < 1) Console.WriteLine("There are no branches left after deleting");
                    Console.WriteLine("branches:");
                    foreach (Branch branch in graph.Branches)
                    {
                        Console.WriteLine(branch);
                    }
                }
            }
            catch (BranchAlreadyAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}