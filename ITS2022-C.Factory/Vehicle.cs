using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Factory
{
    internal abstract class Vehicle
    {
        public bool Engine { get; set; }
        public void Start() => Engine = true;
        public void Stop() => Engine = false;
    }
}