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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List<Country> country = new List<Country>();
            country = CountryDB.GetAllCountries();
            foreach (Country c in country)
                comboBox1.Items.Add(c.Code);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            City city = new City();
            city.Name = textBox1.Text;
            city.CountryCode = comboBox1.Text;
            city.District = textBox2.Text;
            city.Population = double.Parse(textBox3.Text);

            int arv = CountryDB.InsertNewCity(city);
            if (arv != 0)
            { MessageBox.Show("Oli lisatud " + arv + " rida", "Valmis",MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1 frm = new Form1();
            frm.Refresh();
            }
            else
            { MessageBox.Show("Lisamine ebaõnnestus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
