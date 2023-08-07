using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopBankomatas.Models
{
    internal class Client: BasisFunctions//, Iidentify
    {
        public Client() { }
        public Client(string name, string lastName) 
        {
            Name = name;
            LastName = lastName;
        }

        public Client(string name, string lastName, string inputPersonalID) : this (name, lastName)
        {            
            InputPersonalID = inputPersonalID;         
        }

        public Client(string name, string lastName, string inputPersonalID, string clientID) : this(name, lastName, inputPersonalID)
        {
            ClientID = clientID;
        }

        public Client ClientCreate() 
        {
            Console.Write("Įvedam vardą: ");
            string name = Console.ReadLine();
            //string name = "Skrudz";
            Console.Write("Įvedam pav: ");
            //string lastName = "MacDac";
            string lastName = Console.ReadLine();
            Console.Write("Įvedam a/k (uzteks 8 sk......) : ");
            string inputPersonalID = Console.ReadLine();

            string clientID = BasisFunctions.CharakterLengthChanger(inputPersonalID, 5)+            BasisFunctions.CharakterLengthChanger(BasisFunctions.NrRandomGeneratorOnTime(), 8);
            var newClient = new Client(name, lastName, inputPersonalID, clientID);
            UpdateAllClients(newClient);
            return newClient; 
        }

        public List<Client> UpdateAllClients(Client newClient)
        {
            AllClients.Add(newClient);
            return AllClients;
        }

        //testing clients begin
        public void CreateClientsForTest() //testams
        {
            var newClient = new Client("Vardas kl1", "Pavarde kl1", "12345678", "987654321");
            UpdateAllClients(newClient);
            string testpassw = "abc123";
            Account.CreateAccForTest(newClient, testpassw);

            newClient = new Client("Vardas kl2", "Pavarde kl2", "22345678", "987654322");
            UpdateAllClients(newClient);
            testpassw = "Abc123";
            Account.CreateAccForTest(newClient, testpassw);

            newClient = new Client("Vardas kl3", "Pavarde kl3", "32345678", "987654323");
            UpdateAllClients(newClient);
            testpassw = "Abc124";
            Account.CreateAccForTest(newClient, testpassw);

        }
        //testing clients begin


        private string InputPersonalID { get; set; } // private
        //internal int ClientID { get; set; } // ?

        public static List<Client> AllClients { get; set;} = new List<Client>();

    }
}
