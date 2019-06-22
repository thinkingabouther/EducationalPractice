using System;

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
            if (!Branches.Contains(branch))
            {
                Branches.Add(new Branch(node1, node2));
            }
            else throw new BranchAlreadyAddedException();
            ProcessIncedentNodes();
        }
        
        public void AddBranch(int i1, int i2)
        {
            AddBranch(Nodes[i1], Nodes[i2]);
        }
        
        
        public void DeleteNodesWithValue(int value)
        {
            var tempNodes = new CustomList<Node>();
            var NodesToDelete = new CustomList<Node>();
            for (int i = 0; i < Nodes.Length; i++)
            {
                if (Nodes[i].Value != value)
                {
                    Node tempNode = (Node)Nodes[i].Clone();
                    tempNode.NextMember = null;
                    tempNodes.Add(tempNode);
                }
                else
                {
                    NodesToDelete.Add(Nodes[i]);
                }
            }
            Nodes = tempNodes;
            var tempBranches = new CustomList<Branch>();
            foreach (Branch branch in Branches)
            {
                if (!NodesToDelete.Contains(branch.Node1) || NodesToDelete.Contains(branch.Node2))
                {
                    tempBranches.Add(branch);
                }
            }

            Branches = tempBranches;
            foreach (Node node in Nodes)
            {
                node.IncedentNodes = new CustomList<Node>();
            }

            ProcessIncedentNodes();

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
                output += $"node {node.Name} with value {node.Value}\n";
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
        
    }

    public class Node : ICloneable, IMember<Node>
    {
        public string Name { get; }
        public int Value { get; set; }
        public CustomList<Node> IncedentNodes = new CustomList<Node>();
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
            return $"Node {Name}";}

        public object Clone()
        {
            var tempNode = new Node($"{Name}");
            tempNode.Value = Value;
            tempNode.NextMember = NextMember;
            return tempNode;
        }

        public Node NextMember
        {
            get => _nextMember;
            set => _nextMember = value;
        }
    }
    

    public class Branch : IMember<Branch>
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