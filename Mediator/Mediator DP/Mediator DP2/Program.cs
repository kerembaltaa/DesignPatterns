using System;

namespace Mediator_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Nakliye nakliye = new Nakliye();
            XFirma xfirma = new XFirma(nakliye);
            YFirma yfirma = new YFirma(nakliye);
            ZFirma zfirma = new ZFirma(nakliye);

            nakliye.XFirma = xfirma;
            nakliye.YFirma = yfirma;
            nakliye.ZFirma = zfirma;

            xfirma.NakliyeyeBasla();
        }
    }
    public interface INakliye
    {
        void MaliDevret(Firma firma);
    }
    public abstract class Firma
    {
        protected INakliye _nakliye;

        protected Firma(INakliye nakliye)
        {
            _nakliye = nakliye;
        }
        public abstract void NakliyeyeBasla();
    }
    public class XFirma : Firma
    {
        public XFirma(INakliye nakliye) : base(nakliye)
        {
        }
        public override void NakliyeyeBasla()
        {
            Console.WriteLine("Iğdır'dan eşyalar yüklendi.");
            _nakliye.MaliDevret(this);
        }
    }
    public class YFirma : Firma
    {
        public YFirma(INakliye nakliye) : base(nakliye)
        {
        }
        public override void NakliyeyeBasla()
        {
            Console.WriteLine("Sivas'tan eşyalar yüklendi.");
            _nakliye.MaliDevret(this);
        }
    }
    public class ZFirma : Firma
    {
        public ZFirma(INakliye nakliye) : base(nakliye)
        {
        }
        public override void NakliyeyeBasla()
        {
            Console.WriteLine("Ankara'dan eşyalar yüklendi.");
            _nakliye.MaliDevret(this);
        }
    }
    public class Nakliye : INakliye
    {
        XFirma _xfirma;
        YFirma _yfirma;
        ZFirma _zfirma;
        public XFirma XFirma { set => _xfirma = value; }
        public YFirma YFirma { set => _yfirma = value; }
        public ZFirma ZFirma { set => _zfirma = value; }
        public void MaliDevret(Firma firma)
        {
            if (firma is XFirma)
            {
                Console.WriteLine("Eşyalar Sivas'ta tekrar nakledilmek üzere indirildi.\n");
                _yfirma.NakliyeyeBasla();
            }
            else if (firma is YFirma)
            {
                Console.WriteLine("Eşyalar Ankara'da tekrar nakledilmek üzere indirildi.\n");
                _zfirma.NakliyeyeBasla();
            }
            else
                Console.WriteLine("Eşyalar Edirne'ye vardı.");
        }
    }

}
