using System;

namespace Abstract_Factory_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IFootballFactory germany = new BundesLigaFactory();
            IFootballFactory spain = new LaLigaFactory();
            IFootballFactory italy = new SerieAFactory();
            FootballWorld footballWorld = new FootballWorld(italy);
            Console.WriteLine(footballWorld.GetFootballTeamColor());
            Console.WriteLine(footballWorld.GetTopScorer());
            Console.ReadLine();
        }
    }

    public interface IPlayer
    {
        string GetTopScorer();
    }

    public interface ITeam
    {
        string GetTeamColor();
    }

    public interface IFootballFactory
    {
        ITeam CreateTeam();
        IPlayer CreatePlayer();
    }

    public class BundesLigaFactory : IFootballFactory
    {
        public ITeam CreateTeam()
        {
            return new BorussiaDortmund();
        }

        public IPlayer CreatePlayer()
        {
            return new BundesligaPlayer();
        }
    }

    public class LaLigaFactory : IFootballFactory
    {
        public ITeam CreateTeam()
        {
            return new RealMadrid();
        }

        public IPlayer CreatePlayer()
        {
            return new LaLigaPlayer();
        }
    }

    public class SerieAFactory : IFootballFactory
    {
        public ITeam CreateTeam()
        {
            return new Juventus();
        }

        public IPlayer CreatePlayer()
        {
            return new SerieAPlayer();
        }
    }

    public class BorussiaDortmund : ITeam
    {
        public string GetTeamColor()
        {
            return "Black and Yellow";
        }
    }

    public class Juventus : ITeam
    {
        public string GetTeamColor()
        {
            return "Black and White";
        }
    }

    public class RealMadrid : ITeam
    {
        public string GetTeamColor()
        {
            return "Blue and White";
        }
    }

    public class BundesligaPlayer : IPlayer
    {
        public string GetTopScorer()
        {
            return "Robert Lewandowski";
        }
    }

    public class LaLigaPlayer : IPlayer
    {
        public string GetTopScorer()
        {
            return "Lionel Messi";
        }
    }

    public class SerieAPlayer : IPlayer
    {
        public string GetTopScorer()
        {
            return "Cristiano Ronaldo";
        }
    }

    public class FootballWorld
    {
        private readonly ITeam _team;
        private readonly IPlayer _teamScorer;

        public FootballWorld(IFootballFactory factory)
        {
            _team = factory.CreateTeam();
            _teamScorer = factory.CreatePlayer();
        }

        public string GetFootballTeamColor()
        {
            return _team.GetTeamColor();
        }

        public string GetTopScorer()
        {

            return _teamScorer.GetTopScorer();
        }
    }
}
