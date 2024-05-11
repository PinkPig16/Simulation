using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation;

namespace SimulationDelivery
{
    internal class Maps
    {
        private static readonly Dictionary<Point, Entiry> Map = new Dictionary<Point, Entiry>();

        private static readonly Dictionary<Type, string> typeEntity = new Dictionary<Type, string>
            {
                { typeof(Rock)," \U0001F31A "},
                { typeof(Package)," \U0001F4E6 "},
                { typeof(Minibus)," \U0001F699 "},
                { typeof(Truck)," \U0001F69A "},
                { typeof(Wood)," \U0001F334 "},
                { typeof(Delivery), " \U0001F3E2 "}
            };

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
            int height = Int32.Parse(Simulation.Resource.height());
            int width = Int32.Parse(Simulation.Resource.height());
            for (int i = 0; i < 105; i++)
            {
                Point point = new Point(rnd.Next(height), rnd.Next(width));
                if (i == 0)
                {
                    AddEntiry(point, new Delivery());
                }
                else if(i < 15)
                {
                    AddEntiry(point, new Minibus(rnd.Next(10,15)));
                }
                else if ( i < 30 && i > 15)
                {
                    AddEntiry(point, new Truck(rnd.Next(5,10),rnd.Next(2, 4)));
                }
                else if (i < 80 && i > 30)
                {
                    AddEntiry(point, new Package());
                }
                else if (i < 90 && i > 80)
                {
                    AddEntiry(point, new Wood());
                }
                else if (i < 105 && i > 90)
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
                    if (Map.ContainsKey(point))
                    {
                        Type objType = Map[point].GetType();
                        if (typeEntity.ContainsKey(objType))
                        {
                            Console.Write(typeEntity[objType]);
                        }
                    } else
                    {
                        Console.Write(" .. ");
                    }
                    
                }
                Console.WriteLine("\n");
            }
        }
        public static bool FindEntiry(Point point, out Entiry value)
        {
            return Map.TryGetValue(point, out value);

        }
    }
}
