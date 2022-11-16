using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Toestellen_Models;

namespace Toestellen_DAL
{
    public static class FileOperations
    {
        public static List<Product> BestandInlezen(string bestandsnaam)
        {
            List<Product> lijstProducten = new List<Product>();
            List<string> gegevens = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(bestandsnaam))
                {
                    while(!reader.EndOfStream)
                    {
                        Product product;
                        string lijn;
                        
                        product = null;
                        lijn = reader.ReadLine();

                        gegevens = lijn.Split(';').ToList();
                       
                        switch (gegevens[0].ToLower())
                        {
                            case "boek":
                                if (double.TryParse(gegevens[3], out double prijsBoek))
                                {
                                    product = new Boek(gegevens[2], gegevens[1], prijsBoek, gegevens[4]);                                   
                                }
                                break;

                            case "televisie":
                                if (double.TryParse(gegevens[3], out double prijsTelevisie) && int.TryParse(gegevens[6], out int beeldgrootte) && int.TryParse(gegevens[7], out int herz))
                                {
                                    product = new Televisie(gegevens[2], gegevens[1], double.Parse(gegevens[3]), gegevens[4], gegevens[5], beeldgrootte, herz);
                                }
                                break;

                            case "warmwaterkoker":
                                if (double.TryParse(gegevens[3], out double prijsWarmwaterkoker) && double.TryParse(gegevens[5], out double inhoud))
                                {
                                    product = new Warmwaterkoker(gegevens[2], gegevens[1], prijsWarmwaterkoker, gegevens[4], gegevens[5], inhoud);
                                }
                                break;
                        }

                        if (!lijstProducten.Contains(product))
                        {
                            lijstProducten.Add(product);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }

            return lijstProducten;
        }

        public static void VoegProductToe(Product product)
        {
            using (StreamWriter writer = new StreamWriter("Producten.txt", true))
            {
                writer.WriteLine(product.ToStringCompact());
            }
        }

        public static void FoutLoggen(Exception fout)
        {
            using (StreamWriter writer = new StreamWriter("Foutenbestand.txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                writer.WriteLine(fout.GetType().Name);
                writer.WriteLine(fout.Message);
                writer.WriteLine(fout.StackTrace);
                writer.WriteLine(new String('-', 80));
                writer.WriteLine();
            }
        }
    }
}
