namespace AlgoDat_Praktikum.Code.Interfaces
{
    // if you add something to the interfaces below please refactor them in an own .cs file in the folder
    interface IMultiSetUnsorted : IDictionary 
    {
        bool checkMultiSet(int elem);
       
    }
}