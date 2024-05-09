using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDelivery
{
    internal class Maps
    {
        private static readonly Dictionary<Point, Entiry> Map = new Dictionary<Point, Entiry>();

        public  void AddEntiry(Point point, Entiry entiry)
        {
            if (!Map.ContainsKey(point))
            {
                Map.Add(point, entiry);
            }
        }

        public void FillMap()
        {
            Random rnd = new Random();

            for (int i = 0; i < 105; i++)
            {
                Point point = new Point(rnd.Next(10), rnd.Next(22));
                if(i < 15)
                {
                    AddEntiry(point, new Minibus(rnd.Next(10,15)));
                }
                if ( i < 30 && i > 15)
                {
                    AddEntiry(point, new Truck(rnd.Next(2, 4),rnd.Next(5,10)));
                }
                if (i < 80 && i > 30)
                {
                    AddEntiry(point, new Package());
                }
                if (i < 90 && i > 80)
                {
                    AddEntiry(point, new Wood());
                }
                if (i < 105 && i > 90)
                {
                    AddEntiry(point, new Rock());
                }
            }
        }
        public void PrintMap()
        {
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < 10;  i++)
            {
                for(int j = 0; j < 22; j++)
                {
                    Point point = new(i, j);
                    if(Map.ContainsKey(point))
                    {
                        if (Map[point] is Rock)
                        {
                            Console.Write(" \U0001F31A ");
                        } else if (Map[point] is Package)
                        {
                            Console.Write(" \U0001F4E6 ");
                        } else if (Map[point] is Wood)
                        {
                            Console.Write(" \U0001F334 ");
                        } else if (Map[point] is Truck)
                        {
                            Console.Write(" \U0001F69A ");
                        } else if (Map[point] is Minibus)
                        {
                            Console.Write(" \U0001F699 ");
                        }
                        
                    } else
                    {
                        Console.Write(" .. ");
                    }
                    
                }
                Console.WriteLine("\n");
            }
        }
    }
}
