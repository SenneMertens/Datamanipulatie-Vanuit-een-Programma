using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodentocht_Models
{
    public interface IControlepunt
    {
        double Breedtegraad { get; }
        bool HeeftEHBOPost { get; }
        double Lengtegraad { get; }
        string Naam { get; }
    }
}
