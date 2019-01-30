using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo_BusCompany
{
    class BusCompany
    {
        private List<Bus> buses = new List<Bus>();

        public void AddBus(Bus b)
        {
            if (b == null)
                throw new Exception("You can not add null value.");
            int y = 0;
            while (y < buses.Count && !(buses.ElementAt(y).Brand.Equals(b.Brand) && buses.ElementAt(y).Model.Equals(b.Model) && b.Age > buses.ElementAt(y).Age))
            {
                y++;
            }
            if (y < buses.Count)
            {
                throw new Exception("This bus is already added to the company.");
            }
            else
            {
                buses.Add(b);
            }
        }

        public Bus ElementAt(int i)
        {
            return this.buses.ElementAt(i);
        }

        public int Count()
        {
            return buses.Count;
        }
    }
}
