﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;
using AlgoDat_Praktikum.Code.abstrDataType;

namespace AlgoDat_Praktikum.Code.LinkedList
{
    class MultiSetUnsortedLinkedList : List, IMultiSetUnsorted<int>
    {
        //hier dürfen gleiche Elemente  mehrmals vorkommen und müssen NICHT sortiert sein

        public (bool successfulInsert, int elemPos) SearchHelper { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool checkMultiSet(int elem)
        {
            throw new NotImplementedException();
        }

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
