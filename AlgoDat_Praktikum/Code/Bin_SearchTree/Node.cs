using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Bin_SearchTree
{
    public class Node
    {
        //public Node parentNode { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }

        public int Value { get; set; }

        public Node(int value, Node left, Node right, Node parent)
        {
            Value = value;
            Left = left;
            Right = right;
            Parent = parent;
        }
    }
}
