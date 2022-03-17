using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Library
{
    internal class Executor
    {
        public static void TestMain(string[] args)
        {
            var x = new ItalianIdentityCard().NameSurname;
            var y = new ItalianIdentityCard().Number;
            new ItalianIdentityCard().Something3();
            //new IdentityCard();
        }
    }
}
