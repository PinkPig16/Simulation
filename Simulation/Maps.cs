
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace SimulationDelivery
{
    internal class Maps
    {
        private int height { get; set; } = 12;
        private int width { get; set; } = 22;

        private static  Dictionary<Point, Entiry> Map = new Dictionary<Point, Entiry>();

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
            int height = this.height;
            int width =  this.width;
            for (int i = 0; i < 105; i++)
            {
                Point point = new Point(rnd.Next(height), rnd.Next(width));
                if (i == 0)
                {
                    AddEntiry(point, new Delivery());
                }
                else if (i < 30)
                {
                    if (i % 2 == 0)
                    {
                        AddEntiry(point, new Minibus(rnd.Next(10, 15)));
                    } else
                    {
                        AddEntiry(point, new Truck(rnd.Next(5, 10), rnd.Next(2, 4)));
                    }                    
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

            for (int i = 0; i < 12;  i++)
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
        public static Dictionary<Point, Entiry> getMap()
        {
            return Map;
        }
        public static void removeEntity(Point fromCell)
        {
            Map.Remove(fromCell);
            Render.removeEntity(fromCell);
        }
        public static List<Entiry> getTransports()
        {
            return Map.Where(item => item.Value is Transport).Select(item => item.Value).ToList();
        }
        public static List<Entiry> getPackage()
        {
            return Map.Where(item => item.Value is Package).Select(item => item.Value).ToList();
        }

        public static int PackageCount()
        {
            return Map.Where(item => item.Value is Package).Count();
        }
        public static Point FindPoint(Entiry entiry)
        {
            return Map.FirstOrDefault(x => x.Value == entiry).Key;
            
        }
        public static void AddEntity(Point point, Entiry entiry)
        {
            Map.Add(point, entiry);
        }
        public static void ChangeEntity(Point point, Entiry entiry)
        {
            if (Map.ContainsKey(point))
            {
                Map[point] = entiry;
                Render.TransportMove(point, entiry);
            }
        }
        public static string getTypeTruck()
        {
         
            return typeEntity[(typeof(Truck))];
        }
        public static string getTypeMinibus()
        {
            return typeEntity[(typeof(Minibus))];
        }

    }
}
