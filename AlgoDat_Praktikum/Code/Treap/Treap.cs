using AlgoDat_Praktikum.Code.Bin_SearchTree;
using System;
using System.Linq;

namespace AlgoDat_Praktikum.Code.Treap
{
    class Treap : BinSearchTree
    {
        public void userHandler()
        {
            do
            {
                Console.WriteLine("\n\nDu hast einen Treap ausgewählt!");
                Console.WriteLine("1.Suche eine Zahl");
                Console.WriteLine("2.Füge eine/mehrere Zahl/en hinzu");
                Console.WriteLine("3.Lösche eine Zahl");
                Console.WriteLine("4.Ausgabe des Treaps");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\nWelche Zahl möchstest du suchen?");
                        if (search(Convert.ToInt32(Console.ReadLine()))) { Console.WriteLine($"Deine Zahl wurde gefunden und kommt nach {SearchHelper.Parent.Value}\n\n"); print(); }
                        else { Console.WriteLine("Leerer Treap/Zahl nicht im Treap! Schaue nochmal die Ausgabe an\n\n"); print(); }
                        break;
                    case "2":
                        Console.WriteLine("\nFalls du mehrere Zahlen hinzufügen möchstest schreibe sie in diesem Format auf: 2,3,4,5,6,...");
                        var arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToInt32);
                        foreach (int elem in arr)
                        {
                            insert(elem);
                        }
                        Console.WriteLine("\nDein Treap:\n\n");
                        print();
                        break;
                    case "3":
                        Console.WriteLine("\nWelche Zahl möchstest du löschen?:");
                        if (delete(Convert.ToInt32(Console.ReadLine()))) { Console.WriteLine("Deine Zahl wurde gelöscht. Dein neuer Treap:\n\n"); print(); }
                        else { Console.WriteLine("Die Zahl gibt es nicht. Schaue am besten nochmal nach\n\n"); print(); }
                        break;
                    case "4":
                    default:
                        Console.WriteLine("\nAusgabe des Treaps:\n\n");
                        print();
                        break;
                }
                Console.WriteLine("\n\nDrücke Esc um zu beenden");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public void testTreap()
        {
            insert(45);
            insert(18);
            insert(10);
            insert(41);
            insert(43);
            insert(67);
            insert(56);
            insert(97);
            insert(95);
            insert(66);
            insert(59);
            insert(57);
            insert(64);
            //insert(45); // test gelicher knoten nochmal eingefügt
            print();

            if (search(64)) Console.WriteLine("64 da\n\n");
            else Console.WriteLine("64 nicht da");
            Console.WriteLine("------------------------------------------------------\n\n");

            if (delete(64)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");
            Console.WriteLine("------------------------------------------------------\n\n");
            insert(64);

            if (delete(41)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");
            Console.WriteLine("------------------------------------------------------\n\n");

            if (delete(97)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");
            Console.WriteLine("------------------------------------------------------\n\n");
            insert(41);
            insert(97);

            Console.WriteLine("Löschen 2 Nachfolger\n");
            if (delete(18)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");
            Console.WriteLine("------------------------------------------------------\n\n");

            if (delete(67)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");
            Console.WriteLine("------------------------------------------------------\n\n");

            Console.WriteLine("Löschen einer Zahl nicht im Baum:\n");
            if (delete(999)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");

            Console.WriteLine("3 einfügen");
            insert(3);
            print();
        }

        #region Public Methods
        public override bool insert(int elem)
        {
            bool sucessfullInsert = base.insert(elem);
            // after every insert treap should be sorted depending on its node prio
            sortTree(LastInsert);
            return sucessfullInsert;
        }
        /// <summary>
        /// rotate the node with the elem until it is a child node and deletes it
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public new bool delete(int elem)
        {
            if (search(elem))
            {
                Node n = SearchHelper;
                while (n.Left != null || n.Right != null)
                {
                    // 101 is an out of range prio for child nodes that are null
                    int prioLeft = n.Left != null ? n.Left.Prio : 101;
                    int prioRight = n.Right != null ? n.Right.Prio : 101;
                    if (prioRight < prioLeft)
                    {
                        leftRotOfNode(n.Right);
                    }
                    else
                    {
                        rightRotOfNode(n.Left);
                    }
                }
                // deletes the node
                _ = n.Parent.Value < n.Value ? n.Parent.Right = null : n.Parent.Left = null;
                return true;
            }
            return false;
        }

        public override void print()
        {
            printTreap(TreeRoot);
        }
        #endregion

        #region helper functions
        // after every node which is being added call sortTree on that node
        private void sortTree(Node n)
        {
            Node parent = n.Parent;
            while (parent != null && n.Prio < parent.Prio)
            {
                if (n.Value < parent.Value) rightRotOfNode(n);
                else leftRotOfNode(n);
                // new parent of n
                parent = n.Parent;
            }
        }
        /// <summary>
        /// right rotate of Node n
        /// </summary>
        /// <param name="n"></param>
        private void rightRotOfNode(Node n)
        {
            Node oldRightOf_n = n.Right;
            Node oldParentParentOf_n = n.Parent.Parent;
            n.Right = n.Parent;
            n.Right.Parent = n;
            n.Right.Left = oldRightOf_n;
            if (oldRightOf_n != null)
            {
                n.Right.Left.Parent = n.Right;
            }
            n.Parent = oldParentParentOf_n;
            if (n.Parent != null)
            {
                _ = n.Parent.Value < n.Value ? n.Parent.Right = n : n.Parent.Left = n;
            }
            else
            {
                TreeRoot = n;
            }
        }
        /// <summary>
        /// left rotate of Node n
        /// </summary>
        /// <param name="n"></param>
        private void leftRotOfNode(Node n)
        {
            Node oldLeftOf_n = n.Left;
            Node oldParentParentOf_n = n.Parent.Parent;
            n.Left = n.Parent;
            n.Left.Parent = n;
            n.Left.Right = oldLeftOf_n;
            if (oldLeftOf_n != null)
            {
                n.Left.Right.Parent = n.Left;
            }
            n.Parent = oldParentParentOf_n;
            if (n.Parent != null)
            {
                _ = n.Parent.Value < n.Value ? n.Parent.Right = n : n.Parent.Left = n;
            }
            else
            {
                TreeRoot = n;
            }
        }

        private void printTreap(Node n, int lvl = 0)
        {
            string tabs = "         ";
            if (n != null)
            {
                printTreap(n.Right, lvl + 1);
                // einrückungen für die ausgabe
                tabs = String.Concat(Enumerable.Repeat(tabs, lvl));
                if (lvl != 0)
                {
                    //Console.WriteLine(tabs + "height" + lvl + "\n");
                    Console.WriteLine(tabs + " ---- " + $" ({n.Value},{n.Prio})" + "\n");
                }
                else
                {
                    Console.WriteLine($"\n\n\n(r): ({n.Value},{n.Prio})\n\n\n");
                }
                printTreap(n.Left, lvl + 1);
            }
        }
        #endregion
    }
}
