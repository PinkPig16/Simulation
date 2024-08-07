﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDelivery
{
    abstract class Transport : Entiry
    {
        private int Speed { get; set; }
        private int MaxLoadCapacity { get; set; }
        private int LoadCapacity {  get; set; }
        abstract public Point MakeMove(Entiry entiry);
        abstract public void Loading();



    }
}
