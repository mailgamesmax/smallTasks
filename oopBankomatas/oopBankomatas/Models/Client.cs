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
            //string inputPersonalID = "30112291234";
            //int inputPersonalID = 30112291234;
            /*BasisFunctions.CharakterLengthLimit(inputPersonalID, 5);
            BasisFunctions.CharakterLengthLimit(BasisFunctions.NrRandomGeneratorOnTime(), 8);*/

            
            //CharakterLengthLimit
            string clientID = BasisFunctions.CharakterLengthLimit(inputPersonalID, 5)+            BasisFunctions.CharakterLengthLimit(BasisFunctions.NrRandomGeneratorOnTime(), 8);
            var newClient = new Client(name, lastName, inputPersonalID, clientID);
            UpdateAllClients(newClient);
            return newClient; 
        }

        public List<Client> UpdateAllClients(Client newClient)
        {
            AllClients.Add(newClient);
            return AllClients;
        }

        //public string Name { get; set; }
        //public string LastName { get; set; }
        private string InputPersonalID { get; set; } // private
        //internal int ClientID { get; set; } // ?

        public static List<Client> AllClients { get; set;} = new List<Client>();

    }
}
