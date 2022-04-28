using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.abstrDataType;
using AlgoDat_Praktikum.Code.Interfaces;



namespace AlgoDat_Praktikum.Code.LinkedList
{
    class SetUnsortedLinkedList : Helper, ISetUnsorted
    {
        //hier dürfen gleiche elemente NICHT mehrmals vorkommen und müssen NICHT sortiert sein
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
