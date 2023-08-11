using System.Dynamic;

namespace MyFolderContent
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, list screeener )) ");

            for (int currentProgress = 0; currentProgress < 3; currentProgress++)             
            { 
                string myFolderPath = @"C:\Users\Maksim\Downloads\myDesktop";
                
                string[] filesInActualFolder = Directory.GetFiles(myFolderPath);
                foreach (string fullPath in filesInActualFolder)
                {
                    
                    Console.WriteLine($"name ->     {Path.GetFileName(fullPath)}");                    
                }
                Console.WriteLine("20 sek brake....\n");
                int delayTime = 3000;
                await Task.Delay(delayTime);
            }
        }
    }
}