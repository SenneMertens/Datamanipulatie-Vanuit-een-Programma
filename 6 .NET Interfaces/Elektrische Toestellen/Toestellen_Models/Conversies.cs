using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toestellen_Models
{
    public static class Conversies
    {
        public static string ConverteerNumeriekNaarString(double waarde)
        {
            return $"{waarde.ToString("0.##")}";
        }

        public static string ConverteerNumeriekNaarValuta(double waarde)
        {
            return $"{waarde.ToString("C")}";
        }
    }
}
