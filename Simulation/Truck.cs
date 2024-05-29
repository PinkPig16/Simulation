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
        private static readonly int height = 12;
        private static readonly int width = 22;
        
        private int Speed { get; set; }
        private int MaxLoadCapacity { get; set; }
        private int LoadCapacity { get; set; }

        public Truck(int speed, int MaxLoadCapacity, int loadCapacity = 0)
        {
            this.Speed = speed;

            this.LoadCapacity = loadCapacity;

            this.MaxLoadCapacity = MaxLoadCapacity;
        }
        public override void Loading()
        {
            throw new NotImplementedException();
        }

        public override Point MakeMove(Entiry entiry)
        {
            int[,] offsets = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
            Queue<Point> queue = new Queue<Point>();
            var pointEntiry = Maps.FindPoint(entiry);
            queue.Enqueue(pointEntiry);
            var searchedQueue = new Queue<Point>();
            while (queue.Count > 0)
            {
                var point = queue.Dequeue();

                if (!searchedQueue.Contains(point))
                {
                    searchedQueue.Enqueue(point);

                    Entiry value;
                    if (Maps.FindEntiry(point, out value))
                    {

                        if (this.LoadCapacity < this.MaxLoadCapacity && typeof(Package) == value.GetType())
                        {
                            int difference = Math.Abs((searchedQueue.First().X - point.X)) + Math.Abs((searchedQueue.First().Y - point.Y));

                            if (difference <= this.Speed)
                            {
                                this.LoadCapacity++;
                                return point;
                            }
                            else
                            {
                                foreach (var item in searchedQueue)
                                {
                                    difference = Math.Abs((item.X - point.X)) + Math.Abs((item.Y - point.Y));
                                    if (difference <= this.Speed && !Maps.FindEntiry(point, out value))
                                    {
                                        return point;
                                    }

                                }
                            }
                        }
                        else if (this.LoadCapacity == this.MaxLoadCapacity && typeof(Delivery) == value.GetType())
                        {
                            int difference = Math.Abs((searchedQueue.Last().X - point.X)) + Math.Abs((searchedQueue.Last().Y - point.Y));

                            if (difference <= this.Speed)
                            {
                                this.LoadCapacity++;
                                Maps.removeEntity(point);
                                return point;
                            }
                            else
                            {
                                foreach (var item in searchedQueue)
                                {
                                    difference = Math.Abs((item.X - point.X)) + Math.Abs((item.Y - point.Y));
                                    if (difference <= this.Speed && !Maps.FindEntiry(point, out value))
                                    {
                                        return point;
                                    }

                                }
                            }

                        }
                    }

                }

                for (int i = 0; i < offsets.GetLength(0); i++)
                {

                    int newX = point.X + offsets[i, 0];
                    int newY = point.Y + offsets[i, 1];

                    if (newX >= 0 && newY >= 0 && newX < height && newY < width)
                    {
                        queue.Enqueue(new Point(newX, newY));
                    }

                }
            }

            return Point.Empty;
        }
    }
}
