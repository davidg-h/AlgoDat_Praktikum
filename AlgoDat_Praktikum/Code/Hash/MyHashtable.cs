using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgoDat_Praktikum.Code.Array
{
    public class MyHashtable
    {
        int size;
        int[] memory;

        public MyHashtable(int size){
            this.size = size;
            memory = new int[size];
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = -1;
            }
        }
        public bool search(int elem){
            for (int i = 0; i < size; i++)
            {
                if(memory[i] == elem)
                    return true;
            }
            return false;
        }  // true = gefunden
        public bool insert(int elem, int key = -1)
        {
            int i = 0;
            while(i < size && memory[i] != -1 ) i++;
            if(i == size) return false;
            memory[i] = elem;
            return true;
        }
        public bool insert2(int key,int elem){
            int newKey = divisionRestMethode(key);
            if(memory[newKey] == -1){
                memory[newKey] = elem;
                return true;
            }
            else{
                int i = 1;
                while(newKey-i >= 0 && memory[newKey-i] != -1) i++;
                if(i < 0) {
                    while(newKey+i <= size && memory[newKey+i] != -1) i++;
                    if(i > 0) {
                    while(newKey-i >= 0 && memory[newKey-i] != -1) i++;
                }
                else{
                    memory[newKey-i] = elem;
                }
                }
                else{
                    memory[newKey-i] = elem;
                }
                memory[i] = elem;
                return true;

            }
        }

        public bool delete(int elem){
            return true;
        } // true = gelöscht
        public void print(){
            for(int i=0;i<size;i++){
               System.Console.WriteLine(i+": "+memory[i]);
            }
        }

        private int divisionRestMethode(int k){
	        return (k % size);
        }
    }
}
