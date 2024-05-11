using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDelivery
{
    class Minibus : Transport
    {
        private int Speed { get; set; }
        private int MaxLoadCapacity { get; set; }
        private int LoadCapacity { get; set; }
        public Minibus(int speed, int MaxLoadCapacity = 1, int LoadCapacity = 0)
        {
            this.Speed = speed;
            this.MaxLoadCapacity = MaxLoadCapacity;
        }

        protected override void Loading()
        {
            throw new NotImplementedException();
        }

        protected override void MakeMove(Queue<Point> queue, Queue<Point> searchedQueue)
        {
            throw new NotImplementedException();
        }

    }
}
