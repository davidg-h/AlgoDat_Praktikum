namespace AlgoDat_Praktikum.Code.Interfaces
{
    interface IDictionary
    {
        bool search(int elem);
        bool insert(int elem);
        bool delete(int elem);
        void print();
    }

    // if you add something to the interfaces below please refactor them in an own .cs file in the folder
    interface IMultiSetUnsorted : IDictionary { }
    interface IMultiSetSorted : IDictionary { }
    interface ISetUnsorted : IDictionary { }
    interface ISetSorted : IDictionary { }
}