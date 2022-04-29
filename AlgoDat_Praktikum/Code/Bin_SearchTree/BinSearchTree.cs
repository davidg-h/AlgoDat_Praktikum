using AlgoDat_Praktikum.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Bin_SearchTree
{
    class BinSearchTree : ISetSorted<Node>
    {
        public virtual (bool successfulInsert, Node elemPos) SearchHelper { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool delete(int elem)
        {
            throw new NotImplementedException();
        }

        public bool insert(int elem)
        {
            throw new NotImplementedException();
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public bool search(int elem)
        {
            throw new NotImplementedException();
        }
    }

    class Node
    {
        Node parent, left, right;
        int value;
    }
}
