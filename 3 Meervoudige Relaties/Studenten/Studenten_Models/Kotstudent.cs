using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenten_Models
{
    public class Kotstudent : Student
    {
        private string Kotadres { get; set; }
        private string Kotbaas { get; set; }

        public Kotstudent(string studentnummer, string studentnaam, string kotadres, string kotbaas) : base(studentnaam, studentnummer)
        {
            this.Kotadres = kotadres;
            this.Kotbaas = kotbaas;
        }

        public override string MaakDetail()
        {
            return $"{base.MaakDetail()}{Environment.NewLine}{new string(' ', 10)}Kotadres: {this.Kotadres.PadRight(15)}{Environment.NewLine}{new string(' ', 10)}Kotbaas: {this.Kotbaas}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} (Kotstudent)";
        }
    }
}
