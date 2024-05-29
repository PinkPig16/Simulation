
using SimulationDelivery;
using System.Drawing;
using System.Text;

internal class Simulation
{
    static void Main(string[] args)
    {
        Maps maps = new Maps();

        Render.initConsole();

        maps.FillMap();
        
        maps.PrintMap();

        //Console.SetCursorPosition(21*4,9*2);
        // Console.WriteLine(" \U0001F3E2 ");
       /* Console.WriteLine(Console.BufferHeight);
        Console.WriteLine(Console.BufferWidth);*/
        NextTurn();
        Console.ReadLine();
        

    }
    private static void NextTurn()
    {
        var transportEntiryList = Maps.getTransports();
        foreach (var transportEntiry in transportEntiryList)
        {
                var transport = (Transport)transportEntiry;
                var newPoint = transport.MakeMove(transportEntiry);
                var OldPoint = Maps.FindPoint(transportEntiry);
                Maps.removeEntity(OldPoint);
                
                Maps.ChangeEntity(newPoint, transportEntiry); 
        }
    }
}