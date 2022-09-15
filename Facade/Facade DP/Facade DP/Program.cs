using System;

namespace Facade_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade fcd = new Facade();

            fcd.KrediKullan(new Musteri { Ad = "Burak", TcNo = "123303", MusteriNumarasi = 4234242 }, 1000);
        }
    }
    class Banka
    {
        public bool KrediyiKullan(Musteri m, decimal talepEdilenMiktar)
        {
            return true;
        }
    }
    class Kredi
    {
        public bool KrediKullanmaDurumu(Musteri m)
        {
            return true;
        }
    }
    class MerkezBanka
    {
        public bool KaraListeKontrol(string tcNo)
        {
            return false;
        }
    }
    class Musteri
    {
        public int MusteriNumarasi { get; set; }
        public string TcNo { get; set; }
        public string Ad { get; set; }
    }
    class Facade
    {
        private Banka _banka;
        private MerkezBanka _merkezBanka;
        private Kredi _kredi;

        public Facade()
        {
            _banka = new Banka();
            _merkezBanka = new MerkezBanka();
            _kredi = new Kredi();

        }

        public void KrediKullan(Musteri m, decimal talep)
        {
            if (!_merkezBanka.KaraListeKontrol(m.TcNo) && _kredi.KrediKullanmaDurumu(m))
            {
                _banka.KrediyiKullan(m, talep);
                Console.WriteLine("Krediyi kullandırdık");
            }

        }
    }
}
