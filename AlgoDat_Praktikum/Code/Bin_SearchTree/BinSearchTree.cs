using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;


namespace AlgoDat_Praktikum.Code.Bin_SearchTree
{
    class BinSearchTree : ISetSorted<Node>
    {
        //Properties:
        public Node SearchHelper { get; set; }
        public Node TreeRoot { get; set; }
        internal Node LastInsert { get; set; }

        public void userHandler()
        {
            do
            {
                Console.WriteLine("\n\nDu hast einen BinarySearchTree ausgewählt!");
                Console.WriteLine("1.Suche eine Zahl");
                Console.WriteLine("2.Füge eine/mehrere Zahl/en hinzu");
                Console.WriteLine("3.Lösche eine Zahl");
                Console.WriteLine("4.Ausgabe des BinarySearchTrees");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\nWelche Zahl möchstest du suchen?");
                        if (search(Convert.ToInt32(Console.ReadLine()))) { Console.WriteLine($"Deine Zahl wurde gefunden und kommt nach {SearchHelper.Parent.Value}\n\n"); print(); }
                        else { Console.WriteLine("Leerer BinarySearchTree/Zahl nicht im BinarySearchTree! Schaue nochmal die Ausgabe an\n\n"); print(); }
                        break;
                    case "2":
                        Console.WriteLine("\nFalls du mehrere Zahlen hinzufügen möchstest schreibe sie in diesem Format auf: 2,3,4,5,6,...");
                        var arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToInt32);
                        foreach (int elem in arr)
                        {
                            insert(elem);
                        }
                        Console.WriteLine("\nDein BinarySearchTree:\n\n");
                        print();
                        break;
                    case "3":
                        Console.WriteLine("\nWelche Zahl möchstest du löschen?:");
                        if (delete(Convert.ToInt32(Console.ReadLine()))) { Console.WriteLine("Deine Zahl wurde gelöscht. Dein neuer BinarySearchTree:\n\n"); print(); }
                        else { Console.WriteLine("Die Zahl gibt es nicht. Schaue am besten nochmal nach\n\n"); print(); }
                        break;
                    case "4":
                    default:
                        Console.WriteLine("\nAusgabe des BinarySearchTree:\n\n");
                        print();
                        break;
                }
                Console.WriteLine("\n\nDrücke Esc um zu beenden");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        #region PublicFunctions
        public virtual bool insert(int elem)
        {


            Node nodeToInsert = new Node(elem, null, null, null, new Random().Next(101));
            if (TreeRoot == null) // TreeRoot is null
            {
                TreeRoot = nodeToInsert; //Given value is new root
                LastInsert = TreeRoot;
                return true;
            }
            //Insertion of new leaf
            if (!search(elem))
            {
                if (SearchHelper.Value < elem)
                {
                    SearchHelper.Right = nodeToInsert;
                    nodeToInsert.Parent = SearchHelper;
                    LastInsert = nodeToInsert;
                    return true;
                }
                else if (SearchHelper.Value > elem)
                {
                    SearchHelper.Left = nodeToInsert;
                    nodeToInsert.Parent = SearchHelper;
                    LastInsert = nodeToInsert;
                    return true;
                }
            }
            // hier wollte der fuhr das mit dem suchen haben wo die position geben wird falls der knoten nicht vorhanden ist -> damit nur einmal gesucht wird
            // Value must already be in tree 
            Console.WriteLine("Zahl schon vorhanden");
            return false;
        }
        // bei löschen muss auch zunächst gesucht werden hier wird das property searchHelper nützlich sein laut fuhr gleiches prinzip beim insert
        public bool delete(int elem)
        {
            Node temp_b = null;
            Node temp_c = null;
            if (search(elem) == true)
            {
                // löschen eines blattes
                if (SearchHelper.Left == null && SearchHelper.Right == null)
                {
                    _ = SearchHelper.Value > SearchHelper.Parent.Value ? SearchHelper.Parent.Right = null : SearchHelper.Parent.Left = null;
                }
                //Löschen mit Kind Rechts
                else if (SearchHelper.Left == null)
                {
                    SearchHelper.Value = SearchHelper.Right.Value;
                    SearchHelper.Right = null;
                    //Löschen mit Kind Links
                }
                else if (SearchHelper.Right == null)
                {
                    SearchHelper.Value = SearchHelper.Left.Value;
                    SearchHelper.Left = null;
                }
                //löschen mit mehreren Kindern 
                else if (SearchHelper.Left != null && SearchHelper.Right != null)
                {
                    temp_b = SearchHelper;
                    if (temp_b.Left.Right != null) //Bedingung dafür dass im Baum ein größerer Wert Vorhanden ist der verschoben werden muss
                    {
                        temp_b = temp_b.Left;
                        while (temp_b.Right.Right != null)//Annähern an den größtmöglichen Nachfolger der zu löschenden Zahl
                        {
                            temp_b = temp_b.Right;
                        }
                    }
                    if (temp_b == SearchHelper)//Hochbewegen des linken Teilbaums
                    {
                        temp_c = temp_b.Left;
                        temp_b.Left = temp_c.Left;
                    }
                    else //Hochbewegen des rechten Teilbaums
                    {
                        temp_c = temp_b.Right;
                        temp_b.Right = temp_c.Left;
                    }
                    SearchHelper.Value = temp_c.Value;
                }

                return true;
            }
            else
            {
                Console.WriteLine("Zahl nicht vorhanden, kann nicht gelöscht werden.");
                return false;
            }
        }
        public bool search(int elem)
        {
            if (TreeRoot == null)
            {
                return false;//Keine Elemente im Baum -> Wert kann nicht vorkommen 
            }
            return binarySearch(TreeRoot, elem);
        }

