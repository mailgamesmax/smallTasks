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

        public Client(string name, string lastName, int personalID) : this (name, lastName)
        {            
            PersonalID = personalID;         
        }

        public Client(string name, string lastName, int personalID, int clientID) : this(name, lastName, personalID)
        {
            ClientID = clientID;
        }

        public Client ClientCreate() 
        {
            string name = "Skrudz";
            string lastName = "MacDac";
            int personalID = 01234567890;
            int clientID = 11;//456781;
            var newClient = new Client(name, lastName, personalID, clientID);
            UpdateAllClients(newClient);
            return newClient; 
        }

        public List<Client> UpdateAllClients(Client newClient)
        {
            AllClients.Add(newClient);
            return AllClients;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        private int PersonalID { get; set; } // private
        internal int ClientID { get; set; } // ?

        public static List<Client> AllClients { get; set;} = new List<Client>();



    }
}
