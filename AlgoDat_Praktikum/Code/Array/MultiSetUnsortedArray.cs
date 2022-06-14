using AlgoDat_Praktikum.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Array_
{
    class MultiSetUnsortedArray : BaseArrayUnsorted, IMultiSetUnsorted<int>
    {
        public MultiSetUnsortedArray(int size) : base(size) { }

        // !!!! hier kann da MultiSet gleicher Wert mehrfach dran kommen
        public override bool insert(int element)
        {
            if (element == 0) //0 nicht zugelassen
            {
                return false;
            }
            if (array[0] == 0)//Prüfen ob array leer ist, falls ja, ganz vorne einfügen
            {
                array[0] = element;
                return true;
            }

            // hier wird ja immer am Ende eingefügt wenn noch platz ist -> letzten index mit einer Zahl drinnen herausfinden bei search und da dann damit arbeiten
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

        // wurde schon in BaseArray implementiert
        /*public void print()
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
