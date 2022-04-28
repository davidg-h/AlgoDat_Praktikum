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
                    Console.WriteLine("a. Hash"); // -> im handler noch Auswahl einteilen in SepChain oder QuadProp
                    Console.WriteLine("b. SetUnsorted Array");
                    Console.WriteLine("c. SetUnsorted LinkedList");
                    userInput = Console.ReadLine();
                    HashHandler hashHandler = new HashHandler();
                    hashHandler.handle();
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

    class HashHandler
    {

        MyHashtable hashtable;
        int Size;

        public HashHandler()
        {

        }
        public void handle()
        {
            initialize();
            Console.WriteLine("Du musst erst einmal Werte in deinen neuen coolen Hashtable einfügen...");
            Console.WriteLine("1. selber Werte einfügen");
            Console.WriteLine("2. Zufallswerte genenrieren");
            string input = Console.ReadLine();
            int selection;
            while (!Int32.TryParse(input, out selection))
            {
                Console.WriteLine("das ist leider keine Zahl :<");
                input = Console.ReadLine();
            }
            switch (selection)
            {
                case 1:
                    insertData();
                    break;
                case 2:
                    generateRandom();
                    break;
                default:
                    Console.WriteLine("Schlechte Eingabe");
                    break;
            }

            Console.WriteLine("So sieht dein Hashtable gerade aus:");
            hashtable.print();
            Console.ReadLine();
        }

        private void insertData()
        {
            Console.Clear();
            Console.WriteLine("Welche Werte willst du einfügen? (Schlüssel=Wert, Schlüssel2=Wert ...)");
            String input = Console.ReadLine();
            try
            {
                string[] arguments = input.Split(",");
                for (int i = 0; i < arguments.Length; i++)
                {
                    //TODO TryParse
                    int key = Int32.Parse(arguments[i].Split("=")[0]);
                    int value = Int32.Parse(arguments[i].Split("=")[1]);
                    hashtable.insert2(key, value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ungültige Eingabe");
            }


        }

        private void generateRandom()
        {
            Console.WriteLine("du willst also Zufällige Werte? Okay hier");
            Random r = new Random();
            for (int i = 0; i < Size; i++)
            {
                hashtable.insert2(r.Next(0, Size * 2), r.Next(0, Size * 2));
            }
            hashtable.print();
        }

        public void initialize()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Herzlichen Glückwunsch, sie haben den Hashtable ausgewählt");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Wie groß soll dein Hashtable sein?");
            string input = Console.ReadLine();
            int size;
            while (!Int32.TryParse(input, out size))
            {
                Console.WriteLine("das ist leider keine Zahl :<");
                Console.WriteLine("Wie groß soll dein Hashtable sein?");
                input = Console.ReadLine();
            }
            Console.WriteLine("Alles Klar, dann generiere ich jetzt einen Hashtable für dich");
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(100);
                Console.Write(".");
            }
            Console.WriteLine();
            Size = size;
            hashtable = new MyHashtable(size);
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
