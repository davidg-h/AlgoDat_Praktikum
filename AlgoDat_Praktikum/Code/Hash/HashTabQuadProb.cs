using AlgoDat_Praktikum.Code.Interfaces;
using System;

namespace AlgoDat_Praktikum.Code.Hash
{
    public class HashTabQuadProb: HashHelper, ISetUnsorted<int> 
    {
        int[] memory;

        public HashTabQuadProb(int size){
            this.Size = size;
            memory = new int[Size];
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = -1;
            }
        }

        public bool search(int value){
            int key = modulo(value, Size);
            int nextFree = -1;
            if(memory[key] == value)
            {
                SearchHelper = key;
                return true;
            }
            if (memory[key] == -1)
            {
                nextFree = key;
            }
            for (int i = 1; i < Size / 2 + 1; i++)
            {
                int offset = i * i;
                int newKey = modulo(key + offset, Size);
                if(nextFree == -1 && memory[newKey] == -1){     //nextFree noch nicht gesetzt
                    nextFree = newKey;
                }
                else if(memory[newKey] == value)
                {
                    SearchHelper = newKey;
                    return true;
                }
                newKey = modulo(key - offset, Size);
                if (nextFree == -1 && memory[newKey] == -1){
                    nextFree = newKey;
                }
                if(memory[newKey] == value)
                {
                    SearchHelper = newKey;
                    return true;
                }
            }
            SearchHelper = nextFree;
            return false;
            
        }  // true = gefunden


        public bool insertQuadraticProbing(int value){

            if(search(value)){
                System.Console.WriteLine("Wert " + value + " schon vorhanden");
                Console.ReadKey();
                return false;
            }
            if(SearchHelper == -1){
                System.Console.WriteLine("HashTable ist voll");
                Console.ReadKey();
                return false;
            }
            memory[SearchHelper] = value;
            return true;
        }

        public bool insert(int value)
        {
            return insertQuadraticProbing(value);
        }

        public bool delete(int value){
            if(search(value)){
                memory[SearchHelper] = -1;
                return true;
            }
            return false;
        } // true = gelöscht

        public void print(){
            for(int i=0;i<Size;i++){
                if (memory[i] == -1)
                    Console.WriteLine(i + ": \t--");
                else
                    Console.WriteLine(i + ": \t" + memory[i]);
            }
        }
    }
}
