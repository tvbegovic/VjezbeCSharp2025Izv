using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaRijeci
{
    public partial class Glavna : Form
    {
        List<string> rijeci = new List<string>();
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnDodajNaKraj_Click(object sender, EventArgs e)
        {
            string rijec = txtJednaRijec.Text;
            rijeci.Add(rijec);
            OsvjeziListBox();
        }

        void OsvjeziListBox()
        {
            lstRijeci.DataSource = null;
            lstRijeci.DataSource = rijeci;
        }

        private void btnDodajNaPoziciju_Click(object sender, EventArgs e)
        {
            string rijec = txtJednaRijec.Text;
            string unos = txtPozicija.Text;
            bool ok = int.TryParse(unos, out int pozicija);
            if(!ok)
            {
                MessageBox.Show("Pogrešan format");
                return;
            }
            if(pozicija < 0 || pozicija >= rijeci.Count)
            {
                MessageBox.Show("Pozicija nije u rasponu");
                return;
            }
            rijeci.Insert(pozicija, rijec);
            OsvjeziListBox();
        }
    }
}
