using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using Microsoft.SqlServer.Server;

namespace Task8
{
    public class Graph
    {
        public List<Node> Nodes = new List<Node>();
        public List<Branch> Branches = new List<Branch>();

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public void AddBranch(Branch branch)
        {
            Branches.Add(branch);
        }

        public void ProcessIncedentNodes()
        {
            foreach (Node node in Nodes)
            {
                foreach (Branch branch in Branches)
                {
                    if (branch.Node1 == node && !node.IncedentNodes.Contains(branch.Node2)) node.AddIncedentNode(branch.Node2);
                    if (branch.Node2 == node && !node.IncedentNodes.Contains(branch.Node1)) node.AddIncedentNode(branch.Node1);
                }
            }
        }

        public string GetAllNodes()
        {
            string output = "";
            foreach (Node node in Nodes)
            {
                output += node + "\n";
            }

            return output;
        }
        
        public string GetAllBranches()
        {
            string output = "";
            foreach (Branch branch in Branches)
            {
                output += branch + "\n";
            }

            return output;
        }
        
        public void AssignNumbersToNodes(int num)
        {
            var temp = num.ToString();
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].NodeNum = temp[i] - '0';
            }
        }

        public static int Isomeric(Graph a, Graph b)
        {
            NumGenerator numGenerator = new NumGenerator(a.Nodes.Count);
            a.AssignNumbersToNodes(int.Parse(new string(numGenerator.Digits.ToArray())));

            foreach (int numGeneratorNum in numGenerator.Nums)
            {
                b.AssignNumbersToNodes(numGeneratorNum);
                if (TryIsomeric(a, b)) return numGeneratorNum;
            }

            return 0;
        }

        private static bool TryIsomeric(Graph a, Graph b)
        {
            foreach (Node aNode in a.Nodes)
            {
                foreach (Node bNode in b.Nodes)
                {
                    if (bNode.NodeNum == aNode.NodeNum)
                    {
                        List<int> aNodeInc = new List<int>();
                        List<int> bNodeInc = new List<int>();
                        foreach (Node aNodeIncedentNode in aNode.IncedentNodes)
                        {
                            aNodeInc.Add(aNodeIncedentNode.NodeNum);
                        }
                        foreach (Node bNodeIncedentNode in bNode.IncedentNodes)
                        {
                            bNodeInc.Add(bNodeIncedentNode.NodeNum);
                        }
                        aNodeInc.Sort();
                        bNodeInc.Sort();
                        if (aNodeInc.Count == bNodeInc.Count)
                        {
                            for (int i = 0; i < aNodeInc.Count; i++)
                            {
                                if (aNodeInc[i] != bNodeInc[i]) return false;
                            }

                        }
                        else return false;

                    }
                }
            }
            return true;
        }
    }

    public class Node
    {
        public string Name { get; }
        public string Value { get; }
        public List<Node> IncedentNodes = new List<Node>();
        public int NodeNum;
        
        public Node(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Node(string name)
        {
            Name = name;
            Value = "";
        }

        public void AddIncedentNode(Node node)
        {
            IncedentNodes.Add(node);
        }
        
        public string GetAllIncedentNodesNames()
        {
            string output = "";
            foreach (Node incedentNode in IncedentNodes)
            {
                output += incedentNode.Name + ", ";
            }

            return output;
        }

        

        public override string ToString()
        {
            return $"Node {Name}, incedent nodes - {GetAllIncedentNodesNames()}";}
        }
    

    public class Branch
    {
        public Node Node1 { get; }
        public Node Node2 { get; }

        public Branch(Node node1, Node node2)
        {
            Node1 = node1;
            Node2 = node2;
        }

        public override string ToString()
        {
            return $"Branch between {Node1} and {Node2}";
        }
    }

    public class NumGenerator
    {
        private int _length;
        public List<char> Digits = new List<char>();
        public List<int> Nums = new List<int>();

        public NumGenerator(int length)
        {
            _length = length;
            GenerateDigits();
            GenerateNumbers();
        }


        private void GenerateDigits()
        {
            for (int i = 1; i <= _length; i++) Digits.Add(Convert.ToChar(i.ToString()));
        }
        private List<int> GenerateNums()
        {
            return Enumerable.Range((int)Math.Pow(10, _length-1), (int)Math.Pow(10, _length) - 1 -(int)Math.Pow(10, _length-1) ).Where(
                    x => x.ToString().ToCharArray().Distinct().Count() == x.ToString().Length )
                .ToList();
           
        }

        private void GenerateNumbers()
        {
            var tempList = GenerateNums();
            tempList.RemoveAll(ToRemove);
            Nums = tempList;
        }

        private bool ToRemove(int num)
        {
            var temp = num.ToString().ToCharArray();
            foreach (char c in temp)
            {
                if (!Digits.Contains(c)) return true;
            }

            return false;
        }
        
        
        
    }
}