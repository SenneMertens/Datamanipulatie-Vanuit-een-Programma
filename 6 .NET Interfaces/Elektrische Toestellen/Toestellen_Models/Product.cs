using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toestellen_Models
{
    public abstract class Product : Basisklasse
    {
        public string Beschrijving { get; set; }
        public string Code { get; set; }
        public double Prijs { get; set; }
        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Beschrijving) && string.IsNullOrWhiteSpace(Beschrijving))
                {
                    return $"Vul een beschrijving in.";
                }
                else if (columnName == nameof(Code) && string.IsNullOrWhiteSpace(Code))
                {
                    return $"Vul een code in.";
                }
                else if (columnName == nameof(Prijs) && Prijs < 0)
                {
                    return $"De prijs moet groter dan of gelijk zijn aan 0.";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private protected Product(string beschrijving, string code, double prijs)
        {
            this.Beschrijving = beschrijving;
            this.Code = code;
            this.Prijs = prijs;
        }

        public Product() : this(string.Empty, string.Empty, 0)
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Product product && Code == product.Code;
        }

        public override int GetHashCode()
        {
            return -434485196 + EqualityComparer<string>.Default.GetHashCode(Code);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name.PadRight(15)}{this.Beschrijving.PadRight(30)}{this.Prijs.ToString("0.##")}€";
        }

        public virtual string ToStringCompact()
        {
            return $"{this.GetType().Name};{this.Code};{this.Beschrijving};{this.Prijs.ToString("0.##")}";
        }
    }
}
