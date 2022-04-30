using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.BinSearchTree
{
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }

        public int NodeValue { get; set; }

        
    }
    public static Node(int elem)
    {
        Node node = new Node();
        node.NodeValue = elem;
        node.LeftNode = null;
        node.RightNode = null;
        return node; 

    }
}
