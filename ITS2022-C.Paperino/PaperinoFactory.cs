using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Paperino
{
    internal class PaperinoFactory
    {
        public Paperino Create()
        {
            return new SuperQui();
        }
    }
}
