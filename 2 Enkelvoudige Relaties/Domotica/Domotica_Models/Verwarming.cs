using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domotica_Models
{
    public class Verwarming
    {
        private double _graden;

        public double Graden
        {
            get { return _graden; }
            set 
            {
                if (this.Power && value >= 0)
                {
                    _graden = value;
                }
            }
        }

        public bool Power { get; set; }

        public Verwarming()
        {
            this.Graden = 0;
            this.Power = false;
        }
    }
}
