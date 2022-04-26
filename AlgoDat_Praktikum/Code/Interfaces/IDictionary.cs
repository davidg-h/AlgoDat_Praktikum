namespace AlgoDat_Praktikum.Code.Interfaces
{
    interface IDictionary
    {
        bool search(int elem);
        bool insert(int elem);
        bool delete(int elem);
        void print();
    }
}