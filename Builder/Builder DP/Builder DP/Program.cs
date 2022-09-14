using System;
using System.Collections.Generic;

namespace Builder_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrowserQuery Query = new BrowserQuery();
            //var Result = Query.Add("armut", "5").Add("elma", "7");
            //Console.WriteLine(Result);

            //Jsonx myDictionary = new Jsonx();
            //myDictionary.Add("armut", "5").Add("elma", "7");
            //Console.WriteLine(myDictionary);

            Jsonx query = new Jsonx();
            //BrowserQuery query = new BrowserQuery();
            var result = ConstructionProcess(query);
            Console.WriteLine(result);
        }


        // Director
        public static IRepresentation ConstructionProcess(IRepresentation representation)
        {
            return representation.Add("armut", "5").Add("elma", "7");
        }

        public interface IRepresentation
        {
            IRepresentation Add(string key, string value);
        }

        public class BrowserQuery : IRepresentation
        {
            private string query { get; set; }
            public BrowserQuery()
            {
                query = "";
            }
            public IRepresentation Add(string key, string value)
            {
                if (query == "")
                {
                    query = "?" + key + "=" + value;
                }
                else
                {
                    query = query + "&" + key + "=" + value;
                }
                return this;
            }

            //XYZ

            public override string ToString()
            {
                return query;
            }
        }

        public class Jsonx : IRepresentation
        {
            private string result { get; set; }
            private Dictionary<string, string> dictionary { get; set; }
            public Jsonx()
            {
                dictionary = new Dictionary<string, string>();
                result = "";
            }
            public IRepresentation Add(string key, string value)
            {
                dictionary[key] = value;
                return this;
            }

            public string MyFunc()
            {
                result = "{\n";
                int numberOfElements = dictionary.Count;
                int counter = 1;
                foreach (var item in dictionary)
                {
                    result += "\"" + item.Key + "\"";
                    result += ":";
                    result += "\"" + item.Value + "\"";
                    if (counter != numberOfElements)
                    {
                        result += ",\n";
                    }
                    counter += 1;
                }
                result += "\n}";
                return result;
            }

            public override string ToString()
            {
                var result = this.MyFunc();
                return result;
            }
        }
    }
}
