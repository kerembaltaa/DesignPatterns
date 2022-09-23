using System;

namespace Template_Method_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Alisveris a1 = new Televizyon();
            a1.TemplateMethod();
            Console.WriteLine("***********");
            Alisveris a2 = new Buzdolabi();
            a2.TemplateMethod();

            Console.Read();
        }
    }
    enum OdemeTipi
    {
        Pesin, Taksit
    }

    abstract class Alisveris
    {
        protected string UrunAdi;
        protected OdemeTipi odemeTipi;
        void Baslat() => Console.WriteLine("Alışveriş başladı.");
        void Bitir() => Console.WriteLine($"Alışveriş bitti.{UrunAdi} {odemeTipi} yöntemiyle alınmıştır.");
        abstract public void Urun();
        abstract public void OdemeSekli();
        public void TemplateMethod()
        {
            Baslat();
            Urun();
            OdemeSekli();
            Bitir();
        }
    }
    class Televizyon : Alisveris
    {
        public override void OdemeSekli()
        {
            odemeTipi = OdemeTipi.Pesin;
        }

        public override void Urun()
        {
            UrunAdi = "Televizyon";
        }
    }

    class Buzdolabi : Alisveris
    {
        public override void OdemeSekli()
        {
            odemeTipi = OdemeTipi.Taksit;
        }

        public override void Urun()
        {
            UrunAdi = "Buzdolabı";
        }
    }

}
