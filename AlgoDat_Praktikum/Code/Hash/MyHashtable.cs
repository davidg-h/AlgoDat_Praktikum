using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgoDat_Praktikum.Code.Array
{
    public class MyHashtable
    {
        public int Size;
        int[] memory;

        public MyHashtable(int size){
            this.Size = findNextPrime(size);
            //TODO: set size to next prime
            memory = new int[Size];
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = -1;
            }
        }

        public bool search(int elem){
            int value = divisionRestMethode(elem);
            if (value == -1)
                return false;
            return true;
        }  // true = gefunden

        public bool insert(int elem, int key = -1)
        {
            int i = 0;
            while(i < Size && memory[i] != -1 ) i++;
            if(i == Size) return false;
            memory[i] = elem;
            return true;
        }

        public bool insertSondierung(int key,int elem){
            if(memory[key] == -1){
                memory[key] = elem;
                return true;
            }
            else{
                int i = 1;
                while(key-i >= 0 && memory[key-i] != -1) i++;
                if(key-i < 0) {
                    i = 1;
                    while(key+i <= Size && memory[key+i] != -1) i++;
                    if(key + i > Size) {
                        return false;
                    }
                    else{
                        memory[key+i] = elem;
                    }
                }
                else{
                    memory[key-i] = elem;
                }
                return true;
            }
        }
        public bool insert2(int key, int elem)
        {
            int newKey = divisionRestMethode(key);
            return insertSondierung(newKey, elem);
        }

        public bool insertQuadratic(int key, int elem)
        {
            int newKey = divisionRestMethode((int)Math.Pow(key,2));
            return insertSondierung(newKey, elem);
        }

        public bool delete(int elem){
            int value = divisionRestMethode(elem);
            if (value == -1)
                return false;
            memory[divisionRestMethode(elem)] = -1;
            return true;
        } // true = gelöscht

        public void print(){
            for(int i=0;i<Size;i++){
               Console.WriteLine(i+": "+memory[i]);
            }
        }

        private int findNextPrime(int number)
        {
            bool isPrime = false;
            int counter  = number;
            while (!isPrime)
            {
                isPrime = true;
                for (int i = 2; i < counter / 2; i++)
                {
                    if (counter % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                counter++;
            }
            return counter;
        }

        private int divisionRestMethode(int k){
	        return (k % Size);
        }
    }
}
