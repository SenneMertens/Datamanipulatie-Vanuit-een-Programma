using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benzinepomp_Models
{
    public class Pomp
    {
        public bool Actief { get; set; }
        private int Debiet { get; set; }
        private DateTime Startmoment { get; set; }

        public Pomp()
        {
            Random random = new Random();

            this.Actief = false;
            this.Debiet = random.Next(5, 11);            
        }

        public int Stand()
        {
            if (this.Actief)
            {
                return this.Debiet * this.VerschilInTijd();
            }
            else
            {
                return 0;
            }
        }

        public void Start()
        {
            this.Actief = true;
            this.Startmoment = DateTime.Now;
        }

        public int Stop()
        {
            this.Actief = false;

            return this.Stand();
        }

        private int VerschilInTijd()
        {
            DateTime nu = DateTime.Now;
            TimeSpan verschil = nu.Subtract(this.Startmoment);
            return verschil.Hours * 3600 + verschil.Minutes * 60 + verschil.Seconds;
        }
    }
}
