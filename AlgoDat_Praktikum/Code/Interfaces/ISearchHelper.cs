namespace AlgoDat_Praktikum.Code.Interfaces
{
    interface ISearchHelper<T> : IDictionary
    {
        T SearchHelper { get; set; }
    }
}
