using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDelivery
{
    class Truck : Transport
    {
        private int Speed { get; set; }
        private int MaxLoadCapacity { get; set; }
        private int LoadCapacity { get; set; }

        public Truck(int speed, int MaxLoadCapacity, int loadCapacity = 0)
        {
            this.Speed = speed;

            this.LoadCapacity = loadCapacity;

            this.MaxLoadCapacity = MaxLoadCapacity;
        }
        protected override void Loading()
        {
            throw new NotImplementedException();
        }

        protected override Point MakeMove(Queue<Point> queue, Queue<Point> searchedQueue)
        {
            int[,] offsets = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            int height = Int32.Parse(Simulation.Resource.height());
            int width = Int32.Parse(Simulation.Resource.width());

            while (queue.Count > 0)
            {
                var point = queue.Dequeue();

                if (!searchedQueue.Contains(point))
                {
                    searchedQueue.Enqueue(point);

                    Entiry value;
                    if (Maps.FindEntiry(point, out value))
                    {
                        int difference = Math.Abs((searchedQueue.Last().X - point.X)) + Math.Abs((searchedQueue.Last().Y - point.Y));
                        if (this.LoadCapacity == this.MaxLoadCapacity && typeof(Package) == value.GetType())
                        {
                            if (difference <= this.Speed)
                                return point;
                        }
                        else
                        {
                            
                        }
                    }
                    else if (typeof(Package) == value.GetType())
                    {
                        return point;
                    }
                }

                for (int i = 0; i < offsets.GetLength(0); i++)
                {

                    int newX = point.X + offsets[i, 0];
                    int newY = point.Y + offsets[i, 1];

                    if (newX >= 0 && newY >= 0 && newX < height && newY < width)
                    {

                    }

                }
            }
        }
    }
}
