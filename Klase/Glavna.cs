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
    }
}
