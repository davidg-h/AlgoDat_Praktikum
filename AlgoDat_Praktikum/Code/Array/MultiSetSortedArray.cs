﻿using AlgoDat_Praktikum.Code.Interfaces;
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
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] >= element)
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
                }
                Console.WriteLine("Das Array ist bereits voll.");
                return false;
            }

        }

        public override void userHandling()
        {
            do
            {
                Console.WriteLine("\n\nDu hast ein MultiSetSortedArray ausgewählt!");
                Console.WriteLine("1.Suche eine Zahl");
                Console.WriteLine("2.Füge eine Zahl hinzu");
                Console.WriteLine("3.Lösche eine Zahl");
                Console.WriteLine("4.Ausgabe des Arrays");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\nWelche Zahl möchstest du suchen?");
                        if (search(Convert.ToInt32(Console.ReadLine()))) { Console.WriteLine($"Deine Zahl wurde gefunden\n\n"); print(); }
                        else { Console.WriteLine("Leeres Array/Zahl nicht im Array! Schaue nochmal die Ausgabe an\n\n"); print(); }
                        break;
                    case "2":
                        Console.WriteLine("\nWelche Zahlen möchtest du hinzufügen?");
                        var arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToInt32);
                        foreach (int elem in arr)
                        {
                            insert(elem);
                        }
                        Console.WriteLine("\nDein Array:\n\n");
                        print();
                        break;
                    case "3":
                        Console.WriteLine("\nWelche Zahl möchstest du löschen?:");
                        if (delete(Convert.ToInt32(Console.ReadLine()))) { Console.WriteLine("Deine Zahl wurde gelöscht. Dein neues Array:\n\n"); print(); }
                        else { Console.WriteLine("Die Zahl gibt es nicht. Schaue am besten nochmal nach\n\n"); print(); }
                        break;
                    case "4":
                        Console.WriteLine("\nAusgabe des Arrays:\n\n");
                        print();
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe.");
                        break;
                }
                Console.WriteLine("\n\nDrücke Esc um zu beenden");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
