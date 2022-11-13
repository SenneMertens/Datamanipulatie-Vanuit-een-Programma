using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Auto_Models;
using System.Security.Cryptography.X509Certificates;

namespace Auto_DAL
{
    public static class FileOperations
    {
        public static List<string> LeesMerken(string bestandsnaam)
        {
            List<string> lijstMotors = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(bestandsnaam))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (!lijstMotors.Contains(line))
                        {
                            lijstMotors.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return lijstMotors;
        }

        public static List<Motor> LeesMotor(string bestandsnaam)
        {
            List<Motor> lijstMotor = new List<Motor>();
            List<string> gegevens = null;

            try
            {
                using (StreamReader reader = new StreamReader(bestandsnaam))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        gegevens = line.Split(';').ToList();

                        if (int.TryParse(gegevens[0], out int cilinderinhoud) && int.TryParse(gegevens[1], out int pk))
                        {
                            Motor motor = new Motor(cilinderinhoud, pk);

                            if (!lijstMotor.Contains(motor))
                            {
                                lijstMotor.Add(motor);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }

            return lijstMotor;
        }
        
        public static void SchrijfMotor(string bestandsnaam, Motor motor)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(bestandsnaam, true))
                {
                    writer.WriteLine($"{motor.Cilinderinhoud};{motor.PK}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{bestandsnaam} bestaat niet.");
            }
        }
    }
}
