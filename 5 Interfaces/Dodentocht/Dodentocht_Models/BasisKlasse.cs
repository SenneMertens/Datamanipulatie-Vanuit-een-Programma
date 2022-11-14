using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodentocht_Models
{
    public abstract class BasisKlasse
    {
        public string Foutmeldingen
        {
            get
            {
                string foutmeldingen;

                foutmeldingen = string.Empty;

                foreach (var property in this.GetType().GetProperties())
                {
                    string fout;

                    fout = Valideer(property.Name);

                    if (!string.IsNullOrWhiteSpace(fout))
                    {
                        foutmeldingen += fout;
                    }
                }

                return foutmeldingen;
            }
        }

        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Foutmeldingen);
        }

        public abstract string Valideer(string propertynaam);
    }
}
