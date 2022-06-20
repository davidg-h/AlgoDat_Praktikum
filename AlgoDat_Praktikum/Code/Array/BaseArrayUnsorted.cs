using AlgoDat_Praktikum.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Array_
{
    abstract class BaseArrayUnsorted : BaseArray, IMultiSetUnsorted<int>
    {
        public int SearchHelper { get; set; }

        public BaseArrayUnsorted(int size) : base(size)
        {

        }
        public bool search(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return true;
                }
            }
            return false;
        }

        abstract public bool insert(int element);

        public bool delete(int element)
        {
            if (!search(element))
            {
                return false;
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    if (i == array.Length - 1)
                    {
                        array[i] = 0;
                    }
                    for (int y = i; y < array.Length - 1; y++)
                    {
                        array[y] = array[y + 1];
                        array[y + 1] = 0;

                    }
                    return true;
                }
            }
            return false;
        }
    }
}
