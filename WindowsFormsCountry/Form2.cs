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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //  ConnectionDatabase.connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=world.mdb;Persist Security Info=True";
            //  asub Program.cs failis
            
            List<Country> country = new List<Country>();
            country = CountryDB.GetAllCountries();
            foreach (Country c in country)
                comboBox1.Items.Add(c.Name);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<City> city = new List<City>();
            city = CountryDB.GetAllCitiesbyCountryName(comboBox1.Text);

            DataTable table = new DataTable();

            //DataColumn idColumn = table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("District", typeof(string));
           
            table.Columns.Add("Population", typeof(long));

            //table.PrimaryKey = new DataColumn[] { idColumn };

            foreach (City c in city)
            {
                table.Rows.Add(new object[] { c.Name, c.District, c.Population });
            }
            table.AcceptChanges();
            dataGridView1.DataSource = table;

        }
    }
}
