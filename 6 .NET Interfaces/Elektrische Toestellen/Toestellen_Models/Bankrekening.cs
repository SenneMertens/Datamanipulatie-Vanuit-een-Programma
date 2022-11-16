using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toestellen_Models
{
    public class Bankrekening : Basisklasse
    {
        public string Ibannummer { get; set; }
        public double Minimum { get; }
        public double Saldo { get; private set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Ibannummer) && string.IsNullOrWhiteSpace(Ibannummer))
                {
                    return $"Vul een ibannummer in.";
                }
                else if (columnName == nameof(Minimum) && Minimum < this.Saldo)
                {
                    return $"Het saldo moet groter dan het minimum zijn.";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public Bankrekening(string ibannummer) 
        {
            this.Ibannummer = ibannummer;
            this.Minimum = -100;
            this.Saldo = 0;
        }

        public bool Afhalen(double bedrag)
        {
            bedrag = Math.Abs(bedrag);

            if (this.Saldo - bedrag >= this.Minimum)
            {
                this.Saldo -= bedrag;

                return true;
            }
            else
            {
                return false;
            }

        }

        public override bool Equals(object obj)
        {
            return obj is Bankrekening bankrekening && Ibannummer == bankrekening.Ibannummer;
        }

        public override int GetHashCode()
        {
            return -917190795 + EqualityComparer<string>.Default.GetHashCode(Ibannummer);
        }

        public void Storten(double bedrag)
        {
            bedrag = Math.Abs(bedrag);

            this.Saldo += bedrag;
        }

        public override string ToString()
        {
            return $"Het saldo van de rekening {this.Ibannummer} bedraagt {Conversies.ConverteerNumeriekNaarValuta(this.Saldo)} €.";
        }
    }
}
