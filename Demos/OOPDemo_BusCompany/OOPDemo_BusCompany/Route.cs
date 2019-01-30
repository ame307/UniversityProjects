using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo_BusCompany
{
    class Route
    {
        private List<string> cities = new List<string>();
        private List<int> distances = new List<int>();

        public void AddRoute(string city1, string city2, int distance)
        {
            if (cities.Count == 0)
            {
                if (city1.Equals(null))
                    throw new Exception("You can not add null value.");
                cities.Add(city1);
                if (city2.Equals(null))
                    throw new Exception("You can not add null value.");
                cities.Add(city2);
                if (distance == 0)
                    throw new Exception("You can not add null value.");
                distances.Add(distance);
            }
            else
            {
                if (!(cities.Last().Equals(city1)))
                    throw new Exception("You have to give a destination to the previous city.");
                cities.Add(city2);
                distances.Add(distance);
            }

        }

        public double FuelUse(Bus b)
        {
            double sum = 0;
            for (int i = 0; i < distances.Count; i++)
            {
                sum = sum + distances.ElementAt(i);
            }
            return sum / 100 * b.RealConsumption;
        }
    }
}
