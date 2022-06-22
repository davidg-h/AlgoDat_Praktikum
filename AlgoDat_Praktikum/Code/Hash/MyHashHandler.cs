using AlgoDat_Praktikum.Code.Interfaces;
using System;

namespace AlgoDat_Praktikum.Code.Hash
{
    public static class HashHandler
    {
        static ISetUnsorted<int> hashtable;
        static int Size;

        public static void handleQuadProb()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Herzlichen Glückwunsch, sie haben den Hashtable ausgewählt");
            Console.WriteLine("Die verwendete Hashmethode ist eine Modulooperation");
            Console.WriteLine("Bei kollisionen wird eine Sondierung vorgenommen");
            Console.WriteLine("----------------------------------------------------------");
            Initialize();
            hashtable = new HashTabQuadProb(Size);
            fillWithData();
            while(true)
                handleInput();
        }

        public static void handleSepChain()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Herzlichen Glückwunsch, sie haben den Hashtable ausgewählt");
            Console.WriteLine("Die verwendete Hashmethode ist eine Modulooperation");
            Console.WriteLine("Bei Kollisionen wird eine Sub-Liste erstellt");
            Console.WriteLine("----------------------------------------------------------");
            Initialize();
            hashtable = new HashTabSepChain(Size);
            fillWithData();
            while(true)
                handleInput();
        }

        static void handleInput()
        {
            Console.Clear();
            Console.WriteLine("Was willst du nun machen?");
            Console.WriteLine("1. Daten einfügen");
            Console.WriteLine("2. Daten löschen");
            Console.WriteLine("3. Daten suchen");
            Console.WriteLine("4. Daten anzeigen");
            ConsoleKeyInfo input = Console.ReadKey();
            int selection = ConvertInputToSelection(input);
            switch (selection)
            {
                case 1:
                    insertData();
                    break;
                case 2:
                    deleteData();
                    break;
                case 3:
                    searchData();
                    break;
                case 4:
                    printData();
                    break;
                default:
                    Console.WriteLine("Schlechte Eingabe");
                    break;
            }
        }

        private static void printData()
        {
            Console.Clear();
            Console.WriteLine("So Sieht dein Hashtable gerade aus:");
            hashtable.print();
            Console.ReadLine();
        }

        private static void searchData()
        {
            Console.Clear();
            Console.WriteLine("nach welchem Wert willst du suchen?");
            string input = Console.ReadLine();
            int selection = ConvertInputToInt(input);
            if (hashtable.search(selection))
            {
                Console.WriteLine("Der Wert existiert in deinem Hashtable an der Stelle " + hashtable.SearchHelper);
            }
            else
            {
                Console.WriteLine("Der Wert existiert leider NICHT in deinem Hashtable");
            }
            Console.ReadLine();
        }

        private static void deleteData()
        {
            Console.Clear();
            Console.WriteLine("Welchen Wert willst du löschen?");
            string input = Console.ReadLine();
            int selection = ConvertInputToInt(input);
            if (hashtable.delete(selection))
            {
                Console.WriteLine("der Wert wurde erfolgreich gelöscht");
            }
            else
            {
                Console.WriteLine("Der angegebene Wert konnte leider NICHT gelöscht werden, da er nicht gefunden wurde...");
            }
        }

        static void fillWithData()
        {
            Console.Clear();
            Console.WriteLine("Du musst erst einmal Werte in deinen neuen coolen Hashtable einfügen...");
            Console.WriteLine("1. selber Werte einfügen");
            Console.WriteLine("2. Zufallswerte genenrieren");
            string input = Console.ReadLine();
            int selection = ConvertInputToInt(input);
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

        static void insertData()
        {
            Console.Clear();
            Console.WriteLine("Welche Werte willst du einfügen? (Wert1, Wert2 ...)");
            String input = Console.ReadLine();
            try
            {
                string[] arguments = input.Split(",");
                for (int i = 0; i < arguments.Length; i++)
                {
                    //TODO TryParse
                    int key = Int32.Parse(arguments[i]);
                    hashtable.insert(key);
                }
            }
            catch 
            {
                Console.WriteLine("ungültige Eingabe");
            }
        }

        static void generateRandom()
        {
            Console.Clear();
            Console.WriteLine("du willst also Zufällige Werte? Okay hier");
            Random r = new Random();
            for (int i = 0; i < Size; i++)
            {
                hashtable.insert(r.Next(0, Size * 10));
            }
        }

        static void Initialize()
        {
            Console.WriteLine();
            Console.WriteLine("Wie groß soll dein Hashtable sein?");
            Console.WriteLine("Es wird per default die nächst größere Primzahl angenommen");
            string input = Console.ReadLine();
            int size;
            while (!Int32.TryParse(input, out size))
            {
                Console.WriteLine("das ist leider keine Zahl :<");
                Console.WriteLine("Wie groß soll dein Hashtable sein?");
                input = Console.ReadLine();
            }

            Size = findNextPrime(size);
            Console.Clear();
            Console.WriteLine("Die nächst größere Primzahl ist " + Size);
            Console.WriteLine("Alles Klar, dann generiere ich jetzt einen Hashtable für dich");
            Console.WriteLine();
            for (int i = 0; i < 80; i++)
            {
                System.Threading.Thread.Sleep(40);
                Console.Write(".");
            }
            Console.WriteLine();
        }

        static int ConvertInputToSelection(ConsoleKeyInfo input)
        {
            int selection;
            while (!Int32.TryParse(input.KeyChar.ToString(), out selection))
            {
                if (input.Key == ConsoleKey.Escape)
                {
                    System.Environment.Exit(-1);
                }
                Console.WriteLine("das ist leider keine Zahl :<");
                input = Console.ReadKey();
                
            }
            return selection;
        }

        static int ConvertInputToInt(string input)
        {
            int selection;
            while (!Int32.TryParse(input, out selection))
            {
                Console.WriteLine("das ist leider keine Zahl :<");
                input = Console.ReadLine();
            }
            return selection;
        }

        static int findNextPrime(int number)
        {
            bool isPrime = false;
            int counter = number - (number) % 4 + 3;
            while (!isPrime)
            {
                isPrime = true;
                for (int i = 2; i < counter / 2; i++)
                {
                    if (counter % i == 0)
                    {
                        isPrime = false;
                        counter += 4;
                        break;
                    }
                }
            }
            return counter;
        }
    }
}
