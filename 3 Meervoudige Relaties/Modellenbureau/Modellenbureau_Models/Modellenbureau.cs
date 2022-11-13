using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modellenbureau_Models
{
    public class Modellenbureau
    {
        private string _naamBedrijf;

        public List<Fotomodel> Modellen { get; }

        public string NaamBedrijf 
        {
            get { return _naamBedrijf; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _naamBedrijf= value;
                }
                else
                {
                    throw new Exception($"De bedrijfsnaam is niet ingevuld.");
                }
            }
        }

        public Modellenbureau(string bedrijfsnaam)
        {
            this.NaamBedrijf = bedrijfsnaam;
            this.Modellen= new List<Fotomodel>();
        }

        public string DrukSlank()
        {
            string resultaat;

            resultaat = $"{this.NaamBedrijf} heeft de volgende superslanke modellen in dienst:{Environment.NewLine}";

            Modellen.Where(x => x.IdeaalGewicht() < 60).ToList().ForEach(x => resultaat += $"{x.ToString()}{Environment.NewLine}");

            return resultaat;
        }

        public override bool Equals(object obj)
        {
            return obj is Modellenbureau modellenbureau && NaamBedrijf == modellenbureau.NaamBedrijf;
        }

        public override int GetHashCode()
        {
            return -1172016032 + EqualityComparer<string>.Default.GetHashCode(NaamBedrijf);
        }

        public override string ToString()
        {
            string resultaat;

            resultaat = $"Bureau {this.NaamBedrijf}{Environment.NewLine}";

            Modellen.ForEach(x => resultaat += $"{x.ToString()}{Environment.NewLine}");

            return resultaat;
        }

        public void VoegToe(Fotomodel fotomodel)
        {
            if (!Modellen.Contains(fotomodel))
            {
                Modellen.Add(fotomodel);
            }
            else
            {
                throw new Exception($"{fotomodel.Naam} zit al in de lijst.");
            }
        }

        public void VoegToe(double lengte, string naam, double pols)
        {
            Fotomodel fotomodel = new Fotomodel(lengte, naam, pols);

            if (!Modellen.Contains(fotomodel))
            {
                Modellen.Add(fotomodel);
            }
            else
            {
                throw new Exception($"{fotomodel.Naam} zit al in de lijst.");
            }
        }
    }
}
