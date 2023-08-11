using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableYield
{
    internal class StringPrinter : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string line in myList)
            {
                yield return line;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void UpdateAllLines(StringPrinter stringPrinter)
        {
            AllLines.Add(stringPrinter);
        }

        public StringPrinter() { }
        public StringPrinter(string oneLine) { MyLine = oneLine; }

        public static List<StringPrinter> AllLines { get; set; } = new List<StringPrinter>();
        public static List<string> myList { get; set; } = new List<string>();
        public string MyLine { get; set; }
    }
}
