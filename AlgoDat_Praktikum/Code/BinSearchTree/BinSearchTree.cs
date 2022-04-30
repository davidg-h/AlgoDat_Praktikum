using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDat_Praktikum.Code.Interfaces;


namespace AlgoDat_Praktikum.Code.BinSearchTree
{
    // wird von List nicht mehr geerbt sondern nur noch vom Interface
    class BinSearchTree : List, ISetSorted
    {
        //Properties:
        public Node TreeRoot { get; set; }
        Node currentNode = TreeRoot;
        //Functions
        public override bool insert(int elem)
        {
            Node nodeToInsert = new Node(elem);
            Node parentNode = null;

            if (this.currentNode == null) // TreeRoot is null
            {
                TreeRoot = nodeToInsert; //Given value is new root
                return true;
            }
            while (currentNode != null) //Go through the tree until you find the next avaiable leaf
            {
                if (currentNode.NodeValue > elem) // Given value is smaller then the Node value under scope
                {
                    parentNode = currentNode; //Saving information about parent node if following node might be null
                    currentNode = currentNode.LeftNode; //traverse to the left 
                }
                else if (currentNode.NodeValue < elem)// Given value is smaller then the Node value under scope
                {
                    parentNode = currentNode;//Saving information about parent node if following node might be null
                    currentNode = currentNode.RightNode;//traverse to the right;  
                }
            }
            //Insertion of new leaf
            if (parentNode.NodeValue < elem)
            {
                parentNode.RightNode = nodeToInsert;
                return true;
            }
            else if (parentNode.NodeValue > elem)
            {
                parentNode.LeftNode = nodeToInsert;
                return true;
            }
            // hier wollte der fuhr das mit dem suchen haben wo die position geben wird falls der knoten nicht vorhanden ist -> damit nur einmal gesucht wird
            else // Value must already be in tree 
            {
                return false;
            }
        }
        public override bool delete(int elem)
        {
            if (search(elem) == true)
            {
                deleteNode(currentNode, elem);
                return true;
            }
            else
                return false;
            
        }

        static Node deleteNode(Node root, int elem)
        {
            //tree is empty
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

            if(root.LeftNode == null)
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

                while(prev.LeftNode != null)
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
            }
        }

        public override bool search(int elem)
        {
            if (TreeRoot == null)
            {
                return false;//Keine Elemente im Baum -> Wert kann nicht vorkommen 
            }
            return binarySearch(TreeRoot, elem);
        }

        bool binarySearch(Node nodeUnderScope, int elem)
        {
            if (nodeUnderScope.NodeValue == elem)
            {
                return true; //Momentane Node hat den gesuchten Wert
            }
            else if (nodeUnderScope.NodeValue > elem && nodeUnderScope.LeftNode.NodeValue != null)
            {
                binarySearch(nodeUnderScope.LeftNode, elem); //Gesuchter Wert ist kleiner als aktueller NodeWert
            }
            else if (elem > nodeUnderScope && nodeUnderScope.RightNode.NodeValue != null)
            {
                binarySearch(nodeUnderScope.RightNode, elem);//Gesuchter Wert ist größer als aktueller NodeWert
            }
            else
            {
                false;//Element nicht vorhanden in Baum
            }
        }//Hilfsfunktion für rekursivenaufruf

        public override print()
        {
            InorderTraversal(TreeRoot);
        }

        void InorderTraversal(Node root)
        {
            if (root == null)
            {
                return;
            }

            InorderTraversal(root.LeftNode);
            System.Console.WriteLine(root.NodeValue + " ");
            InorderTraversal(root.RightNode);

        }
    }
}
