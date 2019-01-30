using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public class Purchase
    {
        private const int motherBoard = 100;
        private const int cpu = 120;
        private const int winchester = 80;

        private const double discount2 = 1.02;
        private const double discount3 = 1.03;
        private const double discount5 = 1.05;

        public int PurchaseA(int motherBoardPC, int cpuPC, int winchesterPC)
        {
            int s = motherBoardPC * motherBoard + cpuPC * cpu + winchesterPC * winchester;
            return s;
        }

        public int PurchaseB(int motherBoardPC, int cpuPC, int winchesterPC)
        {
            double increase = 1.1;
            int s = (int)(motherBoardPC * (motherBoard * increase) + cpuPC * (cpu * increase) + winchesterPC * (winchester * increase));
            return s;
        }

        public int PurchaseC(int motherBoardPC, int cpuPC, int winchesterPC)
        {
            double increase = 1.3;
            int s = (int)(motherBoardPC * (motherBoard * increase) + cpuPC * (cpu * increase) + winchesterPC * (winchester * increase));
            return s;
        }

        public int Discount(int s, int pc)
        {
            int sd = 0;

            if (s > 10000)
                sd = (int)(s * discount5);

            if (sd == 0 && pc > 30)
            {
                if (pc <= 50)
                    sd = (int)(s * discount2);
                else
                    sd = (int)(s * discount3);
            }

            return sd;

        }

    }
}
