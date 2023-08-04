using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopBankomatas.Models
{
    internal class Client
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

        public Client newClientCreate() 
        {
            string name = "Skrudz";
            string lastName = "MacDac";
            int personalID = 01234567890;
            int clientID = 03456781;
            new Client(name, lastName, personalID, clientID);

            return new Client(); 
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public int PersonalID { get; set; } // private
        public int ClientID { get; set; } // private?

        public List<Client> allClients { get; set;} = new List<Client>();



    }
}
