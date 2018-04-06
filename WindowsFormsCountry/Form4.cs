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
            double id = ((ComboBoxItem)comboBox1.SelectedItem).HiddenValue;
            int check = CountryDB.DeleteCity(id);
            if (check == 1)
            {
                MessageBox.Show("An Item has been successfully deleted", "Delete Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            List<City> city = new List<City>();
            city = CountryDB.GetAllCities();
            foreach (City c in city)
            {
                comboBox1.Items.Add(new ComboBoxItem(c.Name, c.ID));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label3.Visible = true;
             //label3.Text = ((ComboBoxItem)comboBox1.SelectedItem).HiddenValue.ToString();
        }
    }
}
