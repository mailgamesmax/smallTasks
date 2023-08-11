using System.Net.Sockets;

namespace StreamTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Streams.....!");

            string content = File.ReadAllText(@"C:\Users\Maksim\source\repos\OOP\folder_github\StreamProjects\failtxt1.txt");
            Console.WriteLine(content);

            List<string> someJokesAboutDevelopers= new List<string>
        {            
            "Kaip kompiuteristai sveikina vienas kitą? \"Hello World!\"",
            "Kodėl kompiuteristas niekada nesugadina savo vakarienės? Jis naudoja \"try-catch\" bloką.",
            "Kas programuotojui yra github? Tai kaip facebook, tik su daugiau commit ir mažiau like.",
            "čia galėjo būti tavo juokelis......."
        };

            /*            foreach (string joke in  someJokesAboutDevelopers)
                        {
                            string targetFile = File.WriteAllLines(@"C:\Users\Maksim\source\repos\OOP\folder_github\StreamProjects\failtxtForWriting.txt", joke);

                        }*/

            string targetFile = @"C:\Users\Maksim\source\repos\OOP\folder_github\StreamProjects\failtxtForWriting.txt";
            string copiedTargetFile = @"C:\Users\Maksim\source\repos\OOP\folder_github\StreamProjects\failtxtForWritingCopied.txt";

            if (File.Exists(copiedTargetFile))
            {
                File.Delete(copiedTargetFile);
            }

            File.WriteAllLines(targetFile, someJokesAboutDevelopers);

            File.Copy(targetFile, @"C:\Users\Maksim\source\repos\OOP\folder_github\StreamProjects\failtxtForWritingCopied.txt");

            string testT = "TEST TEXT ";
            Console.WriteLine(testT + testT.Length);

            string streamObject = @"C:\Users\Maksim\source\repos\OOP\folder_github\StreamProjects\failtxt1.txt"; // neperskaitytas failas
            int totalSymbols = 0;
            int totalLetters = 0;
            string line = "";
            using (var reader = new StreamReader(streamObject))
            {
                while ((line = reader.ReadLine()) != null) 
                {
                    totalSymbols += line.Length;
                    line = line.Replace(" ", "");
                    totalLetters += line.Length;
                }
            }

            Console.WriteLine("TOTAL symbols " + totalSymbols);
            Console.WriteLine("TOTAL letters " + totalLetters);

            if (File.Exists(streamObject))
            {
                File.Delete(streamObject);
            }

            using (StreamWriter writer = new StreamWriter(streamObject))
            {
                writer.WriteLine("su tekstu viskas aišku maždaug");
                writer.WriteLine(321.123);
            }

            //binarinio failo klonavimas
            string binaryObject = @"C:\Users\Maksim\source\repos\OOP\folder_github\StreamProjects\wordpic.docx";
            string targetBinaryObject = @"C:\Users\Maksim\source\repos\OOP\folder_github\StreamProjects\wordpicClone.docx";
            using (BinaryReader readerB = new BinaryReader(File.Open(binaryObject, FileMode.Open)))
            using (BinaryWriter writerB = new BinaryWriter(File.Open(targetBinaryObject, FileMode.Open)))
            {
                while (readerB.BaseStream.Position < readerB.BaseStream.Length) 
                {
                    byte[] buffer = readerB.ReadBytes(1024); // Skaityti baitus
                    writerB.Write(buffer); // Rašyti baitus
                    
                    //int intValue = readerB.ReadInt32();
                                           //double doubleValue = readerB.ReadDouble();
                                           //bool intBoolValue = readerB.ReadBoolean();
                }
            }



        }
    }
}