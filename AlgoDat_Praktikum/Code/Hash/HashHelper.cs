abstract public class HashHelper{

    public int Size;

    public int SearchHelper { get; set; }

    internal int modulo(int k, int size){
            int result = (k % size);
            if (result < 0)
                result += size;
	        return result;
        }
}