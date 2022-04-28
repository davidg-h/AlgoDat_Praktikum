using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;
using AlgoDat_Praktikum.Code.abstrDataType;

namespace AlgoDat_Praktikum.Code.LinkedList
{
    class MultiSetIUnsortedLinkedList : Helper, IMultiSetUnsorted
    {
        //hier dürfen gleiche Elemente  mehrmals vorkommen und müssen NICHT sortiert sein
        public bool checkMultiSet(int elem)
        {
            throw new NotImplementedException();
        }

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
