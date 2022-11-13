using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Models
{
    public class Motor
    {
        public int Cilinderinhoud { get; set; }
        public int PK { get; set; }

        public Motor(int cilinderinhoud, int pk)
        {
            this.Cilinderinhoud = cilinderinhoud;
            this.PK = pk;
        }

        public override string ToString()
        {
            return $"Cilinderinhoud: {this.Cilinderinhoud} - PK: {this.PK}";
        }

        public override bool Equals(object obj)
        {
            return obj is Motor motor && Cilinderinhoud == motor.Cilinderinhoud && PK == motor.PK;
        }

        public override int GetHashCode()
        {
            int hashCode = -970975100;
            hashCode = hashCode * -1521134295 + Cilinderinhoud.GetHashCode();
            hashCode = hashCode * -1521134295 + PK.GetHashCode();
            return hashCode;
        }
    }
}
