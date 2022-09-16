using System;
using System.Collections.Generic;

namespace Flyweight_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            IGalaxy star = GalaxyFactory.GetPlanetoryObject(PlanetaryType.Star);
            star.SetBrightness(10);
            star.SetPosition(20, 80);
            Console.WriteLine(star);
            IGalaxy planet = GalaxyFactory.GetPlanetoryObject(PlanetaryType.Planet);
            planet.SetBrightness(67);
            planet.SetPosition(120, 85);
            Console.WriteLine(planet);
            IGalaxy star2 = GalaxyFactory.GetPlanetoryObject(PlanetaryType.Star);
            star2.SetBrightness(65);
            star2.SetPosition(67, 23);
            Console.WriteLine(star2);
            Console.WriteLine();
            int counter = GalaxyFactory.count;
            Console.WriteLine("Number of objects: "+counter);

            
        }
    }
    public interface IGalaxy
    {
        void SetBrightness(double brightness);
        void SetPosition(int x, int y);
    }
    public class Ellipse
    {
        private readonly int height;
        private readonly int width;
        private readonly string color;

        public Ellipse(int height, int width, string color)
        {
            this.height = height;
            this.width = width;
            this.color = color;
        }
    }
    public enum PlanetaryType
    {
        Star,
        Planet
    }
    public class Planet : IGalaxy
    {
        public static Ellipse StarShape = new Ellipse(30, 30, "red"); // Intrinsic State

        // These are the extrinsic states
        int positionX;
        int positionY;
        double brightness;

        public void SetBrightness(double brightness)
        {
            this.brightness = brightness;
        }

        public void SetPosition(int x, int y)
        {
            positionX = x;
            positionY = y;
        }

        public override string ToString()
        {
            return string.Format($"A Planet at located at [{positionX},{positionY}] coordinate and is having a brigtness of [{brightness}]%");
        }
    }
    public class Star : IGalaxy
    {
        public static Ellipse StarShape = new Ellipse(10, 10, "blue"); // Intrinsic State

        // These are the extrinsic states
        int positionX;
        int positionY;
        double brightness;

        public void SetBrightness(double brightness)
        {
            this.brightness = brightness;
        }

        public void SetPosition(int x, int y)
        {
            positionX = x;
            positionY = y;
        }

        public override string ToString()
        {
            return string.Format($"A Star at [{positionX},{positionY}] coordinate and is shining with [{brightness}]% brightness");
        }
    }
    public class GalaxyFactory
    {
        private static Dictionary<PlanetaryType, IGalaxy> planetoryObjects = new Dictionary<PlanetaryType, IGalaxy>();
        public static int count;
        public static IGalaxy GetPlanetoryObject(PlanetaryType planetoryObject)
        {
            if (planetoryObjects.ContainsKey(planetoryObject)) { 
                count = planetoryObjects.Count;
            return planetoryObjects[planetoryObject]; }

            else
            {
                IGalaxy NewObject = null;
                if (planetoryObject == PlanetaryType.Star)
                {
                    NewObject = new Star();
                    planetoryObjects.Add(PlanetaryType.Star, NewObject);
                    count = planetoryObjects.Count;
                }
                else
                {
                    NewObject = new Planet();
                    planetoryObjects.Add(PlanetaryType.Planet, NewObject);
                    count = planetoryObjects.Count;
                }
                return NewObject;
            }
        }
    }
}
