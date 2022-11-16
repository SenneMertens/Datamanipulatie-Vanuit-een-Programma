using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toestellen_Models
{
    public abstract class Basisklasse : IDataErrorInfo
    {
        public string Error
        {
            get
            {
                string foutmeldingen;

                foutmeldingen = string.Empty;

                foreach(var property in this.GetType().GetProperties())
                {
                    if (property.CanRead && property.CanWrite)
                    {
                        string fout;

                        fout = this[property.Name];

                        if (!string.IsNullOrWhiteSpace(fout))
                        {
                            foutmeldingen += $"{fout}{Environment.NewLine}";
                        }
                    }
                }

                return foutmeldingen;
            }
        }

        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Error);
        }

        public abstract string this[string columnName] { get; }
    }
}
