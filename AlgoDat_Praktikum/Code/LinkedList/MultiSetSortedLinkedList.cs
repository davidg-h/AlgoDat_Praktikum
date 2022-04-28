using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;
using AlgoDat_Praktikum.Code.abstrDataType;


namespace AlgoDat_Praktikum.Code.LinkedList
{
    class MultiSetSortedLinkedList : Helper, IMultiSetSorted
    {
        //hier dürfen gleiche elemente mehrmals vorkommen und müssen sortiert sein
        public override bool delete(int elem)
        {
            throw new NotImplementedException();
        }

        public override bool insert(int elem)
        {
            throw new NotImplementedException();
        }

        public override void print()
        {
            throw new NotImplementedException();
        }

        public override (bool, int) _search(int elem)
        {
            throw new NotImplementedException();
        }
    }
}
