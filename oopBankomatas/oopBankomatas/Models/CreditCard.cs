using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oopBankomatas.Models
{
    internal class CreditCard
    {
        public CreditCard() { }
        public CreditCard(int uniqNr, DateOnly validUntil)
        {
            UniqNr = uniqNr;
            ValidUntil = validUntil;            
        }

        public CreditCard(int uniqNr, DateOnly validUntil, int clientID ) : this(uniqNr, validUntil)
        {
            ClientID = clientID;
        //    OwnerName = ownerName;
        }
        
/*        public CreditCard MakeNewCard() 
        {           
            int inputUniqNr = 1;
            DateTime inputValidTime = DateTime.Now; //new DateOnly(DateTime.Now); //.AddYears(7));
            DateOnly now = DateOnly.Parse(DateTime.Now);
            DateOnly nnow = new DateOnly();
            int inputClientID = 03456781;
            var newCard = new CreditCard(inputUniqNr, inputValidTime, inputClientID);

            return new CreditCard();

        }*/
        
        public int UniqNr { get; set; } 

        public DateOnly ValidUntil { get; set; }
        public int ClientID  { get; set; }

        public static List<CreditCard> allCards { get; set; } = new List<CreditCard>();

//        public Dictionary<string, string> OwnerName { get; set; }


    }
}
