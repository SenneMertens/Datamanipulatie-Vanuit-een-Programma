using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodentocht_Models
{
    public class Deelnemer : BasisKlasse, IDeelnemer
    {
        public DateTime?[] Aankomsttijden { get; set; }
        public string Naam { get; set; }

        public Deelnemer(string naam)
        {
            this.Naam = naam;
        }

        public int GeefLaatsteControlepunt()
        {
            int index;

            if (this.Aankomsttijden != null)
            {
                index = Array.FindIndex(this.Aankomsttijden, x => x != null);
            }
            else
            {
                throw new ArgumentException($"Het aantal controlepunten is nog niet geïnitialiseerd.");
            }

            if (index != -1)
            {
                return index + 1;
            }
            else
            {
                return 0;
            }
        }

        public bool HeeftAlleControlepuntenBezocht()
        {
            if (this.GeefLaatsteControlepunt() == this.Aankomsttijden.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HeeftBezocht(int i)
        {
            if (i < 0 || i >= this.Aankomsttijden.Length)
            {
                throw new ArgumentException($"{i} ligt niet in het bereik van de array.");
            }
            else if (this.Aankomsttijden[i] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RegistreerVolgendeAankomsttijd()
        {
            int index;

            if (this.Aankomsttijden != null)
            {
                index = Array.FindIndex(this.Aankomsttijden, x => x != null);
            }
            else
            {
                throw new ArgumentException($"Het aantal controlepunten is nog niet geïnitialiseerd.");
            }

            if (index != -1)
            {
                this.Aankomsttijden[index] = DateTime.Now;
            }
            else
            {
                throw new ArgumentException($"Alle controlepunten zijn al ingevuld.");
            }

            return index + 1;
        }

        public override string Valideer(string propertynaam)
        {
            string foutmelding;

            foutmelding = string.Empty;

            if (propertynaam == nameof(Naam) && string.IsNullOrWhiteSpace(Naam))
            {
                foutmelding = $"Vul een naam in.";
            }

            return foutmelding;
        }

        public void ZetAantalControlepunten(int aantal)
        {
            if (this.Aankomsttijden != null)
            {
                throw new ArgumentException($"Het aantal controlepunten is reeds geïnitialiseerd.");
            }
            else if (aantal < 1)
            {
                throw new ArgumentException($"Het aantal controlepunten moet groter dan 0 zijn.");
            }
            else
            {
                this.Aankomsttijden = new DateTime?[aantal];
            }
        }
    }
}
