using System;
using System.Collections.Generic;

namespace Composite_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
             
            CompositeSoldier generalCagatay = new CompositeSoldier("Joe", Rank.General);


            generalCagatay.AddSoldier(new PrimitiveSoldier("Michael", Rank.Colonel));
            generalCagatay.AddSoldier(new PrimitiveSoldier("Tobias", Rank.Colonel));


            CompositeSoldier colonelNevi = new CompositeSoldier("Frank", Rank.Colonel);
            CompositeSoldier lieutenantColonelZing = new CompositeSoldier("Donovan", Rank.LieutenantColonel);


            lieutenantColonelZing.AddSoldier(new PrimitiveSoldier("Price", Rank.Captain));
            colonelNevi.AddSoldier(lieutenantColonelZing);
            colonelNevi.AddSoldier(new PrimitiveSoldier("Dave", Rank.LieutenantColonel));

            generalCagatay.AddSoldier(colonelNevi);


            generalCagatay.AddSoldier(new PrimitiveSoldier("Kenny", Rank.Colonel));


            generalCagatay.ExecuteOrder();


            Console.ReadLine();
        }
    }
    enum Rank
    {
        General,
        Colonel,
        LieutenantColonel,
        Major,
        Captain,
        Lieutenant
    }
    abstract class Soldier
    {

        protected string _name;
        protected Rank _rank;

        public Soldier(string name, Rank rank)
        {
            _name = name;
            _rank = rank;
        }

        public abstract void AddSoldier(Soldier soldier);
        public abstract void RemoveSoldier(Soldier soldier);
        public abstract void ExecuteOrder(); 

    }

    class PrimitiveSoldier : Soldier
    {

        public PrimitiveSoldier(string name, Rank rank) : base(name, rank)
        {

        }

        public override void AddSoldier(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        // Bu fonksiyonun Leaf için anlamı yoktur.
        public override void RemoveSoldier(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rank, _name));
        }

    }

    class CompositeSoldier : Soldier
    {


        private List<Soldier> _soldiers = new List<Soldier>();

        public CompositeSoldier(string name, Rank rank) : base(name, rank)
        {

        }

        public override void AddSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
        }

        public override void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rank, _name));

            foreach (Soldier soldier in _soldiers)
            {
                soldier.ExecuteOrder();
            }

        }
    }

}
