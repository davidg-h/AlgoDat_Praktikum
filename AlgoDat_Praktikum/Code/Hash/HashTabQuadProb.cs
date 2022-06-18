using AlgoDat_Praktikum.Code.Interfaces;
using System;

namespace AlgoDat_Praktikum.Code.Hash
{
    public class HashTabQuadProb: HashHelper, ISetUnsorted<int> 
    {
        public int Size;
        int[] memory;
        public int SearchHelper { get; set; }
        public HashTabQuadProb(int size){
            this.Size = size;
            memory = new int[Size];
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = -1;
            }
        }

        public bool search(int elem){
            int newKey = divisionRestMethode(elem, Size);
            if(memory[newKey] == elem)
            {
                SearchHelper = newKey;
                return true;
            }
            for (int i = 1; i < newKey; i++)
            {
                if(memory[newKey-i] == elem)
                {
                    SearchHelper = newKey - i;
                    return true;
                }
                    
            }
            for (int i = 1; i < Size - newKey; i++)
            {
                if (memory[newKey + i] == elem)
                {
                    SearchHelper = newKey + i;
                    return true;
                }
            }
            return false;
            
        }  // true = gefunden


        public bool insertSondierung(int key, int value){
            if(memory[key] == -1){
                memory[key] = value;
                return true;
            }
            else{
                int i = 1;
                //look at left side for free data cell
                while(key-i >= 0 && memory[key-i] != -1) i++;
                if(key-i >= 0) {
                    //free memory cell found
                    memory[key-i] = value;
                }
                else{
                    i = 1;
                    //look at right side for free data cell
                    while(key+i <= Size && memory[key+i] != -1) i++;
                    if(key + i < Size) {
                        //free memory cell found
                        memory[key+i] = value;
                    }
                    else{
                        //if not on left nor on right side free space
                        return false;
                    }
                }
                return true;
            }
        }
        public bool insert2(int valueKey)
        {
            int newKey = divisionRestMethode(valueKey, Size);
            return insertSondierung(newKey, valueKey);
        }

        public bool insert(int valueKey)
        {
            int newKey = divisionRestMethode((int)Math.Pow(valueKey,2), Size);
            return insertSondierung(newKey, valueKey);
        }

        public bool delete(int elem){
            int value = divisionRestMethode(elem, Size);
            if (value == -1)
                return false;
            memory[divisionRestMethode(elem, Size)] = -1;
            return true;
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
