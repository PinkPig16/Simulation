using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDelivery
{
    internal class Render
    {
        public static async void removeEntity(Point from)
        {
            Thread.Sleep(500);
            Console.SetCursorPosition(from.Y*4, from.X*2);
            Console.Write(' ');
        }

        public static void TransportMove(Point from, Entiry transport)
        {
            Console.SetCursorPosition(from.Y * 4, from.X * 2);
            Thread.Sleep(500);
            if (transport is Truck)
            {
                Console.Write(Maps.getTypeTruck());
            } else if (transport is Minibus)
            {
                Console.Write(Maps.getTypeMinibus());
            }
            
        }
        public static void initConsole()
        {

            Console.Title = "Simulation";
            // Console.SetWindowSize(21*4,9*2);
            Console.BufferHeight = 30;
            Console.Clear();
            Console.CursorVisible = false;
        }
    }
}
