using AlgoDat_Praktikum.Code.Interfaces;
using System;
using System.Collections.Generic;

namespace AlgoDat_Praktikum.Code.Hash
{
    public class HashTabSepChain: HashHelper, ISetUnsorted<int> {
        
        public int Size;
        LinkedList.MultiSetSortedLinkedList[] memory;
        public int SearchHelper { get; set; }

    
        public HashTabSepChain(int size){
            this.Size = size;   
            memory = new LinkedList.MultiSetSortedLinkedList[Size];
            for (int i = 0; i < Size; i++)
            {
                memory[i] = new LinkedList.MultiSetSortedLinkedList();
            }
        }

        public bool search(int key)
        {
            int newKey = divisionRestMethode(key);
            bool result = memory[newKey].search(newKey);
            if(result)
                SearchHelper = memory[newKey].SearchHelper.data;
            return result;
        }

        public bool insert(int elem)
        {
            int newKey = divisionRestMethode(elem);
            // if (memory[newKey] == null)
            //     memory[newKey] = new LinkedList.MultiSetSortedLinkedList();
            memory[newKey].insert(elem);
            return true;
        }

        public bool delete(int elem)
        {
            int newKey = divisionRestMethode(elem);
            memory[newKey].delete(elem);
            return true;
        }

        public void print(){
            for(int i=0;i<Size;i++){
                if(memory[i].head == null)
                    Console.WriteLine(i + ": \t--");
                else
                {
                    Console.Write(i + ": \t\n[");
                    memory[i].print();
                    Console.Write("]\n");
                }
                
            }
        }

        private int divisionRestMethode(int k){
	        return (k % Size);
        }
    }
}
