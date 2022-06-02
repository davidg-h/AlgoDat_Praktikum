using System;
using System.Linq;
using AlgoDat_Praktikum.Code.Treap;
using AlgoDat_Praktikum.Code.Bin_SearchTree;
using AlgoDat_Praktikum.Code.Hash;
using AlgoDat_Praktikum.Code.LinkedList;

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
                    // TODO: let your class handle the console inputs and error handling (only not negative numbers)
                    // for more legible code in the main after user enters a concrete data type (s.r.: example)
                    Console.WriteLine("a. MultiSetUnsorted Array");
                    Console.WriteLine("b. MultiSetUnsorted LinkedList");
                    userInput = Console.ReadLine();
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
                    }
                    break;

                case "3":
                    Console.WriteLine("\na. MultiSetSorted Array");
                    Console.WriteLine("b. MultiSetSorted LinkedList");
                    userInput = Console.ReadLine();
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
                            break;
                        case "d":
                            break;
                        case "e":
                            break;
                    }
                    break;
            }
        }
    }
}
