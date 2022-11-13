using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printerbeheer_Models
{
    public class PC
    {
        List<Printer> Printers { get; }

        public PC()
        {
            Printers = new List<Printer>();
        }

        public Printer DrukAf()
        {
            foreach (Printer printer in Printers)
            {
                if (!printer.Bezig)
                {
                    printer.Bezig = true;

                    return printer;
                }
            }

            return null;
        }

        public void VoegPrinterToe(Printer printer)
        {
            Printers.Add(printer);
        }
    }
}
