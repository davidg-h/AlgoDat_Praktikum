using System;

namespace AlgoDat_Praktikum.Code.Array
{
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
            catch 
            {
                Console.WriteLine("ungültige Eingabe");
            }


        }

        private void generateRandom()
        {
            Console.WriteLine("du willst also Zufällige Werte? Okay hier");
            Random r = new Random();
            for (int i = 0; i < hashtable.Size; i++)
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
            Console.WriteLine("Es wird per default die nächst größere Primzahl angenommen");
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
            for (int i = 0; i < 50; i++)
            {
                System.Threading.Thread.Sleep(20);
                Console.Write(".");
            }
            Console.WriteLine();
            Size = size;
            hashtable = new MyHashtable(size);
        }
    }
}
