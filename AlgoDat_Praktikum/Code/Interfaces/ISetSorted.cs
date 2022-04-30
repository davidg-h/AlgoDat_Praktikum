namespace AlgoDat_Praktikum.Code.Interfaces
{
    interface ISetSorted : IDictionary {
        bool search(int elem);
        bool insert(int elem);
        bool delete(int elem);
        void print();
    }
}