using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werknemers_Models
{
    public class Bedrijf : BasisKlasse
    {
        public string Bedrijfsnaam { get; set; }
        public List<Werknemer> Werknemers { get; }

        public Bedrijf(string bedrijfsnaam) 
        {
            this.Bedrijfsnaam = bedrijfsnaam;
            this.Werknemers= new List<Werknemer>();
        }

        public bool AddWerknemer(Werknemer werknemer)
        {
            if (!Werknemers.Contains(werknemer))
            {
                Werknemers.Add(werknemer);

                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Bedrijf bedrijf && Bedrijfsnaam == bedrijf.Bedrijfsnaam;
        }

        public override int GetHashCode()
        {
            return 1025954773 + EqualityComparer<string>.Default.GetHashCode(Bedrijfsnaam);
        }

        public override string ToString()
        {
            return $"{this.Bedrijfsnaam}";
        }

        public override string Valideer(string propertynaam)
        {
            if (propertynaam == nameof(Bedrijfsnaam) && string.IsNullOrWhiteSpace(Bedrijfsnaam))
            {
                return $"Vul een bedrijfsnaam in.";
            }
            else
            {
                return string.Empty ;
            }
        }
    }
}
