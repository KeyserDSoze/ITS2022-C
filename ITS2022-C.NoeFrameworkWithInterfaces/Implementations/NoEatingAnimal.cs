﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.NoeFrameworkWithInterfaces.Models
{
    public class NoEatingAnimal : ISleep
    {
        public void Sleep()
        {
            Console.WriteLine("Animal is sleeping");
        }
    }
}
