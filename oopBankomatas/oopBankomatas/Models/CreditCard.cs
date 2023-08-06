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
            string clienttID = account.ClientID;
            //int clienttID = 123;
            DateTime CalculateValidationTime = DateTime.Today.AddYears(7); 

            string createUniqNr = BasisFunctions.NrRandomGeneratorOnTime();
            createUniqNr = BasisFunctions.
            CharakterLengthChanger(createUniqNr, this.UniqNrLenght);

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
            string inputedNr = "123456789"; // Console.ReadLine();
            CreditCard indicatedCard = AllCards.SingleOrDefault(card => card.UniqNr == inputedNr);
            if (inputedNr.Length == this.UniqNrLenght && indicatedCard != null)
            {
                Console.WriteLine("card nr ok."); //for test only
                Console.WriteLine("validation time checking...");
                if (indicatedCard.ValidUntil > DateTime.Today)
                {
                    Console.WriteLine("data ok "); //for test only
                    var indicatedAcc = CreditCardAccountVerification(indicatedCard);
                    return indicatedAcc;
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



        /*
        public bool Verification()
        {
            Console.Write("ideti kortele/ivesti nr....... ");
            string inputedNr = "123456789"; // Console.ReadLine();
            if (inputedNr.Length == this.UniqNrLenght)
            {
                Console.WriteLine("card nr ok.");
                CreditCardVerification(inputedNr);
            }
            else { Console.WriteLine("neaptarnaujama kortele (nr.....) "); return false; }

            Console.WriteLine("card nr checking...");
            return true;
        }
                public bool CreditCardVerification(string currentCardNr)
                {
                    Console.WriteLine("validation time checking...");
                    CreditCard indicatedCard = AllCards.SingleOrDefault(card => card.UniqNr == currentCardNr);
                    if (indicatedCard != null) 
                    {
                        if (indicatedCard.ValidUntil > DateTime.Today)
                        {
                            Console.WriteLine("data ok ");
                            if (CreditCardAccountVerification(indicatedCard)) 
                            {
                            return true;
                            }
                            else { return false; }


                        }
                        else { Console.WriteLine("soriux, baigėsi galiojimas"); return false; }
                    }
                    else { Console.WriteLine(" vartotojas nerastas "); return false; }
                }*/

        public int UniqNrLenght { get; set; } = 9;
        
        public string UniqNr { get; set; } // 9 simb del paprastumo

        public DateTime ValidUntil { get; set; }
        //public int ClientID  { get; set; }

        public static List<CreditCard> AllCards { get; set; } = new List<CreditCard>();

        //        public Dictionary<string, string> OwnerName { get; set; }


    }
}
