﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;



namespace AlgoDat_Praktikum.Code.LinkedList
{
    class SetUnsortedLinkedList : MultiSetUnsortedLinkedList, ISetUnsorted<Node>
    {
        //hier dürfen gleiche elemente NICHT mehrmals vorkommen und müssen NICHT sortiert sein
        public void SetUnsortedHandler()
        {
            sorted = true;

            do
            {
                Console.WriteLine("\n\nDu hast eine unsortierte verkettete Liste ausgewählt!");
                Console.WriteLine("1.Suche eine Zahl");
                Console.WriteLine("2.Füge eine/mehrere Zahl/en hinzu");
                Console.WriteLine("3.Lösche eine Zahl");
                Console.WriteLine("4.Ausgabe des Treaps");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\nWelche Zahl möchstest du suchen?");
                        if (search(Convert.ToInt32(Console.ReadLine()))) { Console.WriteLine($"Deine Zahl wurde gefunden und kommt nach {SearchHelper.data}\n\n"); print(); }
                        else { Console.WriteLine("Leere Liste/Zahl nicht in der Liste! Schaue nochmal die Ausgabe an\n\n"); print(); }
                        break;
                    case "2":
                        Console.WriteLine("\nFalls du mehrere Zahlen hinzufügen möchstest schreibe sie in diesem Format auf: 2,3,4,5,6,...");
                        var arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToInt32);
                        Console.WriteLine("Mehrfach eingefügte Zahlen werden nur einmal ausgegeben.");
                        foreach (int elem in arr)
                        {
                            insert(elem);
                        }
                        Console.WriteLine("\nDeine Liste:\n\n");
                        print();
                        break;
                    case "3":
                        Console.WriteLine("\nWelche Zahl möchstest du löschen?:");
                        if (delete(Convert.ToInt32(Console.ReadLine()))) { Console.WriteLine("Deine Zahl wurde gelöscht. Deine neue Liste:\n\n"); print(); }
                        else { Console.WriteLine("Die Zahl gibt es nicht. Schaue am besten nochmal nach\n\n"); print(); }
                        break;
                    case "4":
                    default:
                        Console.WriteLine("\nAusgabe der Liste:\n\n");
                        print();
                        break;
                }
                Console.WriteLine("\n\nDrücke Esc um zu beenden");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        public bool insert(int data)
        {
            Node newElement = new Node(data);
            bool found = search(data);

            //list empty, create head 
            if (head == null)
            {
                head = newElement;
                return true;
            }
            //else run through list
            else if (!found)
            {
                Node iterator = head;
                while (iterator.next != null)
                {
                    iterator = iterator.next;
                }
                //add new element to end of list
                iterator.next = newElement;
                return true;
            }
            return false;
        }
    }
}
