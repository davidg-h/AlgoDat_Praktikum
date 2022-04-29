namespace AlgoDat_Praktikum.Code.Interfaces
{
    interface ISearchHelper<T> : IDictionary
    {
        (bool successfulInsert, T elemPos) SearchHelper { get; set; }
    }
}
