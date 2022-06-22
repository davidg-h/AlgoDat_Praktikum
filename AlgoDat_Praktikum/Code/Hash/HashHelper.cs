abstract public class HashHelper{
       

        internal int modulo(int k, int size){
            int result = (k % size);
            if (result < 0)
                result += size;
	        return result;
        }
}