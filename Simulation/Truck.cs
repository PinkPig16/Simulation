using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDelivery
{
    class Truck : Transport
    {
        private int Speed { get; set; }
        private int LoadCapacity { get; set; }
        public Truck(int speed, int loadCapacity)
        {
            this.Speed = speed;

            this.LoadCapacity = loadCapacity;
        }
        protected override void Loading()
        {
            throw new NotImplementedException();
        }

        protected override void MakeMove()
        {
            throw new NotImplementedException();
        }
    }
}
