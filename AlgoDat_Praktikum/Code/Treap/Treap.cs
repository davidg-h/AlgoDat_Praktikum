using AlgoDat_Praktikum.Code.Bin_SearchTree;
using System;
using System.Linq;

namespace AlgoDat_Praktikum.Code.Treap
{
    class Treap : BinSearchTreeTemplate
    {
        NodeT root;
        Random rand = new Random();

        public void userHandler()
        {
            Console.WriteLine("Du hast einen Treap ausgewählt!");
            Console.WriteLine("1.Suche eine Zahl");
            Console.WriteLine("2.Füge eine Zahl hinzu");
            Console.WriteLine("3.Lösche eine Zahl");
            Console.WriteLine("4.Ausgabe des Treaps");
            var userInput = Console.ReadLine();
        }

        public void test()
        {
            NodeT six = new NodeT(6, null, null, null, 1);
            NodeT drei = new NodeT(3, null, null, null, 2);
            NodeT zwei = new NodeT(2, null, null, null, 3);
            NodeT vier = new NodeT(4, null, null, null, 4);
            NodeT neun = new NodeT(9, null, null, null, 5);
            NodeT acht = new NodeT(8, null, null, null, 6);
            NodeT zehn = new NodeT(10, null, null, null, 0);

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

            sortTree(zehn);
            Console.WriteLine("Sort Tree test:");
            print(root);
        }
        
        // after every node which is being added call sortTree on that node
        private void sortTree(NodeT n)
        {
            NodeT parent = (NodeT)n.Parent;
            while (parent != null && n.Prio < parent.Prio)
            {
                if (n.Value < parent.Value) rightRotOfNode(n);
                else leftRotOfNode(n);
                // new parent of n
                parent = (NodeT)n.Parent;
            }
        }

        private void rightRotOfNode(NodeT n)
        {
            NodeT oldRightOf_n = (NodeT)n.Right;
            NodeT oldParentParentOf_n = (NodeT)n.Parent.Parent;
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
                root = n;
            }
        }

        private void leftRotOfNode(NodeT n)
        {
            NodeT oldLeftOf_n = (NodeT)n.Left;
            NodeT oldParentParentOf_n = (NodeT)n.Parent.Parent;
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
                root = n;
            }
        }

        private void print(NodeT n, int lvl = 0)
        {
            string tabs = "         ";
            if (n != null)
            {
                print((NodeT)n.Right, lvl + 1);
                // einrückungen für die ausgabe
                tabs = String.Concat(Enumerable.Repeat(tabs, lvl));
                if (lvl != 0)
                {
                    //Console.WriteLine(tabs + "height" + lvl + "\n");
                    Console.WriteLine(tabs + " ---- " + $" ({n.Value},{n.Prio})" + "\n");
                }
                else
                {
                    Console.WriteLine($"(r): ({n.Value},{n.Prio})");
                }
                print((NodeT)n.Left, lvl + 1);
            }
        }
    }
}
