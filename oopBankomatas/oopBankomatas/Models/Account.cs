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

        public Account(string name, string lastName, Dictionary<int, string> accoutID) : this(name, lastName)
        {
            AccountID = accoutID;
        }

        public virtual Account CreateAccount(Client client)
        {

            string userName = client.Name;
            string userLastName = client.LastName;
            int clientID = client.ClientID;
            string inputPassw = "abc123"; // pakeisti i ivesti
            Dictionary<int, string> accountID = new Dictionary<int, string>() {{ clientID, inputPassw }};
            Account newAccount = new Account(userName, userLastName, accountID);
            UpdateAllAccounts(newAccount);
            return newAccount;
        }

        public List<Client> UpdateAllAccounts(Client addingClient)
        {
            var updateAllAccounts = new List<Client>(allAccounts) { addingClient };
            return updateAllAccounts;
        }

        public Dictionary<int, string> AccountID { get; set; } // clientID+passw        
        public string Name { get; set; }
        public string LastName { get; set; }

        public static List<Account> allAccounts { get; set; } = new List<Account>();
    }
}
