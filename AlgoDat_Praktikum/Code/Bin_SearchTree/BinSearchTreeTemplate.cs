using AlgoDat_Praktikum.Code.Interfaces;
using AlgoDat_Praktikum.Code.BinSearchTree;
using System;


namespace AlgoDat_Praktikum.Code.Bin_SearchTree
{
    class BinSearchTreeTemplate : ISetSorted<Node>
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

    // Deprecated (siehe Node.cs)
    /*   class Node
       {
           Node parent, left, right;
           int value;
       }*/
}
