using ITS2022_C.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Core
{
    public class SpanishIdentityCard : IdentityCard
    {
        public string FiscalCode;
        public void Something4()
        {
            Age = string.Empty;
            Check();
        }
    }
}
