using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Paperino
{
    internal class Qui : Paperino
    {
        public override Color GetColorDark()
        {
            return Color.BlanchedAlmond;
        }

        public override Color GetColorLight()
        {
            //base.GetColorLight();
            return Color.White;
        }
        public override Color GetColorShirt()
        {
            var color = base.GetColorShirt();
            ///
            return Color.RebeccaPurple;
        }
    }
}
