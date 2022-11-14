using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werknemers_Models
{
    public class Commissiewerker : Werknemer
    {
        public int Aantal { get; set; }
        public double Commissie { get; set; }

        public Commissiewerker(double loon, string naam, string voornaam, int aantal, double commissie) : base(loon, naam, voornaam)
        {
            Aantal = aantal;
            Commissie = commissie;
        }

        public override double Loonberekening()
        {
            return this.Loon + (this.Aantal * this.Commissie);
        }

        public override string Valideer(string propertynaam)
        {
            if (propertynaam == nameof(Aantal) && Aantal < 0)
            {
                return $"Het aantal moet groter dan 0 zijn.{Environment.NewLine}";
            }
            else if (propertynaam == nameof(Commissie) && Commissie < 0)
            {
                return $"De commissie moet groter dan 0 zijn.{Environment.NewLine}";
            }

            return base.Valideer(propertynaam);
        }
    }
}
