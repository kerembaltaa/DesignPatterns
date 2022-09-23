using System;

namespace Strategy_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "<app><config><sqlConnection>data....</sqlConnection></config></app>";

            Encrypter enc1 = new Encrypter(new TripleDesEncrypter());
            string encryptedStr = enc1.Encrypt(str);
            string decryptedStr = enc1.Decyrpt(str);

            enc1 = new Encrypter(new RijndaelEncrypter());
            encryptedStr = enc1.Encrypt(str);
            decryptedStr = enc1.Decyrpt(str);
        }
    }
    // Strategy type
    interface IEncrypter
    {
        string Encrypt(string obj);
        string Decyrpt(string obj);
    }

    // ConcreteStrategy type 1
    class RijndaelEncrypter
        : IEncrypter
    {
        #region IEncrypter Members

        public string Encrypt(string obj)
        {
            Console.WriteLine("obj için Rijndael şifreleme");
            return obj;
        }

        public string Decyrpt(string obj)
        {
            Console.WriteLine("obj için Rijndael ters şifreleme");
            return obj;
        }

        #endregion
    }

    // ConcreteStrategy type 1
    class TripleDesEncrypter
        : IEncrypter
    {
        #region IEncrypter Members

        public string Encrypt(string obj)
        {
            Console.WriteLine("obj için TripleDES şifreleme");
            return obj;
        }

        public string Decyrpt(string obj)
        {
            Console.WriteLine("obj için TripleDES ters şifreleme");
            return obj;
        }

        #endregion
    }

    // Context Type
    class Encrypter
    {
        IEncrypter _enc = null;

        public Encrypter(IEncrypter enc)
        {
            _enc = enc;
        }

        public string Encrypt(string obj)
        {
            return _enc.Encrypt(obj);
        }
        public string Decyrpt(string obj)
        {
            return _enc.Decyrpt(obj);
        }
    }
}
