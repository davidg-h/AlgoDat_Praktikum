using System;
using AlgoDat_Praktikum.Code.Array;

namespace AlgoDat_Praktikum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wähle den abstrakten Datentypen aus:");
            Console.WriteLine("1. MultiSet unsorted");
            Console.WriteLine("2. Set unsorted");
            Console.WriteLine("3. MultiSet sorted");
            Console.WriteLine("4. Set sorted");

            string userInput = Console.ReadLine();

            Console.WriteLine("Wähle den konkreten Datentyp aus");
            switch (userInput)
            {
                case "1":
                    // TODO: let your class handle the console inputs and error handling (only not negative numbers)
                    // for more legible code in the main after user enters a concrete data type (s.r.: example)
                    Console.WriteLine("a. MultiSetUnsorted Array");
                    Console.WriteLine("c. MultiSetUnsorted LinkedList");
                    userInput = Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("a. Hashtable with quadratic probing"); 
                    Console.WriteLine("b. Hashtable with seperate Chains"); 
                    Console.WriteLine("c. SetUnsorted Array");
                    Console.WriteLine("d. SetUnsorted LinkedList");
                    userInput = Console.ReadLine();

                    switch(userInput){
                        case "a": 
                            HashHandler.handleQuadProb();
                            break;
                        case "b": 
                            HashHandler.handleSepChain();
                            break;
                    }
                    break;

                case "3":
                    Console.WriteLine("a. MultiSetSorted Array");
                    Console.WriteLine("b. MultiSetSorted LinkedList");
                    userInput = Console.ReadLine();
                    break;

                case "4":
                    Console.WriteLine("a. BinSearchTree");
                    Console.WriteLine("b. Treap");
                    Console.WriteLine("c. AVLTree");
                    Console.WriteLine("d. SetSorted Array");
                    Console.WriteLine("e. SetSorted LinkedList");
                    userInput = Console.ReadLine();
                    break;
            }
        }
    }
}
/*
 * example:
 * 
 * class MyClass {
 * 
 *  void userHandling() {
 *       Console.WriteLine("Sie haben array ausgewählt");
 *       Console.WriteLine("Max. Länge sind (zum Beispiel) 5 Zahlen");
 *       Console.WriteLine("1.einfügen");
 *       Console.WriteLine("2.Löschen");
 *       Console.WriteLine("...");
 *       ....
 *  }
 * }
 * 
 * only code in main should be: 
 * if (userInput == "a") {
 *  Myclass example = new MyClass();
 *  example.userHandling();
 * }
 */
