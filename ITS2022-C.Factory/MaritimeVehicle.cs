using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Factory
{
    internal abstract class MaritimeVehicle : Vehicle
    {
        public bool Something { get; set; }
        public void Do() => Something = true;
        public void Dont() => Something = false;
    }
}