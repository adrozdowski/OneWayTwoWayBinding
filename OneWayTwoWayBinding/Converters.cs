﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace OneWayTwoWayBinding
{
    public class ConverterStringFiltering : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] == DependencyProperty.UnsetValue)
            {
                value[0] = null;
            }

            object result;
            result = value[1] == null ? value[0] : value[1].ToString();
            //if (result != null)
            //    MessageBox.Show(value[1].ToString());
            return result;
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            object[] values = new object[2];
            

            if ((string)value == string.Empty)
            {
                //MessageBox.Show(value.ToString());
                values[1] = string.Empty;
            }

            if ((string)value != string.Empty)
            {
                //MessageBox.Show(value.ToString());
                values[1] = value.ToString();
            }
            return values;
        }
    }

    public class ConverterIntFiltering : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] == DependencyProperty.UnsetValue)
            {
                value[0] = null;
            }

            object result;
            result = value[1] == null ? value[0] : value[1].ToString();
            return result;
            
            //return value[0].ToString();
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            object[] values = new object[2];
            //MessageBox.Show("VALUE " + value.ToString());

            if ((string)value == string.Empty)
            {
                //MessageBox.Show(value.ToString());
                values[1] = null;
            }

            if ((string)value != string.Empty)
            {
                    values[1] = System.Convert.ToInt32(value);
            }

            return values;
        }
    }
    public class ConverterButton : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string _employeeName = (string)values[0];
            string _employeeID = (string)values[1];
            string _employeeSalary = (string)values[2];
            string _employeeDesigner = (string)values[3];
            string _employeeEmailID = (string)values[4];

            return string.Format("{0}:{1}:{2}:{3}:{4}", _employeeName, _employeeID, _employeeSalary, _employeeDesigner, _employeeEmailID);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
