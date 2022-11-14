using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werknemers_Models
{
    public class Uurwerker : Werknemer
    {
        public double Uren { get; set; }

        public Uurwerker(double loon, string naam, string voornaam, double uren) : base(loon, naam, voornaam)
        {
            Uren = uren;
        }

        public override double Loonberekening()
        {
            if (this.Uren <= 40)
            {
                return this.Loon * this.Uren;
            }
            else
            {
                return this.Loon * 40 + ((this.Uren - 40) * (this.Loon * 2));
            }
        }

        public override string Valideer(string propertynaam)
        {
            if (propertynaam == nameof(Uren) && Uren < 0)
            {
                return $"Het aantal uren moet groter dan 0 zijn.{Environment.NewLine}";
            }

            return base.Valideer(propertynaam);
        }
    }
}
