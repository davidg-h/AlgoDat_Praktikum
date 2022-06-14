using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;

namespace AlgoDat_Praktikum.Code.Array
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
                {   //                                                0  1  2  3  4
                    // Logik stimmt hier glaub ich nicht richtg weil: 1, 3, 4, 6, 8  -> l = 2 + 1 = 3 --> i = (3+4) / 2 = 3
                    // müsste glaub ich l = l + 1 sein
                    l = i + 1;
                }
                else
                {
                    // r = r - 1
                    r = i - 1;
                }
            } while (array[i] != element && l < r);

            if (array[i] == element)
            {
                SearchHelper = i; // das gesuchte element als index im array
                return true;
            }
            else
            {
                // neues element soll nach diesem index eingefügt werden
                // SearchHelper = i; Searchhelper so setzen dass das element welches eingefügt werden soll nach dem index i kommt
                return false;
            }
        }

        public bool delete(int element)
        {
            if (!search(element))
            {
                return false;
            }
            // hier dann nicht nochmal durch das array iterieren sondern mit dem Searchhelper(hat den index des zu löschenden elementes) arbeiten -> ganz äußere for schleife ist dann unnötig
            // heißt: alles was nach dem index kommt aufrücken: 1 3 4 6 8  (gelöscht wird 4 -> hat index 2) -> 1 3 6 8 (6 & 8 sind vorgerückt) 
            // wenn löschen erfolgreich dann true zurückgeben
            /* for (int i = 0; i < array.Length; i++)
             {
                 if (array[i] == element)
                 {
                     for (int y = i; y < array.Length - 1; y++)
                     {
            // nevermnind das aufrücken hast du schon xd
                         array[y] = array[y + 1];
                         array[y + 1] = 0;

                     }
                     return true;
                 }
             }*/
            return false;
        }

        public abstract bool insert(int element);
    }
}
