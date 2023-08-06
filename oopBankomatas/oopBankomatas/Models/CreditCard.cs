using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oopBankomatas.Models
{
    internal class CreditCard : Account, Iidentify
    {
        public CreditCard() { }
        public CreditCard(string uniqNr, DateTime validUntil)
        {
            UniqNr = uniqNr;
            ValidUntil = validUntil;
        }

        public CreditCard(string uniqNr, DateTime validUntil, int clientID) : this(uniqNr, validUntil)
        {
            ClientID = clientID;
            //    OwnerName = ownerName;
        }

        public CreditCard MakeNewCard()
        
        {
            //int clienttID = account.ClientID;
            int clienttID = 123;
            DateTime CalculateValidationTime = DateTime.Now.AddYears(7); //new 

            string createUniqNr = BasisFunctions.NrRandomGeneratorOnTime();
            createUniqNr = BasisFunctions.
            CharakterLengthLimit(createUniqNr, 9);

            /*int controlLenght = 9;
            int addSymbols = controlLenght - createUniqNr.Length;

            if (createUniqNr.Length < controlLenght)
            {
                createUniqNr += new string('0', addSymbols);
            }
            else if (createUniqNr.Length > controlLenght) 
            { 
                createUniqNr = createUniqNr.Substring(0, controlLenght);
            }*/

            var newCard = new CreditCard(createUniqNr, CalculateValidationTime, clienttID);
            AllCards.Add(newCard);
            return new CreditCard();

        }

        public void showCardInfo()
        {
        foreach (var card in AllCards)
                Console.WriteLine($"nr {card.UniqNr} cliento id {card.ClientID}");


        }

        /*public CreditCard CreateCard(Account account)
        {
            Console.WriteLine();
            DateTime creatingTime = DateTime.Now;
            
            int[] testdChar = new int[] { creatingTime.Year, creatingTime.Month, creatingTime.Day, creatingTime.Minute };
            return CreditCard;
        }*/

        public bool CheckValidation()
        {
            Console.WriteLine("card nr checking...");

            return true;
        }


        public string UniqNr { get; set; } // 6 simb del paprastumo

        public DateTime ValidUntil { get; set; }
        public int ClientID  { get; set; }

        public static List<CreditCard> AllCards { get; set; } = new List<CreditCard>();

        //        public Dictionary<string, string> OwnerName { get; set; }


    }
}
