using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oopBankomatas.Models
{
    internal class CreditCard : Account //, Iidentify
    {
        public CreditCard() { }
        public CreditCard(string uniqNr, DateTime validUntil)
        {
            UniqNr = uniqNr;
            ValidUntil = validUntil;
        }

        public CreditCard(string uniqNr, DateTime validUntil, string clientID) : this(uniqNr, validUntil)
        {
            ClientID = clientID;
            //    OwnerName = ownerName;
        }

        public CreditCard MakeNewCard(Account account)        
        {
            string createUniqNr = BasisFunctions.NrRandomGeneratorOnTime();
            //Console.WriteLine(createUniqNr);
            createUniqNr = BasisFunctions.CharakterLengthChanger(createUniqNr, this.UniqNrLenght);
            Console.WriteLine("sukurta card " + createUniqNr); //savikontrolei
            DateTime CalculateValidationTime = DateTime.Today.AddYears(7); 

            string clienttID = account.ClientID;
            //int clienttID = 123;

            var newCard = new CreditCard(createUniqNr, CalculateValidationTime, clienttID);
            AllCards.Add(newCard);
            return new CreditCard();
        }

        public void showCardInfo()
        {
        foreach (var card in AllCards)
                Console.WriteLine($"nr {card.UniqNr} cliento id {card.ClientID}");
        }
       
        public Account CardVerification()
        {
            Console.Write("ideti kortele/ivesti nr....... ");
            //string inputedNr = "123456789"; // Console.ReadLine();
            string inputedNr = Console.ReadLine();
            CreditCard indicatedCard = AllCards.SingleOrDefault(card => card.UniqNr == inputedNr);
            if (inputedNr.Length == this.UniqNrLenght && indicatedCard != null)
            {
                Console.WriteLine("card nr ok."); //for test only
                Console.WriteLine("validation time checking...");
                if (indicatedCard.ValidUntil > DateTime.Today)
                {
                    Console.WriteLine("data ok "); //for test only
                    var indicatedAcc = CreditCardAccountVerification(indicatedCard);
                    if (indicatedAcc != null) 
                    {
                    Console.WriteLine($"SAVIKONTROLE rasta: name {indicatedAcc.LastName} \n id {ClientID} \n card nr {indicatedCard.UniqNr}"); //savikontrolei
                        ActionMeniu(indicatedAcc);
                        return indicatedAcc;                    
                    }
                    else 
                    {
                        Console.WriteLine("oups!! kortele blokuota");
                        return indicatedAcc; // null
                    }
                }
                else
                {
                    Console.WriteLine("baigesi kort galiojimas ");
                    return new Account();
                }
            }
            else
            {
                Console.WriteLine("neaptarnaujama kortele..... ");
                return new Account();
            }
        }

        public void ActionMeniu(Account account)
        {
            /*        string? actionDescription = null;
                    double actionValue = 0;*/
            var accountObj = new Account();
            string? requestForAnotherAction;
            do
            {
                Console.Write("pasirink veiskmą ");
                //actionDescription = ActionManager(account, ref actionDescription);
                accountObj.ActionManager(account);
                Console.WriteLine("dar kas nors? (+) ");
                requestForAnotherAction = Console.ReadLine();
            }

            while (requestForAnotherAction == "+");
        }

        public int UniqNrLenght { get; set; } = 9;
        
        public string UniqNr { get; set; } // 9 simb del paprastumo

        public DateTime ValidUntil { get; set; }
        //public int ClientID  { get; set; }

        public static List<CreditCard> AllCards { get; set; } = new List<CreditCard>();

        //        public Dictionary<string, string> OwnerName { get; set; }


    }
}
