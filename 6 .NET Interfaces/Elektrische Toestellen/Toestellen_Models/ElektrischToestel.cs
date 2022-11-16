using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toestellen_Models
{
    public abstract class ElektrischToestel : Product
    {
        public string Merk { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Merk) && string.IsNullOrWhiteSpace(Merk))
                {
                    return $"Vul een merk in.";
                }
                else if (columnName == nameof(Type) && string.IsNullOrWhiteSpace(Type))
                {
                    return $"Vul een type in.";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string Type { get; set; }

        private protected ElektrischToestel(string beschrijving, string code, double prijs, string merk, string type) : base(beschrijving, code, prijs)
        {
            this.Merk = merk;
            this.Type = type;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Merk: {this.Merk}{Environment.NewLine}Type: {this.Type}";
        }

        public override string ToStringCompact()
        {
            return base.ToStringCompact() + $";{this.Merk};{this.Type}";
        }
    }
}
