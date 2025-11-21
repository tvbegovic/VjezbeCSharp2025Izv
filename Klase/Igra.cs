using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    internal class Igra
    {
        private string naziv;
        private string opis;
        private string vrsta;
        private DateTime datumIzdavanja;
        private double cijena;
        private string izdavac;

        public string Naziv 
        {
            get
            {
                return naziv;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Naziv ne smije biti prazan");
                naziv = value;
            }
        }

        public string Opis { get => opis; set => opis = value; }
        public string Vrsta { get => vrsta; set => vrsta = value; }
        public DateTime DatumIzdavanja { get => datumIzdavanja; set => datumIzdavanja = value; }
        public double Cijena { get => cijena;   
            set 
            {
                if (value < 0)
                    throw new ArgumentException("Cijena ne smije biti negativna");
                cijena = value; 
            } 
        }
        public string Izdavac { get => izdavac; set => izdavac = value; }
    }
}
