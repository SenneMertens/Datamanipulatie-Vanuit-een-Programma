using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Models
{
    public static class Validaties
    {
        public static bool IsRijksregisternummerGeldig(string rijksregisternummer)
        {
            int controlegetal;
            long eersteNegenGetallen;

            rijksregisternummer = rijksregisternummer.Replace("-", "");
            rijksregisternummer = rijksregisternummer.Replace(" ", "");

            if (rijksregisternummer.Length != 11 || !long.TryParse(rijksregisternummer.Substring(0, 9), out eersteNegenGetallen) || !int.TryParse(rijksregisternummer.Substring(9, 2), out controlegetal))
            {
                return false;
            }
            

            if (97 - (eersteNegenGetallen % 97) == controlegetal)
            {
                return true;
            }
            else if (97 - ((2000000000 + eersteNegenGetallen) % 97) == controlegetal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
