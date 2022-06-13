using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.LinkedList
{
    abstract class List
    {
        public Node SearchHelper { get; set; }
        internal Node head;
        public bool sorted = false;
        public void print(Node head)
        {
            printExtra(head);
        }

        public void printExtra(Node head)
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }
        }
        public bool search(int elem)
        {
            if (sorted)
            {
                return searchSorted(head, elem);

            }
            return searchUnsorted(head, elem);
        }
        public bool searchSorted(Node current, int x)
        {
            if (current != null)
            {
                if (current.data == x)
                {
                    SearchHelper = current;
                    return true;

                }
                if (this.head.data > x)
                {
                    SearchHelper = null;
                    return false;
                }
                if (current.next == null)
                {
                    SearchHelper = current;
                    return false;
                }
                while (current.next != null)
                {
                    if (current.next.data == x)
                    {
                        SearchHelper = current;
                        return true;
                    }
                    if (x > current.next.data)
                    {
                        current = current.next;

                    }
                    else
                    {
                        SearchHelper = current;
                        return false;
                    }
                }
                SearchHelper = current;
                return false;
            }
            SearchHelper = null;
            return false;
        }
        public bool searchUnsorted(Node current, int x)
        {
            if (current != null)
            {
                if (current.data == x)
                {
                    SearchHelper = current;
                    return true;

                }
                while (current.next != null)
                {
                    if (current.next.data == x)
                    {
                        SearchHelper = current;
                        return true;
                    }
                    current = current.next;
                }
                SearchHelper = current;
                return false;
            }
            SearchHelper = null;
            return false;
        }
        public bool delete(int elem)
        {
            return deleteExtra(head, elem);
        }

        public bool deleteExtra(Node head, int elem)
        {
            search(elem);
            if (SearchHelper != null)
            {
                if (SearchHelper.data == head.data && SearchHelper.data == elem)
                {
                    this.head = head.next;
                    return true;
                }
                else if (SearchHelper.next.data == elem)
                {
                    SearchHelper.next = SearchHelper.next.next;
                    return true;
                }
            }
            Console.WriteLine("The value you are trying to delete does not exsist !");
            return false;
        }
    }
}
