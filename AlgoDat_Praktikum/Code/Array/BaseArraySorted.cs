using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;

namespace AlgoDat_Praktikum.Code.Array_
{
    abstract class BaseArraySorted : BaseArray, IMultiSetSorted<int>
    {
        public int SearchHelper { get; set; }

        public BaseArraySorted(int size) : base(size)
        {

        }

        public bool search(int element)
        {
            int l, r, i;
            l = 0;
            r = array.Length - 1;

            do
            {
                i = (l + r) / 2;
                if (array[i] < element)
                {
                    l = i + 1;
                }
                else
                {
                    r = i - 1;
                }
            } while (array[i] != element && l <= r);

            if (array[i] == element)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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

        public abstract bool insert(int element);
    }
}
