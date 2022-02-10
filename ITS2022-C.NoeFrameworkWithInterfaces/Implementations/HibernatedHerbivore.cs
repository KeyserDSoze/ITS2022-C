using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.NoeFrameworkWithInterfaces.Models
{
    public class HibernatedHerbivore : ISleep, IEat
    {
        public void Eat()
        {
            Console.WriteLine("Herbivore is eating");
        }

        public void Sleep()
        {
            Console.WriteLine("Herbivore is hibernating");
        }
    }
}
