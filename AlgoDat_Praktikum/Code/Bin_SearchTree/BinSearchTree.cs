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
        //Functions
        public virtual bool insert(int elem)
        {
            Node nodeToInsert = new Node(elem, null, null, null, new Random().Next(101));
            if (TreeRoot == null) // TreeRoot is null
            {
                TreeRoot = nodeToInsert; //Given value is new root
                LastInsert = TreeRoot;
                return true;
            }
            //while (currentNode != null) //Go through the tree until you find the next avaiable leaf
            //{
            //    if (currentNode.NodeValue > elem) // Given value is smaller then the Node value under scope
            //    {
            //        parentNode = currentNode; //Saving information about parent node if following node might be null
            //        currentNode = currentNode.LeftNode; //traverse to the left 
            //    }
            //    else if (currentNode.NodeValue < elem)// Given value is smaller then the Node value under scope
            //    {
            //        parentNode = currentNode;//Saving information about parent node if following node might be null
            //        currentNode = currentNode.RightNode;//traverse to the right;  
            //    }
            //}
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
            if (search(elem) == true)
            {
                /*  if (SearchHelper.elemPos.LeftNode == elem)
                  {
                      deleteNode(SearchHelper.elemPos.LeftNode, elem);
                  }
                  else if (SearchHelper.elemPos.RightNode == elem)
                  {
                      deleteNode(SearchHelper.elemPos.RightNode, elem);
                  }*/

                // löschen eines blattes
                if (SearchHelper.Left == null && SearchHelper.Right == null)
                {
                    _ = SearchHelper.Value > SearchHelper.Parent.Value ? SearchHelper.Parent.Right = null : SearchHelper.Parent.Left = null;
                }
                else
                {
                    SearchHelper.Value = deleteNode(SearchHelper.Left);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private int deleteNode(Node n)
        {
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
                    parentOfn.Left = n;
                    n.Parent = parentOfn;
                }
                else
                {
                    n.Parent.Right = null;
                }
                return symmPredecessor;
            }

            /*//tree is empty
            if (root == null)
            {
                return root;
            }

            //Recursive call until root is Nodevalue to be deleted
            if (root.NodeValue > elem)
            {
                root.LeftNode = deleteNode(root.LeftNode, elem);
                return root;
            }
            else if (root.NodeValue < elem)
            {
                root.RightNode = deleteNode(root.RightNode, elem);
                return root;
            }

            if (root.LeftNode == null)
            {
                Node child = root.RightNode;
                return child;
            }
            else if (root.RightNode == null)
            {
                Node child = root.LeftNode;
                return child;
            }
            else
            {
                Node prevParent = root;

                Node prev = root.RightNode;

                while (prev.LeftNode != null)
                {
                    prevParent = prev;
                    prev = prev.LeftNode;
                }

                if (prevParent != root)
                {
                    prevParent.LeftNode = prev.RightNode;
                }
                else
                {
                    prevParent.RightNode = prev.RightNode;
                }

                root.NodeValue = prev.NodeValue;
                return root;
            }*/
        }

        public bool search(int elem)
        {
            if (TreeRoot == null)
            {
                return false;//Keine Elemente im Baum -> Wert kann nicht vorkommen 
            }
            return binarySearch(TreeRoot, elem);
        }

        //Hilfsfunktion für rekursivenaufruf
        bool binarySearch(Node nodeUnderScope, int elem)
        {
            if (nodeUnderScope.Value == elem)
            {
                SearchHelper = nodeUnderScope;
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

        public virtual void print()
        {
            printTree(TreeRoot);
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
                    Console.WriteLine($"(r): ({n.Value})");
                }
                printTree(n.Left, lvl + 1);
            }
        }

        public void testBintree()
        {
            insert(6);
            insert(3);
            insert(9);
            insert(10);
            insert(8);
            insert(3);
            insert(2);
            insert(4);
            insert(1);
            print();

            if (search(3)) Console.WriteLine("3 da\n\n");
            else Console.WriteLine("3 nicht da");

            if (delete(3)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");

            Console.WriteLine("Löschen der Root:\n");
            if (delete(6)) print();
            else Console.WriteLine("Keine solche Zahl vorhanden");
        }
    }
}
