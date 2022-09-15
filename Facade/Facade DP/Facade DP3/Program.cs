using System;
using System.Collections.Generic;
using System.Linq;

namespace Facade_DP3
{
    class Program
    {
        static void Main(string[] args)
        {
            SiparisFacade siparisFacade = new SiparisFacade();
            List<SepettekiUrun> urunler = new List<SepettekiUrun>
            {
                new SepettekiUrun{ Id=1, UrunAdi="X", Fiyat=5, Adet=2},
                new SepettekiUrun{ Id=2, UrunAdi="Y", Fiyat=8, Adet=3},
                new SepettekiUrun{ Id=3, UrunAdi="Z", Fiyat=10, Adet=1},
                new SepettekiUrun{ Id=4, UrunAdi="Q", Fiyat=20, Adet=1}
            };
            siparisFacade.SiparisVer("Mehmet", "Aras Kargo", urunler);
            Console.ReadLine();
        }
    }
    public class Musteri
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
    public class SepettekiUrun
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
    }
    public class KargoSirketi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Iletisim { get; set; }
    }
    public class SiparisIslemleri
    {
        public int SiparisEkle(DateTime siparisTarihi, Musteri musteri, KargoSirketi kargoSirketi)
        {
            Console.WriteLine("{0} tarihinde {1} isimli müşteri siparişi eklendi. Seçilen kargo şirketi:{2} "
                , siparisTarihi.ToString(), musteri.Ad, kargoSirketi.Ad);
            return 1;
        }
    }

    public class SiparisDetaylari
    {
        public void SiparisDetaylariniEkle(int siparisId, List<SepettekiUrun> urunler)
        {
            Console.WriteLine("{0} numaralı siparişte alınan ürünler:", siparisId);
            Console.WriteLine("...............................");
            urunler.ForEach(u => Console.WriteLine("{0} ürününden {1} adet alındı. Ara toplam:{2}", u.UrunAdi, u.Adet, u.Adet * u.Fiyat));
            Console.WriteLine("...............................");
            var toplam = urunler.Sum(x => x.Fiyat * x.Adet);
            Console.WriteLine("Toplam:{0}", toplam);

        }
    }


    public class UrunIslemleri
    {
        public void StokGuncelle(int urunId, int adet)
        {
            Console.WriteLine("{0} id'li ürünün stoğundan, {1} adet düşüldü.", urunId, adet);
        }
    }
    public class SiparisFacade
    {
        private Musteri musteri;
        private KargoSirketi kargoSirketi;
        private UrunIslemleri urunIslemleri = new UrunIslemleri();
        private SiparisIslemleri siparisIslemleri = new SiparisIslemleri();
        private SiparisDetaylari siparisDetaylari = new SiparisDetaylari();


        public void SiparisVer(string musteriAdi, string secilenKargoSirketi, List<SepettekiUrun> urunler)
        {
            musteri = new Musteri { Ad = musteriAdi };
            kargoSirketi = new KargoSirketi { Ad = secilenKargoSirketi };
            int siparisId = siparisIslemleri.SiparisEkle(DateTime.Now, musteri, kargoSirketi);
            siparisDetaylari.SiparisDetaylariniEkle(siparisId, urunler);
            urunler.ForEach(u => urunIslemleri.StokGuncelle(u.Id, u.Adet));
            Console.WriteLine();
            Console.WriteLine("İşlem tamamlandı");

        }

    }
}
