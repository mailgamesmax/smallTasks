using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopBankomatas.Models
{
    internal abstract class BasisFunctions
    {

        public static string NrRandomGeneratorOnTime() //datos konv i stringa
        {
            DateTime creatingTime = DateTime.Now;

            string generatedNr = string.Join("", creatingTime.Month, creatingTime.Day, creatingTime.Hour, creatingTime.Minute, creatingTime.Microsecond);
            return generatedNr;
        }

        public static string CharakterLengthChanger(string basisCharakter, int controlLenght) //karpom rezultata pagal norima ilgi
        {            
            int addSymbols = controlLenght - basisCharakter.Length;

            if (basisCharakter.Length < controlLenght)
            {
                basisCharakter += new string('0', addSymbols);
            }
            else if (basisCharakter.Length > controlLenght)
            {
                basisCharakter = basisCharakter.Substring(0, controlLenght);
            }
            return basisCharakter;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        internal string ClientID { get; set; } // ?

    }
}
