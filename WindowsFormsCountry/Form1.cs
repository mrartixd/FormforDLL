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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  ConnectionDatabase.connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=world.mdb;Persist Security Info=True";
            //  asub Program.cs failis
            
            List<Country> country=new List<Country>();
            country=CountryDB.GetAllCountries();

            DataTable table = new DataTable();

            DataColumn idColumn = table.Columns.Add("Name", typeof(string));
                                  table.Columns.Add("Code", typeof(string));
                                  table.Columns.Add("Continent", typeof(string));
                                  table.Columns.Add("Year", typeof(int));

                                  table.PrimaryKey = new DataColumn[] { idColumn };

            foreach(Country c in country)
            {
                table.Rows.Add(new object[] { c.Name, c.Code,c.Continent,c.InderYear});
            }
            table.AcceptChanges();
            dataGridViewCountry.DataSource = table;
        }

       

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            taidalist();
            dataGridViewCity.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            dataGridViewCity.Update();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void dataGridViewCountry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
           
             taidalist();
            dataGridViewCity.Refresh();
           
        }
      private   void taidalist()
        {
            if (dataGridViewCountry.SelectedCells.Count == 1)
            {   // otsime valitud rea riigi nimetus
                int selectedrowindex = dataGridViewCountry.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridViewCountry.Rows[selectedrowindex];

                label1.Text = Convert.ToString(selectedRow.Cells[0].Value);



                List<City> city = new List<City>();
                city = CountryDB.GetAllCitiesbyCountryName(label1.Text);

                DataTable table = new DataTable();

                DataColumn idColumn = table.Columns.Add("Name", typeof(string));
                table.Columns.Add("District", typeof(string));

                table.Columns.Add("Population", typeof(long));

                table.PrimaryKey = new DataColumn[] { idColumn };

                foreach (City c in city)
                {
                    table.Rows.Add(new object[] { c.Name, c.District, c.Population });
                }
                table.AcceptChanges();
                dataGridViewCity.DataSource = table;

            }  
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 deletec = new Form4();
            deletec.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 newcountry = new Form5();
            newcountry.Show();
        }
    }
}
