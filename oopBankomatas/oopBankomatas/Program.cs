using oopBankomatas.Models;
using System.Security.Principal;

namespace oopBankomatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Bankomat.......! \n\t keli testiniai vartotojai (MaxUnitTest :D )");

            var tcl = new Client(); // test vartotojai
            tcl.CreateClientsForTest();
            Console.WriteLine();

            string requestForAnotherAction;
            do
            {
                AllOptions();
                Console.WriteLine("Į pradžią? (+) ");                    
                requestForAnotherAction = Console.ReadLine();
            }

            while (requestForAnotherAction == "+");


            Console.WriteLine("Testinės kortelės tikrinimas \n");

            var accountForTest = new Account();
            var indicatedAcc = Account.AllAccounts.SingleOrDefault(acc => acc.ClientID == "987654321");
            var card = new CreditCard();
            card.ActionMeniu(indicatedAcc);
            accountForTest.ActionReport(indicatedAcc);

            Console.WriteLine();

            //some functions for test only.... 
            #region
            /*            var makeCard = new CreditCard();
            *//*            makeCard.MakeNewCard();
                        makeCard.MakeNewCard();
                        makeCard.MakeNewCard();
                        makeCard.MakeNewCard();*//*
                        makeCard.showCardInfo();


                        makeCard.CardVerification();*/

            /*            string? actionDescription;
                        double actionValue = 0;
                        Dictionary<string, double> actionDetails = new Dictionary<string, double>();
                        List<Dictionary<string, double>> accountActions = new List<Dictionary<string, double>>(5);

                        if (accountActions.Count > 5) accountActions.RemoveAt(0);
                        actionDetails = new Dictionary<string, double>();
                        actionDescription = "ideti";
                        actionValue = 10;
                        actionDetails.Add(actionDescription, actionValue);
                        accountActions.Add(actionDetails);

                        int i = 1;
                        foreach (var action in  accountActions)
                        {
                            Console.WriteLine(i);
                            foreach (var currentA in action)
                            {
                            Console.WriteLine("turinys " + currentA.Key);
                            Console.WriteLine("suma " + currentA.Value);
                            Console.WriteLine();
                            }
                            i++;
                        }*/
            #endregion
            //some functions for test only.... END
        }

        public static void AllOptions()
        {

            Console.WriteLine($"Pasirinkite veiksmą: \n 1 - Sukurti vartotoja (+ nauja kortele) \n 2 - Įdėti kortelę (BANKOMATAS) \n 3 - Patikrinti esamus vartotojus"); // \n 4 - {put_Cash} \n\n 0 - {userDisconnect} \n");
            int yourChoise = Convert.ToInt16(Console.ReadLine());

            switch (yourChoise)
            {
                case 1:
                    //vartot kurimas - veikia

                    string? requestForAnotherAction;
                    do
                    {
                        var client = new Client();
                        var newClient = client.ClientCreate();
                        var account = new Account();
                        var newAccount = account.CreateAccount(newClient);

                        Console.WriteLine("dar vienas vart? (+) ");
                        requestForAnotherAction = Console.ReadLine();
                    }
                    while (requestForAnotherAction == "+");
                    //vartot kurimas - veikia END
                    break;
                case 2:
                    var makeCard = new CreditCard();
                    //makeCard.showCardInfo();
                    makeCard.CardVerification();
                    break;

                case 3:
                    foreach (var oneclient in Client.AllClients)
                    {
                        Console.WriteLine($"klientas  {oneclient.Name}, suteiktas ID  {oneclient.ClientID} ");
                    }


                    foreach (var oneclient in Account.AllAccounts)
                    {
                        Console.WriteLine($"acc  {oneclient.Name}, {oneclient.Balance} ");
                    }
                    break;

                default:
                    Console.WriteLine("chaos chikitos  : )))))) ");
                    Environment.Exit(0);
                    break;
            }
            //return availibleActionDescription = "nepasirinkta";
        }

        //public static void newUserCreation();
    }
}