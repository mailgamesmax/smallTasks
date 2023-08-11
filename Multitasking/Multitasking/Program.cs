using System.Xml;
//using System.Threading.Tasks;

namespace Multitasking
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, multitaks..........");

            var oneLonger = new ProgressBar();

            var currentProgress = oneLonger.Progress;
            int totalDelayTime = 0;
            for (currentProgress = 0; currentProgress < 10; currentProgress++) 
            {
                int delayTime = 1000;
                //Thread.Sleep(delayTime); // - good option
                await Task.Delay(delayTime);
                if (totalDelayTime % 3000 == 0) { Console.WriteLine(currentProgress); }
                totalDelayTime += delayTime;
                
            }
            Console.WriteLine(currentProgress);

        }
    }

    public class ProgressBar
    {
        
        
        public ProgressBar() { }
        public int Progress; // { get; set; }
    }

// Thread printThread = new Thread(() => { while (progressBar.progress < 100) { Console.WriteLine($"Progress: {progressBar.progress}%"); Thread.Sleep(3000); } });

}