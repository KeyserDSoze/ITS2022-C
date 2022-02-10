using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Paperino
{
    internal abstract class Paperino : object
    {
        public virtual Color GetColorShirt()
            => Color.White;
        public virtual Color GetColorShirt2()
           => Color.White;
        public abstract Color GetColorLight();
        public abstract Color GetColorDark();
    }
}
