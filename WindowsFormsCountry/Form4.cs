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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            List<City> city = new List<City>();
            city = CountryDB.GetAllCities();
            foreach (City c in city)
                comboBox1.Items.Add(c.Name);
        }
    }
}
