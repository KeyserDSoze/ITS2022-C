using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Paperino
{
    internal class SuperQui : Qui
    {
        public override Color GetColorShirt()
        {
            var x = base.GetColorShirt();
            return Color.AliceBlue;
        }
        public override Color GetColorLight()
        {
            return base.GetColorLight();
        }
        public override Color GetColorDark()
        {
            throw new NotImplementedException();
        }
    }
}
