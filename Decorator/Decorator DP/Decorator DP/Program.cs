using System;

namespace Decorator_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            string userFrom = "Michael";
            string userTo = "Esteban";
            IMail standardMail = new GeneralMail(userFrom, userTo);
            IMail SignatureMail = new SignDecorator(standardMail, "Michael");
            IMail EncryptedMail = new EncrypteDecorator(SignatureMail);
            EncryptedMail.Send();

            Console.ReadLine();
        }
    }
    public interface IMail
    {
        void Send();
    }
    public class GeneralMail : IMail
    {
        private string userFrom;
        private string userTo;
        public GeneralMail(string userfrom, string userto)
        {
            this.userFrom = userfrom;
            this.userTo = userto;
        }
        public void Send()
        {
            Console.WriteLine("The mail is sending from {0} to {1}.", userFrom, userTo);
        }
    }

    public abstract class Decorator : IMail
    {
        private IMail mail;
        public Decorator(IMail mail)
        {
            this.mail = mail;
        }
        public virtual void Send()
        {

            mail.Send();
        }
    }

    public class EncrypteDecorator : Decorator
    {

        public EncrypteDecorator(IMail mail) : base(mail)
        {

        }
        public override void Send()
        {
            base.Send();
            Console.WriteLine(" Encrypted  ");
        }
    }

    public class SignDecorator : Decorator
    {
        private string signature;
        public SignDecorator(IMail mail, string signature) : base(mail)
        {
            this.signature = signature;
        }
        public override void Send()
        {
            base.Send();
            Console.WriteLine(signature + " has signed");
        }
    }


}
