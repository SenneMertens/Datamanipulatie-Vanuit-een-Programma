using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toestellen_Models
{
    public class Persoon
    {
        public List<Boek> Boeken { get; }
        public Bankrekening Bankrekening { get; set; }
        public List<ElektrischToestel> ElektrischeToestellen { get; }
        public string Naam { get; set; }
        public string Rijksregisternummer { get; set; }

        public Persoon(string naam, string rijksregisternummer)
        {
            this.Boeken = new List<Boek>();
            this.Bankrekening = null;
            this.ElektrischeToestellen = new List<ElektrischToestel>();
            this.Naam = naam;
            this.Rijksregisternummer = rijksregisternummer;
        }

        public bool? Afhalen(double bedrag)
        {
            return Bankrekening?.Afhalen(bedrag);
        }

        public bool KoopProduct(Product product)
        {
            if (Afhalen(product.Prijs) == true)
            {
                if (product is Boek boek)
                {
                    this.Boeken.Add(boek);
                }
                else if (product is ElektrischToestel elektrischToestel)
                {
                    this.ElektrischeToestellen.Add(elektrischToestel);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Storten(double bedrag)
        {
            if (this.Bankrekening != null)
            {
                this.Bankrekening.Storten(bedrag);

                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string resultaat;

            resultaat = $"{this.Naam} met rijksregisternummer {this.Rijksregisternummer} bezit het volgende:{Environment.NewLine}{Environment.NewLine}";

            if (Boeken.Count > 0)
            {
                resultaat += $"Boeken:{Environment.NewLine}{Environment.NewLine}";

                Boeken.ForEach(x => resultaat += $"{x.ToString()}{Environment.NewLine}{Environment.NewLine}");
            }

            if (ElektrischeToestellen.Count > 0)
            {
                resultaat += $"Elektrische Toestellen:{Environment.NewLine}{Environment.NewLine}";

                ElektrischeToestellen.ForEach(x => resultaat += $"{x.ToString()}{Environment.NewLine}{Environment.NewLine}");
            }

            return resultaat;
        }
    }
}
