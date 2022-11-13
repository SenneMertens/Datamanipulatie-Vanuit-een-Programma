using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benzinepomp_Models
{
    public class Tankmechanisme
    {
        public int GevraagdAantal { get; set; }
        public Pomp Pomp { get; set; }

        public Tankmechanisme()
        {
            this.GevraagdAantal = 0;
            this.Pomp = new Pomp();
        }

        public string StandVanZaken()
        {
            int stand;

            stand = this.Pomp.Stand();

            if (!this.Pomp.Actief)
            {
                return $"De pomp is nog niet gestart.";
            }
            else if (this.GevraagdAantal <= this.Pomp.Stand())
            {
                this.Pomp.Actief = false;

                return $"Genoeg getankt. De pomp is gestopt na {stand} liter.";
            }
            else
            {
                return $"De pomp is aan het tanken. Al {this.Pomp.Stand()} liter getankt.";
            }
        }

        public void Start()
        {
            this.Pomp.Start();
        }
    }
}
