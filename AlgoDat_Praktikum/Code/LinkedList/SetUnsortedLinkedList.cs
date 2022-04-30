using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.abstrDataType;
using AlgoDat_Praktikum.Code.Interfaces;



namespace AlgoDat_Praktikum.Code.LinkedList
{
    class SetUnsortedLinkedList : MultiSetUnsortedLinkedList, ISetUnsorted<int>
    {
        //hier dürfen gleiche elemente NICHT mehrmals vorkommen und müssen NICHT sortiert sein

        public new bool search(int elem)
        {
            throw new NotImplementedException();
        }
    }
}
