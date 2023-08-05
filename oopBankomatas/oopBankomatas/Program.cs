using oopBankomatas.Models;

namespace oopBankomatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Bankomat.......!");

            //DateTime today = Convert.ToDateTime(Console.ReadLine());
/*            DateTime today = DateTime.Today;
            string toText = today.ToString("yyMMdd");
            int toInt = Convert.ToInt32(toText);
            Console.WriteLine(toInt);
            Console.WriteLine();

            DateTime nnow = DateTime.Now.AddYears(7);
            Console.WriteLine(nnow);*/

            var newClient = new Client();
            newClient.newClientCreate();
            var newAccount = new Account();
            newAccount.CreateAccount(newAccount);

            Console.WriteLine();

        }

        //public static void newUserCreation();
    }
}