using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDelivery
{
    class Minibus : Transport
    {
        private int Speed { get; set; }
        private int LoadCapacity { get; set; } = 1;

        public Minibus(int speed)
        {
            this.Speed = speed;
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
