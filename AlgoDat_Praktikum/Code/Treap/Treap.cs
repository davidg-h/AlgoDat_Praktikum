using System;
using System.Linq;
using AlgoDat_Praktikum.Code.Bin_SearchTree;

namespace AlgoDat_Praktikum.Code.Treap
{
    class Treap : BinSearchTreeTemplate
    {
        Node root;
        Random rand = new Random();
        int prio;

        public void userHandler()
        {
            Console.WriteLine("Du hast einen Treap ausgewählt!");
            Console.WriteLine("1.Suche eine Zahl");
            Console.WriteLine("2.Füge eine Zahl hinzu");
            Console.WriteLine("3.Lösche eine Zahl");
            Console.WriteLine("4.Ausgabe des Treaps");
            var userInput = Console.ReadLine();
        }

        public void testRotate()
        {
            Node six = new Node(6, null, null, null);
            Node drei = new Node(3, null, null, null);
            Node zwei = new Node(2, null, null, null);
            Node vier = new Node(4, null, null, null);
            Node neun = new Node(9, null, null, null);
            Node acht = new Node(8, null, null, null);
            Node zehn = new Node(10, null, null, null);

            six.Left = drei;
            six.Right = neun;

            drei.Parent = six;
            drei.Left = zwei;
            drei.Right = vier;

            zwei.Parent = drei;
            vier.Parent = drei;

            neun.Parent = six;
            neun.Left = acht;
            neun.Right = zehn;

            acht.Parent = neun;
            zehn.Parent = neun;
            root = six;
            Console.WriteLine("Standtard:");
            print(root);
            rightRotOfNode(drei);
            Console.WriteLine("\n\n");
            Console.WriteLine("rechts rot um 3:");
            print(root);
            leftRotOfNode(neun);
            Console.WriteLine("\n\n");
            Console.WriteLine("left rot um 9:");
            print(root);
        }

        private void rightRotOfNode(Node n)
        {
            Node oldRightOf_n = n.Right;
            Node oldParentParentOf_n = n.Parent.Parent;
            n.Right = n.Parent;
            n.Right.Parent = n;
            n.Right.Left = oldRightOf_n;
            n.Right.Left.Parent = n.Right;
            n.Parent = oldParentParentOf_n;
            if (n.Parent != null)
            {
                _ = n.Parent.Value < n.Value ? n.Parent.Right = n : n.Parent.Left = n;
            }
            else
            {
                root = n;
            }
        }

        private void leftRotOfNode(Node n)
        {
            Node oldLeftOf_n = n.Left;
            Node oldParentParentOf_n = n.Parent.Parent;
            n.Left = n.Parent;
            n.Left.Parent = n;
            n.Left.Right = oldLeftOf_n;
            n.Left.Left.Parent = n.Right;
            n.Parent = oldParentParentOf_n;
            if (n.Parent != null)
            {
                _ = n.Parent.Value < n.Value ? n.Parent.Right = n : n.Parent.Left = n;
            }
            else
            {
                root = n;
            }
        }

        private void print(Node n, int lvl = 0)
        {
            string tabs = "         ";
            if (n != null)
            {
                print(n.Right, lvl + 1);
                // einrückungen für die ausgabe
                tabs = String.Concat(Enumerable.Repeat(tabs, lvl));
                if (lvl != 0)
                {
                    //Console.WriteLine(tabs + "height" + lvl + "\n");
                    Console.WriteLine(tabs + " ---- " + n.Value + "\n");
                }
                else
                {
                    Console.WriteLine("(r): " + n.Value);
                }
                print(n.Left, lvl + 1);
            }
        }
    }
}
