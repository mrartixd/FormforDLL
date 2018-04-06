using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCountry
{
    public class ComboBoxItem
    {
       string displayValue;
        double hiddenValue;

        //Constructor
        public ComboBoxItem(string d, double h)
        {
            displayValue = d;
            hiddenValue = h;
        }

        //Accessor
        public double HiddenValue
        {
            get
            {
                return hiddenValue;
            }
        }

        //Override ToString method
        public override string ToString()
        {
            return displayValue;
        }
    }
}
