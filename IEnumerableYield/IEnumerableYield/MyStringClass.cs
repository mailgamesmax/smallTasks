using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableYield
{
    internal class MyStringClass
    {
        public string MyLine { get; set; }

        public MyStringClass() { }
        public MyStringClass (string oneLine) { MyLine = oneLine; }

        public static List<string> AllLines { get; set; } = new List<string>();

    }
}
