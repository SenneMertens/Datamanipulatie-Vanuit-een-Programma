using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Models
{
    public static class WetenschappelijkeFormules
    {
        public const double VALVERSNELLING = 9.81;

        public static double Arbeid(double kracht, double verplaatsingInMeter)
        {
            return kracht* verplaatsingInMeter;
        }

        public static double GravitatiePotentieleEnergie(double massa, double hoogteInMeter)
        {
            return Zwaartekracht(massa) * hoogteInMeter;
        }

        public static double Vermogen(double arbeid, int tijdsduur)
        {
            return arbeid* tijdsduur;
        }

        public static double Vermogen(double kracht, double verplaatsingInMeter, int tijdsduur)
        {
            return Arbeid(kracht, verplaatsingInMeter) / tijdsduur;
        }

        public static double Zwaartekracht(double massa)
        {
            return massa * VALVERSNELLING;
        }
    }
}
