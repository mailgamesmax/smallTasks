using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopBankomatas.Models
{
    internal class Account : Client //, Iidentify
    {
        public Account() { }
        public Account(string name, string lastName) : base(name, lastName) {}
        public Account(string name, string lastName, string clientID) : this(name, lastName)
        {
            this.ClientID = clientID;
        }

/*        public Account(string name, string lastName, Dictionary<string, string> accoutID) : this(name, lastName)
        {
            AccountID = accoutID;
        }
*/
        public virtual Account CreateAccount(Client client)
        {

            string userName = client.Name;
            string userLastName = client.LastName;
            string clientID = client.ClientID;
            bool isCoupeledClientIdAndPassw = false;
            do
            {

                Console.Write("sukurk slaptiką: ");
                string inputPassw = "abc123"; // pakeisti i ivesti

                isCoupeledClientIdAndPassw = Autorisation.TryAdd(clientID, inputPassw); //turi būti vienas dict......
                if (isCoupeledClientIdAndPassw) { Console.WriteLine($"isimink slapika.....->  {inputPassw}"); }
                else { Console.WriteLine("kažkas ne OK su slapiku"); }
            }
            while (isCoupeledClientIdAndPassw);
            //Dictionary<string, string> accountID = new Dictionary<string, string>() {{ clientID, inputPassw }}; //turi būti vienas dict......
            Account newAccount = new Account(userName, userLastName, clientID);
            UpdateAllAccounts(newAccount);
            return newAccount;
        }

        public bool Verification()
        {
            Console.WriteLine("duok passw.....");
            string inputedPasw = "abc123"; return true; 

        }
        public Account CreditCardAccountVerification(CreditCard indicatedCard)
        {
            Account indicatedAcc = AllAccounts.SingleOrDefault(acc => acc.ClientID == indicatedCard.ClientID);
            bool passwExist = Autorisation.TryGetValue(indicatedAcc.ClientID, out var getPassw);
            string? checkThisPassw;
            if (passwExist)
            { 
                int i = 1;
                do
                {
                    Console.WriteLine("duok pasw...");
                    checkThisPassw = "abc123"; //input.........
                    if (checkThisPassw == getPassw)
                    {
                        Console.WriteLine("acc passw ok"); //for test only
                        return indicatedAcc;
                    }
                    else
                    {
                        Console.WriteLine("acc passw wrong"); //for test only
                        //return false;
                        i++;
                    }
                }
                while (checkThisPassw != getPassw && i < 3);
                return new Account();
            }    
            else 
            {
                Console.WriteLine("kortelės klaida (nėra passw)");
                return new Account();
            }
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

        

        private static Dictionary<string, string> Autorisation { get; set; } // clientID+passw    // static??????????    
        public double Balance { get; set; } = 1500; //testinis likutis
/*        public string ActionDescription { get; set; }
        public double ActionValue { get; set; }*/
        public List<Dictionary<string, double>> AccountActions { get; set; } = new List<Dictionary<string, double>>(5);
        public static List<Account> AllAccounts { get; set; } = new List<Account>();
    }
}
