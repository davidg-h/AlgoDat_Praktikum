using AlgoDat_Praktikum.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Array
{
    class SetUnsortedArray : BaseArrayUnsorted, ISetUnsorted<int>
    {
        public SetUnsortedArray(int size) : base(size) { }

        // !!!! hier jeder wert nur einmal wegen Set
        public override bool insert(int element)
        {
            if (element == 0) // 0 nicht zulässig
            {
                return false;
            }
            if (search(element)) // Falls Element schon vorhanden ist, return false
            {
                return false;
            }

            //Prüfen ob Array leer ist
            if (array[0] == 0)
            {
                array[0] = element;
                return true;
            }

            // hier SearchHelper soll letzter index sein (wurde in search gesetzt), wo eingefügt wurde und dann den i + 1 index nehmen

            //Einfügen des Elements
           /* for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
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
