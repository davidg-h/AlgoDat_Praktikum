using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;
using AlgoDat_Praktikum.Code.abstrDataType;


namespace AlgoDat_Praktikum.Code.LinkedList
{
    class MultiSetSortedLinkedList : List, IMultiSetSorted<int>
    {
        //hier dürfen gleiche elemente mehrmals vorkommen und müssen sortiert sein

        public (bool successfulInsert, int elemPos) SearchHelper { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool delete(int elem)
        {
            throw new NotImplementedException();
        }

        public bool insert(int elem)
        {
            throw new NotImplementedException();
        }

        public override void print()
        {
            throw new NotImplementedException();
        }

        public bool search(int elem)
        {
            throw new NotImplementedException();
        }
    }
}
