// See https://aka.ms/new-console-template for more information
using ITS2022_C.Factory;


Factory factory = new Factory();
var vehicle = factory.Create(VehicleType.Car);
var vehicle2 = factory.Create(VehicleType.Bike);
var vehicle3 = factory.Create(VehicleType.Ship);
var t3 = vehicle3 as TerrestrialVehicle;
var t4 = (TerrestrialVehicle)vehicle3;
vehicle.Start();
vehicle.Stop();
Vehicle? otherVehicle = vehicle;
TerrestrialVehicle? t = vehicle as TerrestrialVehicle;
TerrestrialVehicle t2 = (TerrestrialVehicle)vehicle;
Car car = t2 as Car;
car.Engine = false;
double x = 5;
double y = x;
if(x == y)
{

}
if (vehicle is TerrestrialVehicle terrestrialVehicle)
{

    terrestrialVehicle.Change();
    if (vehicle == terrestrialVehicle)
    {

    }
}
