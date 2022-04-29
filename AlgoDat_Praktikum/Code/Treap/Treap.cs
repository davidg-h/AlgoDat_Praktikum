using System;
using AlgoDat_Praktikum.Code.Bin_SearchTree;

namespace AlgoDat_Praktikum.Code.Treap
{
    class Treap : BinSearchTree
    {
        Random rand = new Random();
        int prio;


        public void userHandler()
        {
            Console.WriteLine("Du hast einen Treap ausgewählt!");
            Console.WriteLine("1.Suche eine Zahl");
            Console.WriteLine("2.Füge eine Zahl hinzu");
            Console.WriteLine("3.Lösche eine Zahl");
            Console.WriteLine("4.Ausgabe des Treaps");
            var userInput = Console.ReadLine();
        }
    }
}
