using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDP2
{
    interface IShip
    {
        string getName();
        string getCompany();
        int getVelocity();
        int getMaxWeight();
    }
}
