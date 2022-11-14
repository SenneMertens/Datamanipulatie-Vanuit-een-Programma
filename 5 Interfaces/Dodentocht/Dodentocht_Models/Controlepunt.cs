using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodentocht_Models
{
    public class Controlepunt : BasisKlasse, IControlepunt
    {
        public double Breedtegraad { get; set; }
        public bool HeeftEHBOPost { get; set; }
        public double Lengtegraad { get; set; }
        public string Naam { get; set; }

        public Controlepunt(string naam, double breedtegraad, double lengtegraad, bool heeftEHBOPost)
        {
            this.Naam = naam;
            this.Breedtegraad = breedtegraad;
            this.Lengtegraad = lengtegraad;
            this.HeeftEHBOPost = heeftEHBOPost;
        }

        public override string Valideer(string propertynaam)
        {
            string foutmelding;

            foutmelding = string.Empty;

            if (propertynaam == nameof(Breedtegraad) && (Breedtegraad < 4 || Breedtegraad > 5))
            {
                foutmelding = $"De breedtegraad moet tussen 4 en 5 liggen.{Environment.NewLine}";
            }
            else if (propertynaam == nameof(Naam) && string.IsNullOrWhiteSpace(Naam))
            {
                foutmelding = $"Vul een naam in.{Environment.NewLine}";
            }
            else if (propertynaam == nameof(Lengtegraad) && (Lengtegraad < 50 || Lengtegraad > 51))
            {
                foutmelding = $"De lengtegraad moet tussen 50 en 51 liggen.{Environment.NewLine}";
            }

            return foutmelding;
        }
    }
}
