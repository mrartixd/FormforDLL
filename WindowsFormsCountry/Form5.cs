using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldDatabase;

namespace WindowsFormsCountry
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Country country = new Country();
            country.Code = textBoxCode.Text;
            country.Name = textBoxName.Text;
            country.Continent = textBoxContinent.Text;
            country.Region = textBoxRegion.Text;
            country.SurfaceArea = Convert.ToDouble(textBoxSurface.Text);
            country.InderYear = Convert.ToDouble(textBoxIndep.Text);
            country.Population = Convert.ToDouble(textBoxPopulation.Text);
            country.GovernmentForm = textBoxGov.Text;
            country.HeadOfState = textBoxHead.Text;


            int arv = CountryDB.InsertNewCountry(country);
            if (arv != 0)
            {
                MessageBox.Show("Oli lisatud " + arv + " rida", "Valmis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Form1 form = new Form1();
                form.Refresh();
            }
            else
            { MessageBox.Show("Lisamine ebaõnnestus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBoxSurface_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxIndep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxPopulation_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
