using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenten_Models
{
    public class Student
    {
        public string Departement { get; set; }
        public string Studentnaam { get; set; }
        public string Studentnummer { get; set; }

        public Student(string studentnaam, string studentnummer)
        {
            this.Departement = $"IT";
            this.Studentnaam = studentnaam ;
            this.Studentnummer = studentnummer ;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student && Studentnummer == student.Studentnummer;
        }

        public override int GetHashCode()
        {
            return 41853580 + EqualityComparer<string>.Default.GetHashCode(Studentnummer);
        }

        public virtual string MaakDetail()
        {
            return $"{this.Studentnummer.PadRight(10)}{this.Studentnaam}";
        }

        public override string ToString()
        {
            return $"{this.Studentnaam.ToUpper()}";
        }
    }
}
