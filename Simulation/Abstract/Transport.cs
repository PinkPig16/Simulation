using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDelivery
{
    abstract class Transport : Entiry
    {
        private int Speed { get; set; }
        private int LoadCapacity {  get; set; }
        abstract protected void MakeMove();
        abstract protected void Loading();



    }
}
