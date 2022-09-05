using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDP2
{
    class TransportationShip : Interface1
    {
        private string name;
        private string company;
        private int velocity;
        private int max_weight;

        public TransportationShip(string name, string company, int velocity, int max_weight)
        {
            this.name = name;
            this.company = company;
            this.velocity = velocity;
            this.max_weight = max_weight;
        }

        public string getName()
        {
            return name;
        }

        public string getCompany()
        {
            return company;
        }


        public int getVelocity()
        {
            return velocity;
        }

        public int getMaxWeight()
        {
            return max_weight;
        }


        public override string ToString()
        {
            return "Name= " + name + ", Company= " + company + ", Velocity= "
                + velocity + "km/h" + ", Max Weight= " + max_weight + "tons";
        }

    }
}
