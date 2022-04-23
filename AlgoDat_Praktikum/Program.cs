using System;

namespace AlgoDat_Praktikum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wähle den abstrakten Datentypen aus:");
            Console.WriteLine("1.Stack");
            Console.WriteLine("2.Queue");
            Console.WriteLine("...");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    // TODO: let your class handle the console inputs and error handling (only not negative numbers)
                    // for more legible code in the main after user enters a concrete data type (s.r.: example)
                    Console.WriteLine("Wähle den konkreten Datentyp aus");
                    Console.WriteLine("a (Array)");
                    Console.WriteLine("l (Liste)");
                    Console.WriteLine("...");
                    userInput = Console.ReadLine();
                    break;
                case "2":
                    // TODO: do the same as in case 1
                    break;
                case "...":
                    // TODO: add other cases
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
