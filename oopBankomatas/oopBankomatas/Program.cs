using oopBankomatas.Models;

namespace oopBankomatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Bankomat.......!");

            var tcl = new Client(); // test vartotojai
            tcl.CreateClientsForTest();

/*            //vartot kurimas - veikia

            string? requestForAnotherAction;
                        do
                        {
                            var client = new Client();
                            var newClient = client.ClientCreate();
                            var account = new Account();
                            var newAccount = account.CreateAccount(newClient);


                            Console.WriteLine("pakartot? (+) ");
                            requestForAnotherAction = Console.ReadLine();

                        }
                        while (requestForAnotherAction == "+");
            //vartot kurimas - veikia END*/


            foreach (var oneclient in Client.AllClients) 
            { 
            Console.WriteLine($"klientas  {oneclient.Name}, suteiktas ID  {oneclient.ClientID} "); 
            }


            foreach (var oneclient in Account.AllAccounts)
            { Console.WriteLine($"acc  {oneclient.Name}, {oneclient.Balance} "); 
            }

            Console.WriteLine("skaiciavimu projektavimas\n");

            //account.ManageAction(newAccount);
            //account.ActionReport(newAccount);

            Console.WriteLine();


            var makeCard = new CreditCard();
/*            makeCard.MakeNewCard();
            makeCard.MakeNewCard();
            makeCard.MakeNewCard();
            makeCard.MakeNewCard();*/
            makeCard.showCardInfo();


            makeCard.CardVerification();

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

        }

        //public static void newUserCreation();
    }
}