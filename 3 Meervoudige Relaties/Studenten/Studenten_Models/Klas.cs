using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenten_Models
{
    public class Klas
    {
        public string Klasnaam { get; set; }
        public List<Student> Studenten { get; }

        public Klas(string klasnaam)
        {
            this.Klasnaam = klasnaam;
            this.Studenten= new List<Student>();
        }

        public override bool Equals(object obj)
        {
            return obj is Klas klas && Klasnaam == klas.Klasnaam;
        }

        public override int GetHashCode()
        {
            return 264930281 + EqualityComparer<string>.Default.GetHashCode(Klasnaam);
        }

        public string MaakLijst()
        {
            string resultaat;

            resultaat = $"Namenlijst van {this.Klasnaam}:{Environment.NewLine}";

            Studenten.ForEach(x => resultaat += $"{x.ToString()}{Environment.NewLine}");

            return resultaat;
        }

        public string MaakUitgebreideLijst()
        {
            string resultaat;

            resultaat = $"Namenlijst van {this.Klasnaam}:{Environment.NewLine}";

            Studenten.ForEach(x => resultaat += $"{x.MaakDetail()}{Environment.NewLine}");

            return resultaat;
        }

        public void VoegStudentToe(Student student)
        {
            if (!Studenten.Contains(student))
            {
                Studenten.Add(student);
            }
            else
            {
                throw new Exception($"{student.Studentnaam} zit al in de lijst.");
            }
        }
    }
}
