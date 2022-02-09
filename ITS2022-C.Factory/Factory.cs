using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Factory
{
    internal class Factory
    {
        public Vehicle Create(VehicleType type)
        {
            switch (type)
            {
                case VehicleType.Car:
                    return new Car();
                case VehicleType.Bike:
                    return new Bike();
                case VehicleType.Ship:
                    return new Ship();
                default:
                    return null;
            }
        }
    }
}