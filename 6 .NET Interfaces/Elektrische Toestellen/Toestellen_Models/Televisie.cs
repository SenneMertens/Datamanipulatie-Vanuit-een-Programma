using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toestellen_Models
{
    public class Televisie : ElektrischToestel
    {
        public int Beeldgrootte { get; set; }
        public int Herz { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Beeldgrootte) && Beeldgrootte < 0)
                {
                    return $"De beeldgrootte moet groter dan of gelijk zijn aan 0";
                }
                else if (columnName == nameof(Herz) && Herz < 0)
                {
                    return $"De hoeveelheid Herz moet groter dan of gelijk zijn aan 0.";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public Televisie(string beschrijving, string code, double prijs, string merk, string type, int beeldgrootte, int herz) : base(beschrijving, code, prijs, merk, type)
        {
            this.Beeldgrootte = beeldgrootte;
            this.Herz = herz;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Beeldgrootte: {this.Beeldgrootte.ToString("0.##")}{Environment.NewLine}Herz: {this.Herz.ToString("0.##")}";
        }

        public override string ToStringCompact()
        {
            return base.ToStringCompact() + $";{this.Beeldgrootte.ToString("0.##")};{this.Herz.ToString("0.##")}";
        }
    }
}
