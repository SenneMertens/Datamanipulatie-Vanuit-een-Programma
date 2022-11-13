using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domotica_Models
{
    public class PLC
    {
        public Lichten Keukenlichten { get; private set; }
        public Lichten Livinglichten { get; private set; }
        public Verwarming Verwarming { get; private set; }

        public PLC(Lichten keukenlichten, Lichten livinglichten, Verwarming verwarming)
        {
            this.Keukenlichten= keukenlichten;
            this.Livinglichten= livinglichten;
            this.Verwarming= verwarming;
        }

        public void DoeKeukenlichtenAan()
        {
            this.Keukenlichten.Power = true;
        }

        public void DoeKeukenlichtenUit()
        {
            this.Keukenlichten.Power = false;
        }

        public void DoeLivinglichtenAan()
        {
            this.Livinglichten.Power = true;
        }

        public void DoeLivinglichtenUit()
        {
            this.Livinglichten.Power = false;
        }

        public void PasTemperatuurAan(double graden)
        {
            this.Verwarming.Graden = graden;
        }

        public void ZetVerwarmingInAanwezigStand()
        {
            this.Verwarming.Graden = 21;
        }

        public void ZetVerwarmingInAfwezigStand()
        {
            this.Verwarming.Graden = 18;
        }
    }
}
