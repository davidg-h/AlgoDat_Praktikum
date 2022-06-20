using System;
using System.Linq;
using AlgoDat_Praktikum.Code.AVLTree;
using AlgoDat_Praktikum.Code.Treap;
using AlgoDat_Praktikum.Code.Bin_SearchTree;
using AlgoDat_Praktikum.Code.Hash;
using AlgoDat_Praktikum.Code.LinkedList;
using AlgoDat_Praktikum.Code.Array_;

namespace AlgoDat_Praktikum
{
    class Program
    {
        static void Main(string[] args)
        {
            /*BinSearchTree b = new BinSearchTree();
            b.testBintree();*/

            /* Treap treap = new Treap();
             treap.testTreap();*/
            int arraySize = 0;

            Console.WriteLine("Wähle den abstrakten Datentypen aus:");
            Console.WriteLine("1. MultiSet unsorted");
            Console.WriteLine("2. Set unsorted");
            Console.WriteLine("3. MultiSet sorted");
            Console.WriteLine("4. Set sorted");

            string userInput = Console.ReadLine();

            Console.WriteLine("\nWähle den konkreten Datentyp aus");
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("a. MultiSetUnsorted Array");
                    Console.WriteLine("b. MultiSetUnsorted LinkedList");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "a":
                            Console.WriteLine("Wieviele Werte sollen gespeichert werden?");
                            arraySize = Convert.ToInt32(Console.ReadLine());
                            MultiSetUnsortedArray multiSetUnsortedArray = new MultiSetUnsortedArray(arraySize);
                            multiSetUnsortedArray.userHandling();
                            break;
                        case "b":
                            MultiSetUnsortedLinkedList multiSetUnsortedLinkedList = new MultiSetUnsortedLinkedList();
                            multiSetUnsortedLinkedList.MultiSetUnsortedHandler();
                            break;

                    }
                    break;

                case "2":
                    Console.WriteLine("\na. Hashtable with quadratic probing");
                    Console.WriteLine("b. Hashtable with seperate Chains");
                    Console.WriteLine("c. SetUnsorted Array");
                    Console.WriteLine("d. SetUnsorted LinkedList");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "a":
                            HashHandler.handleQuadProb();
                            break;
                        case "b":
                            HashHandler.handleSepChain();
                            break;
                        case "c":
                            Console.WriteLine("\nWie groß soll das Array sein?");
                            arraySize = Convert.ToInt32(Console.ReadLine());
                            SetUnsortedArray setUnsortedArray = new SetUnsortedArray(arraySize);
                            setUnsortedArray.userHandling();
                            break;
                        case "d":
                            SetUnsortedLinkedList setUnsortedLinkedList = new SetUnsortedLinkedList();
                            setUnsortedLinkedList.SetUnsortedHandler();
                            break;
                    }
                    break;

                case "3":
                    Console.WriteLine("\na. MultiSetSorted Array");
                    Console.WriteLine("b. MultiSetSorted LinkedList");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "a":
                            Console.WriteLine("\nWie groß soll das Array sein?");
                            arraySize = Convert.ToInt32(Console.ReadLine());
                            MultiSetSortedArray multiSetSortedArray = new MultiSetSortedArray(arraySize);
                            multiSetSortedArray.userHandling();
                            break;
                        case "b":
                            MultiSetSortedLinkedList multiSetSortedLinkedList = new MultiSetSortedLinkedList();
                            multiSetSortedLinkedList.MultiSetSortedHandler();
                            break;

                    }
                    break;

                case "4":
                    Console.WriteLine("\na. BinSearchTree");
                    Console.WriteLine("b. Treap");
                    Console.WriteLine("c. AVLTree");
                    Console.WriteLine("d. SetSorted Array");
                    Console.WriteLine("e. SetSorted LinkedList");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "a":
                            BinSearchTree bst = new BinSearchTree();
                            bst.userHandler();
                            break;
                        case "b":
                            Treap t = new Treap();
                            t.userHandler();
                            break;
                        case "c":
                            AVL avl = new AVL();
                            avl.userHandler();
                            break;
                        case "d":
                            Console.WriteLine("\nWie groß soll das Array sein?");
                            arraySize = Convert.ToInt32(Console.ReadLine());
                            SetSortedArray setSortedArray = new SetSortedArray(arraySize);
                            setSortedArray.userHandling();
                            break;
                        case "e":
                            SetSortedLinkedList setSortedLinkedList = new SetSortedLinkedList();
                            setSortedLinkedList.SetSortedHandler();
                            break;
                    }
                    break;
            }
        }
    }
}
