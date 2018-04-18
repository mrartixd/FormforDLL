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
            country.SurfaceArea = Convert.ToInt32(textBoxSurface.Text);
            country.InderYear = Convert.ToDouble(textBoxIndep.Text);
            country.Population = Convert.ToDouble(textBoxPopulation.Text);
            country.GovernmentForm = textBoxGov.Text;
            country.HeadOfState = textBoxHead.Text;
            //country.Capital = Convert.ToInt32(textBoxCap.Text);


            int arv = CountryDB.InsertNewCountry(country);
            if (arv != 0)
            {
                MessageBox.Show("Oli lisatud " + arv + " rida", "Valmis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            { MessageBox.Show("Lisamine ebaõnnestus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


    }
}
