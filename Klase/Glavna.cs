using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klase
{
    public partial class Glavna : Form
    {
        List<Igra> igre = new List<Igra>();
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            string naziv = txtNaziv.Text;
            string opis = txtOpis.Text;
            string vrsta = txtVrsta.Text;
            bool ok = DateTime.TryParse(txtDatum.Text, out DateTime datum);
            if(!ok)
            {
                MessageBox.Show("Pogrešan format datuma");
                return;
            }
            ok = double.TryParse(txtCijena.Text, out double cijena);
            if (!ok)
            {
                MessageBox.Show("Pogrešan format cijene");
                return;
            }
            string izdavac = txtIzdavac.Text;
            Igra igra = new Igra();
            try
            {
                igra.Naziv = naziv;
                igra.Opis = opis;
                igra.Vrsta = vrsta;
                igra.DatumIzdavanja = datum;
                igra.Cijena = cijena;
                igra.Izdavac = izdavac;
                igre.Add(igra);
                AzurirajGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška. Tekst: {ex.Message}");
            }
        }

        void AzurirajGrid()
        {
            dgvIgre.DataSource = null;
            dgvIgre.DataSource = igre;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            StreamWriter datoteka = new StreamWriter("igre.txt");
            foreach (var igra in igre)
            {
                datoteka.WriteLine($"{igra.Naziv};{igra.Opis};{igra.Vrsta};{igra.DatumIzdavanja};{igra.Cijena};{igra.Izdavac}");
            }
            datoteka.Close();
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            string[] redci = File.ReadAllLines("igre.txt");
            foreach (var redak in redci)
            {
                string[] stupci = redak.Split(';');
                Igra igra = new Igra();
                igra.Naziv = stupci[0];
                igra.Opis = stupci[1];
                igra.Vrsta = stupci[2];
                bool ok = DateTime.TryParse(stupci[3], out DateTime datum);
                if (ok)
                    igra.DatumIzdavanja = datum;
                ok = double.TryParse(stupci[4], out double cijena);
                if (ok)
                    igra.Cijena = cijena;
                igra.Izdavac = stupci[5];
                igre.Add(igra);
            }
            AzurirajGrid();
        }
    }
}
