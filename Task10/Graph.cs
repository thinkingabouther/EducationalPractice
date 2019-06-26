using System;
using System.Linq;

namespace Task10
{
    public class Graph
    {
        public CustomList<Node> Nodes = new CustomList<Node>();
        public CustomList<Branch> Branches = new CustomList<Branch>();


        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public void AddBranch(Node node1, Node node2)
        {
            var branch = new Branch(node1, node2);
            if (Branches.Length == 0)
            {
                Branches.Add(new Branch(node1, node2));
            }
            else
            {
                if (!Branches.Contains(branch))
                {
                    Branches.Add(new Branch(node1, node2));
                }
                else throw new BranchAlreadyAddedException();
            }
        }
        
        public void AddBranch(int i1, int i2)
        {
            AddBranch(Nodes[i1], Nodes[i2]);
        }


        public void DeleteNodesWithValue(int value)
        {
            var tempNodes = new CustomList<Node>();
            for (int i = 0; i < Nodes.Length; i++)
            {
                if (Nodes[i].Value != value)
                {
                    tempNodes.Add((Node) Nodes[i].Clone());
                }
            }

            Nodes = tempNodes;
            var tempBranches = new CustomList<Branch>();
            foreach (Branch branch in Branches)
            {
                if (Nodes.Contains(branch.Node1) & Nodes.Contains(branch.Node2))
                {
                    tempBranches.Add((Branch) branch.Clone());
                }
            }

            Branches = tempBranches;

        }

    }

    public class Node : ICloneable, IMember<Node>
    {
        public string Name { get; }
        public int Value { get; set; }
        private Node _nextMember;

        public Node(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public Node(string name)
        {
            Name = name;
            Value = 0;
        }
        

        public override string ToString()
        {
            return $"Node {Name}";}

        public object Clone()
        {
            return new Node(Name, Value);
        }


        public Node NextMember
        {
            get => _nextMember;
            set => _nextMember = value;
        }

        public override bool Equals(object obj)
        {
            var temp = (Node) obj;
            return temp != null && temp.Name == this.Name;
        }
    }
    

    public class Branch : ICloneable, IMember<Branch>
    {
        private Branch _nextMember;
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

        public object Clone()
        {
            return new Branch(Node1, Node2);
        }

        public override bool Equals(object obj)
        {
            var branch = (Branch) obj;
            return (this.Node1 == branch.Node1 && this.Node2 == branch.Node2 ||
                    this.Node2 == branch.Node1 && this.Node1 == branch.Node2);
        }

        public Branch NextMember
        {
            get => _nextMember;
            set => _nextMember = value;
        }
        
        
    }
    public class BranchAlreadyAddedException : Exception
    {
        
    }
}