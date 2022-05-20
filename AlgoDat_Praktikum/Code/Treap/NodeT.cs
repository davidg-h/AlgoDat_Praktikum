using AlgoDat_Praktikum.Code.Bin_SearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Treap
{
    public class NodeT : Node
    {
        public int Prio { get; set; }
        public NodeT (int value, NodeT left, NodeT right, NodeT parent, int prio) : base(value, left, right, parent)
        {
            Prio = prio;
        }
    }
}
