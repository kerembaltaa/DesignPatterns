using System;

namespace Chain_Of_Responsibility_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            var withdraw = new Withdraw("a6e193dc-cdbb-4f09-af1a-dea307a9ed15", 480000, "TRY", "TR681223154132432141412");

            Calisan sorumlu = new Sorumlu();
            Calisan yonetici = new Yonetici();
            Calisan grupYoneticisi = new GrupYoneticisi();
            Calisan direktor = new Direktor();

            sorumlu.SiradakiOnayciyiSetEt(yonetici);
            yonetici.SiradakiOnayciyiSetEt(grupYoneticisi);
            grupYoneticisi.SiradakiOnayciyiSetEt(direktor);


            sorumlu.ProcessRequest(withdraw);

            Console.ReadKey();
        }
    }
    public abstract class Calisan
    {
        protected Calisan SıradakiOnayci;

        public void SiradakiOnayciyiSetEt(Calisan employee)
        {
            this.SıradakiOnayci = employee;
        }

        public abstract void ProcessRequest(Withdraw req);
    }
    public class Direktor : Calisan
    {
        public override void ProcessRequest(Withdraw req)
        {
            if (req.Amount <= 750000)
            {
                Console.WriteLine("{0} tarafından para çekme işlemi onaylandı #{1} TL", this.GetType().Name, req.Amount);
            }
            else
            {
                throw new Exception($"Limit banka günlük işlem limitini aştığından para çekme işlemi #{req.Amount} TL onaylanmadı.");
            }
        }
    }
    public class GrupYoneticisi : Calisan
    {
        public override void ProcessRequest(Withdraw req)
        {
            if (req.Amount <= 150000)
            {
                Console.WriteLine("{0} tarafından para çekme işlemi onaylandı #{1} TL", this.GetType().Name, req.Amount);
            }
            else if (SıradakiOnayci != null)
            {
                Console.WriteLine("{0} TL işlem tutarı {1} max. limitini aştığından işlem yöneticiye gönderildi.", req.Amount, this.GetType().Name);

                SıradakiOnayci.ProcessRequest(req);
            }
        }
    }
    public class Yonetici : Calisan
    {
        public override void ProcessRequest(Withdraw req)
        {
            if (req.Amount <= 70000)
            {
                Console.WriteLine("{0} tarafından para çekme işlemi onaylandı #{1} TL", this.GetType().Name, req.Amount);
            }
            else if (SıradakiOnayci != null)
            {
                Console.WriteLine("{0} TL işlem tutarı {1} max. limitini aştığından işlem yöneticiye gönderildi.", req.Amount, this.GetType().Name);

                SıradakiOnayci.ProcessRequest(req);
            }
        }
    }
    public class Sorumlu : Calisan
    {
        public override void ProcessRequest(Withdraw req)
        {
            if (req.Amount <= 40000)
            {
                Console.WriteLine("{0} tarafından para çekme işlemi onaylandı #{1}", this.GetType().Name, req.Amount);
            }
            else if (SıradakiOnayci != null)
            {
                Console.WriteLine("{0} TL işlem tutarı {1} max. limitini aştığından işlem yöneticiye gönderildi.", req.Amount, this.GetType().Name);

                SıradakiOnayci.ProcessRequest(req);
            }
        }
    }

    public class Withdraw
    {
        public string CustomerId { get; }
        public decimal Amount { get; }
        public string CurrencyType { get; }
        public string SoruceAccountId { get; }

        public Withdraw(string customerId, decimal amount, string currencyType, string soruceAccountId)
        {
            CustomerId = customerId;
            Amount = amount;
            CurrencyType = currencyType;
            SoruceAccountId = soruceAccountId;
        }
    }

}
