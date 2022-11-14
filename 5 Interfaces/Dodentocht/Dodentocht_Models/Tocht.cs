using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodentocht_Models
{
    public class Tocht : BasisKlasse, ITocht
    {
        public Controlepunt[] Controlepunten { get; set; }
        public DateTime Datum { get; set; }
        public List<Deelnemer> Deelnemers { get; set; }
        public string Naam { get; set; }

        public Tocht(string naam, DateTime datum)
        {
            this.Controlepunten = new Controlepunt[15];
            this.Naam = naam;
            this.Datum = datum;
            this.Deelnemers = new List<Deelnemer>();
        }

        public Tocht(string naam, DateTime datum, int aantalControlepunten) : this(naam, datum)
        {
            if (aantalControlepunten < 1)
            {
                throw new ArgumentException($"Het aantal controlepunten moet groter dan 0 zijn.");
            }

            this.Controlepunten = new Controlepunt[aantalControlepunten];
        }

        public int[] AantalDeelnemersPerControlepunt()
        {
            int[] resultaat;

            resultaat = new int[this.Controlepunten.Length];

            for (int i = 0; i < this.Controlepunten.Length; i++)
            {
                resultaat[i] = Deelnemers.FindAll(x => x.HeeftBezocht(i)).Count;
            }

            return resultaat;
        }

        public int AantalDeelnemersVoltooid()
        {
            int resultaat;

            resultaat = this.Deelnemers.FindAll(x => x.HeeftAlleControlepuntenBezocht()).Count;

            return resultaat;
        }

        public override string Valideer(string propertynaam)
        {
            string resultaat;

            resultaat = string.Empty;

            if (propertynaam == nameof(Naam) && string.IsNullOrWhiteSpace(Naam))
            {
                resultaat = $"Vul een naam in.{Environment.NewLine}";
            }
            else if (propertynaam == nameof(Datum) && Datum < DateTime.Now)
            {
                resultaat = $"De datum moet in de toekomst liggen.{Environment.NewLine}";
            }

            return resultaat;
        }

        public int VoegControlepuntToe(Controlepunt controlepunt)
        {
            if (controlepunt == null)
            {
                throw new ArgumentNullException($"Het controlepunt is nog niet geïnitialiseerd.");
            }

            int index;

            index = Array.FindIndex(this.Controlepunten, x => x == null);

            if (index != -1)
            {
                if (index == 0 || controlepunt.HeeftEHBOPost || this.Controlepunten[index - 1].HeeftEHBOPost)
                {
                    this.Controlepunten[index] = controlepunt;

                    return index + 1;
                }
                else
                {
                    throw new ArgumentException("Tussen 2 controlepunten zonder EHBP post moet een controlepunt met een EHBO post liggen.");
                }
            }

            throw new IndexOutOfRangeException("Alle controlepunten zijn reeds toegevoegd.");
        }

        public void VoegDeelnemerToe(Deelnemer deelnemer)
        {
            if (deelnemer == null)
            {
                throw new ArgumentNullException($"De deelnemer is nog niet geïnitialiseerd.");
            }

            deelnemer.ZetAantalControlepunten(this.Controlepunten.Length);

            this.Deelnemers.Add(deelnemer);
        }
    }
}
