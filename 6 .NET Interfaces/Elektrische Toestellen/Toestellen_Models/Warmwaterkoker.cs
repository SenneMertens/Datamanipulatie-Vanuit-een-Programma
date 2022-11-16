using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toestellen_Models
{
    public class Warmwaterkoker : ElektrischToestel
    {
        public double Inhoud { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Inhoud) && Inhoud < 0)
                {
                    return $"De inhoud moet groter dan of gelijk zijn aan 0.";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public Warmwaterkoker(string beschrijving, string code, double prijs, string merk, string type, double inhoud) : base(beschrijving, code, prijs, merk, type)
        {
            this.Inhoud = inhoud;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Inhoud: {this.Inhoud}";
        }

        public override string ToStringCompact()
        {
            return base.ToStringCompact() + $";{this.Inhoud}";
        }
    }
}
