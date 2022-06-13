using AlgoDat_Praktikum.Code.Bin_SearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.AVLTree
{
    class AVL : BinSearchTree
    {
        public new void userHandler()
        {
            do
            {
                Console.WriteLine("\n\nDu hast einen AVL Baum ausgewählt!");
                Console.WriteLine("1.Suche eine Zahl");
                Console.WriteLine("2.Füge eine/mehrere Zahl/en hinzu");
                Console.WriteLine("3.Lösche eine Zahl");
                Console.WriteLine("4.Ausgabe des AVL Baums");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\nWelche Zahl möchstest du suchen?");
                        if (search(Convert.ToInt32(Console.ReadLine()))) { Console.WriteLine($"Deine Zahl wurde gefunden und kommt nach {SearchHelper.Parent.Value}\n\n"); print(); }
                        else { Console.WriteLine("Leerer AVL/Zahl nicht im AVL Baum! Schaue nochmal die Ausgabe an\n\n"); print(); }
                        break;
                    case "2":
                        Console.WriteLine("\nFalls du mehrere Zahlen hinzufügen möchstest schreibe sie in diesem Format auf: 2,3,4,5,6,...");
                        var arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToInt32);
                        foreach (int elem in arr)
                        {
                            insert(elem);
                        }
                        Console.WriteLine("\nDein AVL:\n\n");
                        print();
                        break;
                    case "3":
                        Console.WriteLine("\nWelche Zahl möchstest du löschen?:");
                        if (delete(Convert.ToInt32(Console.ReadLine())))
                        {
                            Console.WriteLine("");

                            Console.WriteLine("Deine Zahl wurde gelöscht. Dein neuer AVL:\n\n"); print();
                        }
                        else
                            Console.WriteLine("Deine Zahl konnte nicht gelöscht werden.");
                        break;
                    case "4":
                    default:
                        Console.WriteLine("\nAusgabe des AVLs:\n\n");
                        print();
                        break;
                }
                Console.WriteLine("\n\nDrücke Esc um zu beenden");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        #region public methods
        public override bool insert(int elem)
        {
            bool sucessfullInsert = base.insert(elem);
            // after every insert in AVL Tree the Nodes should be set their balancefactor and sorted
            if (search(elem) && TreeRoot.Value != elem)
            {
                BalanceFactorParent(SearchHelper);
                CheckBalanceFactor(SearchHelper);
            }
            return sucessfullInsert;
        }
        public new bool delete(int elem)
        {
            bool sucessfullDelete = base.delete(elem);
            //after every delete the balance factor need to be set and checked
            if(sucessfullDelete)
            {
            BalanceFactorParent(SearchHelper);
            CheckBalanceFactor(SearchHelper);
            return true;
            }
            else return false;

        }
        #endregion

        #region balancefactor check/set
        //checks the balancefactor of every Node 
        private bool CheckBalanceFactor(Node NodeUnderScope)
        {
            //check for double-rotation or a single rotation is needed
            if (NodeUnderScope.Balance >= 2)
            {
                if (NodeUnderScope.Left.Balance >= 0)
                {
                    rightRotOfNode(NodeUnderScope.Left);
                }
                else
                {
                    //double left-right rotation
                    leftRotOfNode(NodeUnderScope.Left.Right);
                    rightRotOfNode(NodeUnderScope.Left);
                }
            }

            if (NodeUnderScope.Balance <= -2)
            {
                if (NodeUnderScope.Right.Balance <= 0)
                {
                    leftRotOfNode(NodeUnderScope.Right);
                }

                else
                {
                    leftRotOfNode(NodeUnderScope.Left.Right);
                    rightRotOfNode(NodeUnderScope.Left);
                }
            }
            //start with parent and keep checking the parent Nodes because only they are still important after rotation
            if (NodeUnderScope.Parent != null)
            {
                    CheckBalanceFactor(NodeUnderScope.Parent);
            }
            return true;
        }
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
            if (n.Parent != null)
            {
                BalanceFactorParent(n.Parent);
                CheckBalanceFactor(n.Parent);
            }
        }
        public void leftRotOfNode(Node n)
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
            if (n.Parent != null)
            {
                BalanceFactorParent(n.Parent);
                CheckBalanceFactor(n.Parent);
            }
        }

        //sets the BalanceFactor of every single Node in Tree
        private void BalanceFactorParent(Node NodeUnderScope)
        {
            SetBalanceFactor(NodeUnderScope);
            //count the balancefactor starting with the searchHelper Node where a Node was inserted or deleted and work up to the treeroot
            if (NodeUnderScope.Parent != null)
                BalanceFactorParent(NodeUnderScope.Parent);
        }

        //helper class of PreOrderSetBF
        private void SetBalanceFactor(Node NodeUnderScope)
        {
            NodeUnderScope.Balance = 0;
            int lengthLeft = 0;
            int maxLeft = 0;
            int maxRight = 0;

            //if the node is a leaf set the BF to 0
            if (NodeUnderScope.Left == null && NodeUnderScope.Right == null)
                NodeUnderScope.Balance = 0;
            else
            {
                LengthOfSide(ref maxLeft, ref maxRight, ref lengthLeft, NodeUnderScope);
                NodeUnderScope.Balance = maxLeft - maxRight;
            }
        }
        #endregion

        #region Node Length Methods
        //checks the length of each sides of a Node
        private void LengthOfSide(ref int maxLeft, ref int maxRight, ref int length, Node NodeUnderScope)
        {

            //first check which side will be looked at so that the lenght counter doesnt mix them up
            if (NodeUnderScope.Left != null)
            {
                length++;
                LengthOfSideHelper(ref maxLeft, ref length, NodeUnderScope.Left); 
            }
            length = 0;
            if (NodeUnderScope.Right != null)
            {
                length++;
                LengthOfSideHelper(ref maxRight, ref length, NodeUnderScope.Right);
            }
        }

        private void LengthOfSideHelper(ref int maxSide, ref int length, Node n)
        {
            if (maxSide < length)
                maxSide = length;
            if (n.Left != null)
            {
                length++;
                LengthOfSideHelper(ref maxSide, ref length, n.Left);
                length--;
            }
            if (n.Right != null)
            {
                length++;
                LengthOfSideHelper(ref maxSide, ref length, n.Right);
                length--;
            }
        }
        #endregion
    }
}

