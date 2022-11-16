using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toestellen_Models
{
    public class Boek : Product
    {
        public string Auteur { get; set; }
        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Auteur) && string.IsNullOrWhiteSpace(Auteur))
                {
                    return $"Vul een auteur in.";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public Boek(string beschrijving, string code, double prijs, string auteur) : base(beschrijving, code, prijs)
        {
            this.Auteur = auteur;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Auteur: {this.Auteur}";
        }

        public override string ToStringCompact()
        {
            return base.ToStringCompact() + $";{this.Auteur}";
        }
    }
}
