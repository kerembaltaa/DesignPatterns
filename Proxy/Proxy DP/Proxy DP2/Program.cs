using System;
using System.Collections.Generic;

namespace Proxy_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            UrunServisiProxy urunServisiProxy = new UrunServisiProxy();
            var liste = urunServisiProxy.urunAdlariniGetir();
            liste.ForEach(Console.WriteLine);
        }
    }
    public interface IUrunServisi
    {
        List<string> urunAdlariniGetir();
    }
    public class UrunServisi : IUrunServisi
    {
        public List<string> urunAdlariniGetir()
        {
            //veritabannına bağlanarak ilgili ürünleri aldığımızı ve bu sonucu döndürdüğümüzü varsayın
            return new List<string>() { "Saat", "Gömlek", "Tirbuşon" };
        }
    }
    public class UrunServisiProxy : IUrunServisi
    {
        //Dikkat: işi yapacak olan gerçek nesne, bir "alan" olarak tanımlandı:
        private UrunServisi urunServisi = null;
        public List<string> urunAdlariniGetir()
        {
            //proxy nesnemizin bu metodu, gerçek nesnenin aynı metodunu çağıracak: 
            urunServisi = new UrunServisi();
            return urunServisi.urunAdlariniGetir();
        }
    }

}
