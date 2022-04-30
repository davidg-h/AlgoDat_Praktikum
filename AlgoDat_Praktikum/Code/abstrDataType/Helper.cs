using System;
using AlgoDat_Praktikum.Code.Interfaces;

//ist obsolete wegen dem interface ISearchHelper
namespace AlgoDat_Praktikum.Code.abstrDataType
{
    public abstract class Helper : IDictionary
    {
        /// <summary>
        /// if elem was found successfulInsert => true and elemPos => index (where elem was found)
        /// else successfulInsert => false and elemPos => index (where elem should be inserted)
        /// </summary>
        private (bool successfulInsert, int elemPos) searchHelper;
        
        // has to be private when implemented s.r.: Praktikums-Aufgabestellung S.12 (delete this comment after implementation)
        // or implementation with variables s.r.: Praktikums-Aufgabestellung S.12 and searchHelper (decision on one method)
        /// <summary>
        /// helper for search
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public abstract (bool, int) _search(int elem); 

        public virtual bool search(int elem)
        {
            searchHelper = _search(elem);
            return searchHelper.successfulInsert;
        }

        public abstract bool delete(int elem);

        public abstract bool insert(int elem);

        /// <summary>
        /// preorder, inorder or postorder has to be decided
        /// </summary>
        public abstract void print();
    }
}
