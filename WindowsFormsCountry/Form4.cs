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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            List<City> city = new List<City>();
            city = CountryDB.GetAllCities();
            foreach (City r in city)
            {
                comboBox1.Items.Add(new ComboBoxItem(r.Name, Convert.ToString(r.ID)));
            }


            List<Country> country = new List<Country>();
            country = CountryDB.GetAllCountries();
            foreach(Country r in country)
            {
                comboBox2.Items.Add(new ComboBoxItem(r.Name, r.Code));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int arv = CountryDB.DeleteCity(Convert.ToInt32(((ComboBoxItem)comboBox1.SelectedItem).HiddenValue));
            if (arv != 0)
            {
                MessageBox.Show("Oli delete " + arv + " rida", "Valmis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            { MessageBox.Show("Delete ebaõnnestus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int arv = CountryDB.DeleteCountry(((ComboBoxItem)comboBox2.SelectedItem).HiddenValue);
            if (arv != 0)
            {
                MessageBox.Show("Oli delete " + arv + " rida", "Valmis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            { MessageBox.Show("Delete ebaõnnestus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
