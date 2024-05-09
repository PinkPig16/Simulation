
using SimulationDelivery;
using System.Drawing;
using System.Text;

internal class Simulation
{
    static void Main(string[] args)
    {
        Maps maps = new Maps();

        maps.FillMap();
        
        maps.PrintMap();

    }
}