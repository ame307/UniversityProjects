using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo_BusCompany
{
    class Bus
    {

        private string _brand;

        public string Brand
        {
            get { return _brand; }
            set
            {
                if (value.Length < 2)
                    throw new Exception("The brand must be at least 2 characters long.");

                _brand = value;
            }
        }

        private string _model;

        public string Model
        {
            get { return _model; }
            set
            {
                if (value.Length < 2)
                    throw new Exception("The model must be at least 2 characters long.");

                _model = value;
            }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }


        private int _consumption;

        public int Consumption
        {
            get { return _consumption; }
            set { _consumption = value; }
        }

        public double _realConsumption;

        public double RealConsumption
        {
            get { return _realConsumption; }
            set { _realConsumption = value; }
        }

        public Bus(string brand, string model, int age, int consumption)
        {
            this.Brand = brand;
            this.Model = model;
            this.Age = age;
            this.Consumption = consumption;
            this.RealConsumption = consumption * (1 + (double)(age) / 20);
        }

    }
}
