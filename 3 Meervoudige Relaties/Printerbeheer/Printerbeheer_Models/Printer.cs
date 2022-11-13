using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printerbeheer_Models
{
    public class Printer
    {
        public bool Bezig { get; set; }
        public string Naam { get; set; }

        public Printer(string naam)
        {
            this.Bezig = false;
            this.Naam = naam;
        }

        public void Reset()
        {
            this.Bezig = false;
        }

        public override string ToString()
        {
            if (!this.Bezig)
            {
                return $"{this.Naam} is niet bezig en wacht op een printopdracht.";
            }
            else
            {
                return $"{this.Naam} is bezig met een printopdracht.";
            }
        }
    }
}
