using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.NoeFrameworkWithInterfaces.Models
{
    public class AnimalManager
    {
        public void Run(object animal)
        {
            if (animal is IEat eatingAnimal)
            {
                eatingAnimal.Eat();
            }
            if (animal is ISleep sleepingAnimal)
            {
                sleepingAnimal.Sleep();
            }
        }
    }
}
