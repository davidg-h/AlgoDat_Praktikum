using AlgoDat_Praktikum.Code.Interfaces;
using System;
using System.Collections.Generic;

namespace AlgoDat_Praktikum.Code.Hash
{
    public class HashTabSepChain: HashHelper, ISetUnsorted<int> {
        
        public int Size;
        LinkedList.SetUnsortedLinkedList[] memory;
        public int SearchHelper { get; set; }

    
        public HashTabSepChain(int size){
            this.Size = size;   
            memory = new LinkedList.SetUnsortedLinkedList[Size];
            for (int i = 0; i < Size; i++)
            {
                memory[i] = new LinkedList.SetUnsortedLinkedList();
            }
        }

        public bool search(int value)
        {
            int newKey = modulo(value, Size);
            bool result = memory[newKey].search(value);
            if(result)
                SearchHelper = newKey;
            return result;
        }

        public bool insert(int value)
        {
            int newKey = modulo(value, Size);
            bool result = memory[newKey].insert(value);
            if (!result)
            {
                Console.WriteLine("Wert konnte leider nicht eingefügt werden");
                Console.ReadKey();
            }
            return result;
        }

        public bool delete(int value)
        {
            int newKey = modulo(value, Size);
            bool result = memory[newKey].delete(value);
            if (!result)
            {
                Console.WriteLine("Wert konnte leider nicht gelöscht werden");
                Console.ReadKey();
            }
            return result;
        }

        public void print(){
            for(int i=0;i<Size;i++){
                if(memory[i].head == null)
                    Console.WriteLine(i + ": \t--");
                else
                {
                    Console.Write(i + ": \t[\n");
                    memory[i].print();
                    Console.Write("]\n");
                }
            }
        } 
    }
}
