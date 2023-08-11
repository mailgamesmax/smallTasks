namespace AnotherExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, ienum!");

            //string myFile = "filename.txt";
            string myFile = @"C:\Users\Maksim\Desktop\ch.txt";

           FileLineReader reader = new FileLineReader(myFile);

            //kodas neveikia. Taip ir turi but?1
        }
    }

    public class FileLineReader
    {
        public IEnumerable<string> ReadLines() 
        {
            using (StreamReader reader = new StreamReader(FileName)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    yield return line;
                }
            }
        }

        public FileLineReader(string fileName) 
        {
            this.FileName = fileName; //naudojant fieldus būtinas this? fieldas ne savybė,bet gali būt konstruktoriaus dalimi?
        }

        private string FileName; // tai fieldas? 
    }
}