        public virtual void print()
        {
            printTree(TreeRoot);
        }

        #endregion

        #region HelperFunctions

        //Hilfsfunktion für rekursivenaufruf
        bool binarySearch(Node nodeUnderScope, int elem)
        {
            if (nodeUnderScope.Value == elem)
            {
                SearchHelper = nodeUnderScope; //wenn gefunden gebe den Knoten zurück
                return true; //Momentane Node hat den gesuchten Wert
            }
            else if (nodeUnderScope.Value > elem && nodeUnderScope.Left != null)
            {
                return binarySearch(nodeUnderScope.Left, elem); //Gesuchter Wert ist kleiner als aktueller NodeWert
            }
            else if (elem > nodeUnderScope.Value && nodeUnderScope.Right != null)
            {
                return binarySearch(nodeUnderScope.Right, elem);//Gesuchter Wert ist größer als aktueller NodeWert
            }
            else
            {
                SearchHelper = nodeUnderScope; //neuer Knoten müsste hinter diesen kommen; nodeUnderScope ist blatt
                return false;//Element nicht vorhanden in Baum
            }
        }

        private void printTree(Node n, int lvl = 0)
        {
            string tabs = "         ";
            if (n != null)
            {
                printTree(n.Right, lvl + 1);
                // einrückungen für die ausgabe
                tabs = String.Concat(Enumerable.Repeat(tabs, lvl));
                if (lvl != 0)
                {
                    //Console.WriteLine(tabs + "height" + lvl + "\n");
                    Console.WriteLine(tabs + " ---- " + $" ({n.Value})" + "\n");
                }
                else
                {
                    Console.WriteLine($"\n\n\n(r): ({n.Value})\n\n\n");
                }
                printTree(n.Left, lvl + 1);
            }
        }
        #endregion



        public void testBintree()
        {
            /*insert(45);
            insert(18);
            insert(10);
            insert(41);
            insert(43);
            insert(68);
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
            insert(2);
            //insert(15);
            if (delete(18)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");
            Console.WriteLine("------------------------------------------------------\n\n");
            insert(67);
            if (delete(68)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");
            Console.WriteLine("------------------------------------------------------\n\n");

            Console.WriteLine("Löschen einer Zahl nicht im Baum:\n");
            if (delete(999)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");

            Console.WriteLine("3 einfügen");
            insert(3);
            print();*/
        }
      /*  private int deleteNode(Node n)
        {
            if (n == null)
            {
                n = SearchHelper;
            }

            if (n.Right != null)
            {
                return deleteNode(n.Right);
            }
            else
            {
                int symmPredecessor = n.Value;
                if (n.Left != null)
                {
                    Node parentOfn = n.Parent;
                    n = n.Left;
                    parentOfn.Right = n;
                    n.Parent = parentOfn;
                }
                else
                {
                    _ = n.Parent.Value < n.Value ? n.Parent.Right = null : n.Parent.Left = null;
                }
                return symmPredecessor;
            }
        }*/
    }
}
