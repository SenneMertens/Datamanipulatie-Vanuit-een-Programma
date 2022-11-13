using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modellenbureau_Models
{
    public class Fotomodel
    {
        private double _lengte;
        private string _naam;
        private double _pols;

        public double Lengte
        {
            get { return _lengte; } 
            set 
            {
                if (value >= 170 && value <= 195)
                {
                    _lengte = value;
                }
                else
                {
                    throw new Exception($"De ideale lengte is tussen 170 en 195.");
                }
            }
        }

        public string Naam
        {
            get { return _naam; }
            set 
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _naam = value;
                }
                else
                {
                    throw new Exception($"De naam van het model is niet ingevuld.");
                }
            }
        }

        public double Pols
        {
            get { return _pols; }
            set
            {
                if (value >= 10 && value <= 20)
                {
                    _pols = value;
                }
                else
                {
                    throw new Exception($"De ideale polsomtrek is tussen 10 en 20.");
                }
            }
        }

        public Fotomodel(double lengte, string naam, double pols)
        {
            this.Lengte = lengte;
            this.Naam = naam;
            this.Pols = pols;
        }

        public override bool Equals(object obj)
        {
            return obj is Fotomodel fotomodel && Naam == fotomodel.Naam;
        }

        public override int GetHashCode()
        {
            return -1386946022 + EqualityComparer<string>.Default.GetHashCode(Naam);
        }

        public double IdeaalGewicht()
        {
            return (this.Lengte + 4 * this.Pols - 100) / 2;
        }

        public override string ToString()
        {
            return $"{this.Naam.PadRight(25)}{this.Lengte.ToString("0.#").PadRight(10)}{this.Pols.ToString("0.#").PadRight(10)}{this.IdeaalGewicht().ToString("0.#").PadRight(10)}";
        }
    }
}
