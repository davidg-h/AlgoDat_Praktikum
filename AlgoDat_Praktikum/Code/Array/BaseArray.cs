using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Array_
{
    abstract class BaseArray
    {
        public int[] array;

        public BaseArray(int size)
        {
            this.array = new int[size];
        }

        public void print()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    Console.Write("[ ]" + " ");
                }
                else
                {
                    Console.Write("[" + array[i] + "]" + " ");
                }

            }
        }

        public abstract void userHandling();
    }
}
