﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Bin_SearchTree
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }

        public int Value { get; set; }
        public int Prio { get; set; }
        public int Balance { get; set; }

        public Node(int value, Node left, Node right, Node parent, int prio = -1, int balance = 0)
        {
            Value = value;
            Left = left;
            Right = right;
            Parent = parent;
            Prio = prio;
            Balance = balance;
        }
    }
}
