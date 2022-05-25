using AlgoDat_Praktikum.Code.Interfaces;
using System;
using System.Collections.Generic;

namespace AlgoDat_Praktikum.Code.Array
{
    public class HashTabSepChain: HashHelper, ISetUnsorted<int> {
        
        public int Size;
        //TODO: own Datatype for ArrayList
        List<int>[] memory;
        public int SearchHelper { get; set; }

    
        public HashTabSepChain(int size){
            this.Size = size;   
            memory = new List<int>[Size];
            for (int i = 0; i < Size; i++)
            {
                memory[i] = new List<int>();
            }
        }

        public bool search(int key)
        {
            int newKey = divisionRestMethode(key);
            for (int i = 0; i < memory[newKey].Count; i++)
            {
                if (memory[newKey][i] == key)
                    return true;

            }
            return false;
        }

        public bool insert(int elem)
        {
            int newKey = divisionRestMethode(elem);
            if (memory[newKey] == null)
                memory[newKey] = new List<int>();
            memory[newKey].Add(elem);
            return true;
        }

        public bool delete(int elem)
        {
            int newKey = divisionRestMethode(elem);
            memory[newKey].Remove(elem);
            return true;
        }

        public void print(){
            for(int i=0;i<Size;i++){
                for (int j = 0; j < memory[i].Count - 1; j++)
                {
                    Console.WriteLine(i + ": \t" + memory[i][j]);
                }
            }
        }

        private int divisionRestMethode(int k){
	        return (k % Size);
        }
    }
}
