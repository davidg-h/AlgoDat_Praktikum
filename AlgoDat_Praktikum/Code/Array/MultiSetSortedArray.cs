using AlgoDat_Praktikum.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.Array_
{
    class MultiSetSortedArray : BaseArraySorted, IMultiSetSorted<int>
    {
        public MultiSetSortedArray(int size) : base(size) { }

        // !!!! hier kann da MultiSet gleicher Wert mehrfach dran kommen
        public override bool insert(int element)
        {
            //0 nicht zugelassen
            if (element == 0)
            {
                return false;
            }
            //Prüfen ob Array Leer ist, falls ja ganz vorne einfügen//
            if (array[0] == 0)
            {
                array[0] = element;
                return true;
            }

            // hier nicht das Array durchgehen, sondern den search aufrufen, wo dann der SearchHelper gesetzt wird und damit arbeiten

            //Array Durchlaufen und prüfen ob größerer oder gleicher Wert vorhanden
           /* for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= element)//Wenn Gefunden, alle Elemente ab dieser Stelle nach rechts schieben und anschließend Element hinzzfuegen
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

        // print wurde schon in der BaseArray geschrieben, außer du willst was anderes ausgeben
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

        // muss noch implementiert werden (als Beispiel siehe Treap.userHandling())
        public override void userHandling()
        {
            throw new NotImplementedException();
        }
    }
}
