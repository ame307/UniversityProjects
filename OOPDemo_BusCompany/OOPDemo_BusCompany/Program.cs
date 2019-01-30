using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo_BusCompany
{
    class Program
    {
        static void Main(string[] args)
        {

            BusCompany Volan = new BusCompany();

            Bus bus1 = new Bus("MAN", "A11", 5, 34);
            Bus bus2 = new Bus("VOLVO", "B22", 1, 26);
            Bus bus3 = new Bus("IKARUS", "C33", 25, 40);

            Volan.AddBus(bus1);
            Volan.AddBus(bus2);
            Volan.AddBus(bus3);

            Route routes = new Route();

            routes.AddRoute("Szentgyörgy", "Brassó", 36);
            routes.AddRoute("Brassó", "Bukarest", 125);
            routes.AddRoute("Bukarest", "Konstanca", 110);

            double min = routes.FuelUse(Volan.ElementAt(0));
            Bus best = Volan.ElementAt(0);
            for (int i = 1; i < Volan.Count(); i++)
            {
                if (routes.FuelUse(Volan.ElementAt(i)) < min)
                {
                    min = routes.FuelUse(Volan.ElementAt(i));
                    best = Volan.ElementAt(i);
                }

            }
            Console.WriteLine("This is the most economical bus to the trip:");
            Console.WriteLine("The bus brand : " + best.Brand + "\nThe bus model: " + best.Model + "\nConsumption: " + best.Consumption + "l/100km\nReal consumption: " + best.RealConsumption + "l/100km");

            Console.ReadKey();

        }
    }
}
