using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.NoeFramework
{
    public class HibernatedCarnivore : Carnivore
    {
        public override string Name
        {
            get => $"HC. {name}";
            init => name = value;
        }
        public override void Sleep()
        {
            Console.WriteLine($"{Name} is hibernating.");
        }
    }
}
