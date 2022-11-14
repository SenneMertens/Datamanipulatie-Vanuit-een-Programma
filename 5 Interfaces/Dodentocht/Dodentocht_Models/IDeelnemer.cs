using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodentocht_Models
{
    public interface IDeelnemer
    {
        DateTime?[] Aankomsttijden { get; }
        string Naam { get; }

        int GeefLaatsteControlepunt();

        bool HeeftAlleControlepuntenBezocht();

        bool HeeftBezocht(int i);

        int RegistreerVolgendeAankomsttijd();

        void ZetAantalControlepunten(int aantal);
    }
}
