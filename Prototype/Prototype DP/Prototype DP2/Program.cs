using System;

namespace Prototype_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Oyun o1 = new Oyun(3, "Oyun1", "Tür1", true);
            Console.WriteLine(o1.OyunID+" "+o1.OyunAdi+" "+o1.OyunTuru);
            Oyun o2 = (Oyun)o1.Clone();
            //o2.OyunID = 4;
            //o2.OyunAdi = "Oyun1.2";
            Console.WriteLine(o2.OyunID + " " + o2.OyunAdi + " " + o2.OyunTuru);
            
            if (o1.Equals(o2))
            {
                Console.WriteLine("Eşit");
            }
            else
            {
                Console.WriteLine("Değil");
            }

            Console.Read();
        }
    }

    //class Oyun
    //{
    //    public int OyunID { get; set; }
    //    public string OyunAdi { get; set; }
    //    public string OyunTuru { get; set; }
    //    public bool Durum { get; set; }
    //    public Oyun(int OyunID, string OyunAdi, string OyunTuru, bool Durum)
    //    {
    //        this.OyunID = OyunID;
    //        this.OyunAdi = OyunAdi;
    //        this.OyunTuru = OyunTuru;
    //        this.Durum = Durum;
    //    }
    //}

    abstract class PrototypeOyun
    {
        public abstract PrototypeOyun Clone();
    }

    class Oyun : PrototypeOyun
    {
        public int OyunID { get; set; }
        public string OyunAdi { get; set; }
        public string OyunTuru { get; set; }
        public bool Durum { get; set; }
        public Oyun(int OyunID, string OyunAdi, string OyunTuru, bool Durum)
        {
            this.OyunID = OyunID;
            this.OyunAdi = OyunAdi;
            this.OyunTuru = OyunTuru;
            this.Durum = Durum;
        }

        public override PrototypeOyun Clone()
        {
            return this.MemberwiseClone() as PrototypeOyun;
        }
    }
}
