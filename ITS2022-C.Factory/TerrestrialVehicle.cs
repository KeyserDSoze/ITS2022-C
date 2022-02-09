using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Factory
{
    internal abstract class TerrestrialVehicle : Vehicle
    {
        public bool Wheel { get; set; }
        public void Change() => Wheel = true;
        public void NoChange() => Wheel = false;
    }
}