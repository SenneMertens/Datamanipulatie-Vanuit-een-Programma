using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Models
{
    public class Auto
    {
        public string Chassisnummer { get; set; }
        public string Merk { get; set; }
        public Motor Motor { get; set; }

        public Auto(string chassisnummer, string merk, Motor motor)
        {
            this.Chassisnummer = chassisnummer;
            this.Merk = merk;
            this.Motor = motor;
        }

        public override bool Equals(object obj)
        {
            return obj is Auto auto && Chassisnummer == auto.Chassisnummer;
        }

        public override int GetHashCode()
        {
            return -10659265 + EqualityComparer<string>.Default.GetHashCode(Chassisnummer);
        }

        public override string ToString()
        {
            return $"De {this.Merk} met chassisnummer {this.Chassisnummer} heeft de volgende kenmerken:{Environment.NewLine}{this.Motor.ToString()}";
        }
    }
}
