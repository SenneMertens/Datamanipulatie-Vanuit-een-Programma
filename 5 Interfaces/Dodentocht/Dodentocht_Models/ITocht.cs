using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodentocht_Models
{
    public interface ITocht
    {
        Controlepunt[] Controlepunten { get; }
        DateTime Datum { get; }
        List<Deelnemer> Deelnemers { get; }
        string Naam { get; }

        int[] AantalDeelnemersPerControlepunt();

        int AantalDeelnemersVoltooid();

        int VoegControlepuntToe(Controlepunt controlepunt);

        void VoegDeelnemerToe(Deelnemer deelnemer);
    }
}
