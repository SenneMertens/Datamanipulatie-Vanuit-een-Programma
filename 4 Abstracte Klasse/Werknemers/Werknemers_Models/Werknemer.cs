using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werknemers_Models
{
    public abstract class Werknemer : BasisKlasse
    {
        public double Loon { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }

        public Werknemer(double loon, string naam, string voornaam)
        {
            this.Loon = loon;
            this.Naam = naam;
            this.Voornaam = voornaam;
        }

        public override bool Equals(object obj)
        {
            return obj is Werknemer werknemer && Naam == werknemer.Naam && Voornaam == werknemer.Voornaam;
        }

        public override int GetHashCode()
        {
            int hashCode = 1141431810;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Naam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Voornaam);
            return hashCode;
        }

        public abstract double Loonberekening();

        public override string ToString()
        {
            return $"{this.GetType().Name.PadRight(20)}{this.Naam.PadRight(15)}{this.Voornaam.PadRight(15)}{this.Loonberekening().ToString("0.##")}";
        }

        public override string Valideer(string propertynaam)
        {
            if (propertynaam == nameof(Loon) && Loon < 0)
            {
                return $"Het loon moet groter dan 0 zijn.{Environment.NewLine}";
            }
            else if (propertynaam == nameof(Naam) && string.IsNullOrWhiteSpace(Naam))
            {
                return $"Vul een naam in.{Environment.NewLine}";
            }
            else if (propertynaam == nameof(Voornaam) && string.IsNullOrWhiteSpace(Voornaam))
            {
                return $"Vul een voornaam in.{Environment.NewLine}";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
