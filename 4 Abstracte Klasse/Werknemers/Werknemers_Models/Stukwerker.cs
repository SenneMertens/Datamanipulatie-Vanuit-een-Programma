using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werknemers_Models
{
    public class Stukwerker : Werknemer
    {
        public int Aantal { get; set; }

        public Stukwerker(double loon, string naam, string voornaam, int aantal) : base(loon, naam, voornaam)
        {
            this.Loon = loon;
        }

        public override double Loonberekening()
        {
            return this.Loon * this.Aantal;
        }

        public override string Valideer(string propertynaam)
        {
            if (propertynaam == nameof(Aantal) && Aantal < 0)
            {
                return $"Het aantal moet groter dan 0 zijn.{Environment.NewLine}";
            }

            return base.Valideer(propertynaam);
        }
    }
}
