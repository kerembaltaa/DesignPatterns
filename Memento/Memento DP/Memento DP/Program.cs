using System;

namespace Memento_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWorld zulu = new GameWorld { Name = "Zulu", Population = 1000 };

            Console.WriteLine(zulu.ToString());

            GameWorldCareTaker taker = new GameWorldCareTaker();
            taker.World = zulu.Save(); //zulunun o anki halini sakla

            zulu.Population += 999;
            Console.WriteLine(zulu.ToString());

            zulu.Undo(taker.World); //eski dünyayi geri yükle

            Console.WriteLine(zulu.ToString());

            Console.ReadKey();
        }
        class GameWorld
        {
            public string Name { get; set; }
            public long Population { get; set; }

            //Yeni bir gameworldmomento nesnesi örnekleyip ona orginator classına ait nesnenin ilgili özelliklerini atar.
            public GameWorldMemento Save()
            {
                return new GameWorldMemento { Name = this.Name, Population = this.Population }; //calisma zamanındaki özelllikleri alır.
            }

            //o anda gelen orginator nesnesinin ilgili özelliklerini set eder
            public void Undo(GameWorldMemento memento)
            {
                this.Name = memento.Name;
                this.Population = memento.Population;
            }

            public override string ToString()
            {
                return String.Format("{0} dünyasında {1} insan var", Name, Population);
            }
        }
        class GameWorldMemento
        {
            public string Name { get; set; }
            public long Population { get; set; }
        }
        class GameWorldCareTaker
        {
            public GameWorldMemento World { get; set; } //mementoyu döner.
        }

    }
}
