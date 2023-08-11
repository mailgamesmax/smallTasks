using System.Reflection;

namespace IEnumerableYield
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, IEnumerable and yield.......!");

            var stringPrinter = new StringPrinter();
            stringPrinter = new StringPrinter("pirmas sakinys");
            stringPrinter = new StringPrinter("antras sakinys");
            stringPrinter = new StringPrinter("trečias sakinys");
            stringPrinter = new StringPrinter("ketvirtas sakinys");

            foreach (string line in stringPrinter) 
            {
                Console.WriteLine(line);
            }


        }
    }
}