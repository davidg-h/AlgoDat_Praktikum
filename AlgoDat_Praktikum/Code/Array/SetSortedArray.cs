using AlgoDat_Praktikum.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Array
{
    class SetSortedArray : BaseArraySorted, ISetSorted<int>
    {
        public SetSortedArray(int size) : base(size) { }

        // !!!! hier jeder wert nur einmal wegen Set
        public override bool insert(int element)
        {
            if (element == 0) //0 nicht zugelassen
            {
                return false;
            }

            if (search(element)) //Wenn Element schon vorhanden, return false
            {
                return false;
            }

            //Prüfen ob Array Leer ist
            if (array[0] == 0)
            {
                array[0] = element;
                return true;
            }

            // Searchhelper (schon bei search gesetzt) dann danach einfügen (achte auf array größe beim einfügen vllt wäre ein bool für volles Array sinnvoll)
           /* for (int i = 0; i < array.Length; i++) // Einfügen des Elements
            {
                if (array[i] > element)//Wenn größeres Gefunden, alle Elemente ab dieser Stelle nach rechts schieben und anschließend Element hinzzfuegen
                {
                    for (int y = array.Length - 1; y >= i + 1; y--)
                    {
                        array[y] = array[y - 1];
                    }
                    array[i] = element;
                    return true;
                }
                else if (array[i] == 0)
                {
                    array[i] = element;
                    return true;
                }

            }*/

            return false;
        }

       /* public void print()
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
        }*/

        public override void userHandling()
        {
            throw new NotImplementedException();
        }
    }
}
