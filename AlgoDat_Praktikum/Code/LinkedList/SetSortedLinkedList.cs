using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;
using AlgoDat_Praktikum.Code.abstrDataType;


namespace AlgoDat_Praktikum.Code.LinkedList
{
    class SetSortedLinkedList : MultiSetSortedLinkedList, ISetSorted<int>
    {
        //hier dürfen gleiche elemente NICHT mehrmals vorkommen und müssen sortiert sein

        public new bool search(int elem)
        {
            throw new NotImplementedException();
        }
    }
}
