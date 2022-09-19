using System;
using System.Collections.Generic;

namespace Command_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.Hesapla('+', 100);
            kullanici.Hesapla('-', 50);
            kullanici.Hesapla('*', 10);
            kullanici.Hesapla('/', 2);
            kullanici.GeriAl(4);
            kullanici.IleriAl(3);
            Console.ReadKey();
        }
    }
    abstract class Komut
    {
        public abstract void Uygula();
        public abstract void Uygulama();

    }
    class HesapKomutu : Komut
    {
        private char _islemTuru;
        private int _islenen;
        private Hesap _hesap;
        public HesapKomutu(Hesap hesap, char @islemTuru, int islenen)
        {
            this._hesap = hesap;
            this._islemTuru = @islemTuru;
            this._islenen = islenen;
        }
        public char IslemTuru
        {
            set { _islemTuru = value; }
        }
        public int Islenen
        {
            set { _islenen = value; }
        }
        public override void Uygula()
        {
            _hesap.Islem(_islemTuru, _islenen);
        }
        public override void Uygulama()
        {
            _hesap.Islem(GeriAl(_islemTuru), _islenen);
        }
        private char GeriAl(char @islemTuru)
        {
            switch (@islemTuru)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default:
                    throw new
            ArgumentException("@islemTuru");
            }
        }
    }
    class Hesap
    {
        private int _mevcut = 0;
        public void Islem(char @islemTuru, int islenen)
        {
            switch (@islemTuru)
            {
                case '+': _mevcut += islenen; break;
                case '-': _mevcut -= islenen; break;
                case '*': _mevcut *= islenen; break;
                case '/': _mevcut /= islenen; break;
            }
            Console.WriteLine("Mevcut değer = {0,3} (İşlem türü: {1}, İşlenen: {2})", _mevcut, @islemTuru, islenen);

        }
    }
    class Kullanici
    {
        private Hesap _hesap = new Hesap();
        private List<Komut> _komutlar = new List<Komut>();
        private int _mevcut = 0;
        public void IleriAl(int seviye)
        {
            Console.WriteLine("\n---- İleri Al {0} seviye ", seviye);
            for (int i = 0; i < seviye; i++)
            {
                if (_mevcut < _komutlar.Count - 1)
                {
                    Komut komut = _komutlar[_mevcut++];
                    komut.Uygula();
                }
            }
        }
        public void GeriAl(int seviye)
        {
            Console.WriteLine("\n---- Geri Al {0} seviye ", seviye);
            for (int i = 0; i < seviye; i++)
            {
                if (_mevcut > 0)
                {
                    Komut komut = _komutlar[--_mevcut] as Komut;
                    komut.Uygulama();
                }
            }
        }
        public void Hesapla(char @islemTuru, int islenen)
        {
            Komut komut = new HesapKomutu(_hesap, @islemTuru, islenen);
            komut.Uygula();
            _komutlar.Add(komut);
            _mevcut++;
        }
    }
}
