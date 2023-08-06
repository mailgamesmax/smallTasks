using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopBankomatas.Models
{
    internal class Account : Client
    {
        public Account() { }
        public Account(string name, string lastName) : base(name, lastName) {}

        public Account(string name, string lastName, Dictionary<string, string> accoutID) : this(name, lastName)
        {
            AccountID = accoutID;
        }

        public virtual Account CreateAccount(Client client)
        {

            string userName = client.Name;
            string userLastName = client.LastName;
            string clientID = client.ClientID;
            string inputPassw = "abc123"; // pakeisti i ivesti
            Dictionary<string, string> accountID = new Dictionary<string, string>() {{ clientID, inputPassw }}; //turi būti vienas dict......
            Account newAccount = new Account(userName, userLastName, accountID);
            UpdateAllAccounts(newAccount);
            return newAccount;
        }

        public List<Account> UpdateAllAccounts(Account newAccount)
        {
            AllAccounts.Add(newAccount);
            return AllAccounts;
        }

        public void ManageAction(Account account) 
        {
        string? actionDescription;
        double actionValue = 0;
        Dictionary<string, double> actionDetails = new Dictionary<string, double>();
        string? requestForAnotherAction;
            do
            {


                actionDetails = new Dictionary<string, double>();
                Console.Write("pasirink veiskmą ");
                actionDescription = Console.ReadLine();
                Console.Write("Įvesk sumą (įšimti -max 1000e): ");
                actionValue = Convert.ToDouble(Console.ReadLine());

                if (account.Balance + actionValue < 0 || actionValue < (-1000))
                {
                    Console.WriteLine("ką čia bandai apgaut seni?....");
                }
                else
                {
                    if (account.AccountActions.Count > 4) account.AccountActions.RemoveAt(0);
                    actionDetails.Add(actionDescription, actionValue);
                    account.AccountActions.Add(actionDetails);
                    account.Balance += actionValue;
                    Console.WriteLine($"{actionDescription} <- įvykdyta\n{actionValue} <- operacijos suma\n{account.Balance} <- ESAMAS LIKUTIS");
                }
                Console.WriteLine("dar kas nors? (+) ");
                requestForAnotherAction = Console.ReadLine();
            }

            while (requestForAnotherAction == "+");
        }

        public void ActionReport(Account account) 
        {
            int i = 1;
            foreach (var action in  account.AccountActions)
            {
                Console.WriteLine("operacijos nr: " + i);
                foreach (var currentA in action)
                {
                Console.WriteLine("turinys " + currentA.Key);
                Console.WriteLine("suma " + currentA.Value);
                Console.WriteLine();
                }
                i++;
            }
            Console.WriteLine($"Likutis: {account.Balance}");
        }

        

        public Dictionary<string, string> AccountID { get; set; } // clientID+passw    // static??????????    
        public double Balance { get; set; } = 1500; //testinis likutis
/*        public string ActionDescription { get; set; }
        public double ActionValue { get; set; }*/
        public List<Dictionary<string, double>> AccountActions { get; set; } = new List<Dictionary<string, double>>(5);
        public static List<Account> AllAccounts { get; set; } = new List<Account>();
    }
}
