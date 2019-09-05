using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OneWayTwoWayBinding
{
    public class OnlyIntOrNullRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int result = 0;
            bool canConvert = int.TryParse(value as string, out result);
            if(string.IsNullOrEmpty(value.ToString()))
            {
                canConvert = true;
            }
            //MessageBox.Show(value.ToString());
            return new ValidationResult(canConvert, "Not a number");
        }
    }
    public class RequiredValuesToAddRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            bool RequiredValue = false;
            if ((string)value == string.Empty)
            {
                //MessageBox.Show("EMPTY");
                RequiredValue = false;
                //MessageBox.Show(value.ToString());
            }
            //else if ((string)value == "Ad")
            //{
            //    //MessageBox.Show("NOTEMPTY");
            //    RequiredValue = false;
            //    //MessageBox.Show(value.ToString());
            //}
            else if ((string)value != string.Empty)
            {
                //MessageBox.Show("NOTEMPTY");
                RequiredValue = true;
                //MessageBox.Show(value.ToString());
            }
            return new ValidationResult(RequiredValue, "Value cannot be null");
        }

    }
}


//<MultiBinding.ValidationRules>
//                        <local:RequiredValuesToAddRule ValidatesOnTargetUpdated = "True" />
//                    </ MultiBinding.ValidationRules >