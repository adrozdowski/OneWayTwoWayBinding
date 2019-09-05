using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using GongSolutions.Wpf.DragDrop;
using System.Windows.Input;

namespace OneWayTwoWayBinding
{
    public class Employee : INotifyPropertyChanged, IDataErrorInfo
    {
        private string employeeName;
        private int? employeeID;
        private int? employeeSalary;
        private string employeeDesigner;
        private string employeeEmailID;
        private Employee selectedEmployee;
        private ICollectionView filteredCollection;
        private int? selectedIndex;
        private string dynamicSearchEmployeeName;
        private string dynamicSearchEmployeeID;
        private string dynamicSearchEmployeeSalary;
        private string dynamicSearchEmployeeDesigner;
        private string dynamicSearchEmployeeEmailID;
        private string modeOfExecuting;
        private string rememberValueEmployeeName;
        private int? rememberValueEmployeeID;
        private int? rememberValueEmployeeSalary;
        private string rememberValueEmployeeDesigner;
        private string rememberValueEmployeeEmailID;
        private ObservableCollection<Employee> employees;
        private string error;
        private int maxValue;
        private bool isPressedEquals;
        private bool isPressedLess;
        private bool isPressedGreater;
        private bool textboxActive;
        private bool isValidated;
        private bool isGreaterButtonActive;
        private bool isLessButtonActive;
        private bool isEqualButtonActive;
        private bool isSelected;
        private IEnumerable<Employee> selectedEmployees;
        private OrderedSet<int> indexesOfSelectedEmployees;
        private int sountOfSelectedEmployees;
        private bool clickOnSelectedItem;
        public bool ClickOnSelectedItem
        {
            get
            {
                return clickOnSelectedItem;
            }
            set
            {
                clickOnSelectedItem = value;
                OnPropertyChanged("ClickOnSelectedItem");
            }
        }
        public int CountOfSelectedEmployees
        {
            get
            {
                return sountOfSelectedEmployees;
            }
            set
            {
                sountOfSelectedEmployees = value;
                OnPropertyChanged("CountOfSelectedEmployees");
            }
        }

        public OrderedSet<int> IndexesOfSelectedEmployees
        {
            get
            {
                return indexesOfSelectedEmployees;
            }
            set
            {
                indexesOfSelectedEmployees = value;
                OnPropertyChanged("IndexesOfSelectedEmployees");
            }
        }

        public IEnumerable<Employee> SelectedEmployees
        {
            get
            {
                //selectedEmployees = Employees.Where(o => o.IsSelected).ToList();
                return selectedEmployees;
            }
            set
            {
                selectedEmployees = value;
                OnPropertyChanged("SelectedEmployees");
            }
        }
        public bool IsSelected
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show("SELE")));

                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public bool IsGreaterButtonActive
        {
            get
            {
                return isGreaterButtonActive;
            }
            set
            {
                isGreaterButtonActive = value;
                OnPropertyChanged("IsGreaterButtonActive");
            }
        }

        public bool IsLessButtonActive
        {
            get
            {
                return isLessButtonActive;
            }
            set
            {
                isLessButtonActive = value;
                OnPropertyChanged("IsLessButtonActive");
            }
        }

        public bool IsEqualButtonActive
        {
            get
            {
                return isEqualButtonActive;
            }
            set
            {
                isEqualButtonActive = value;
                OnPropertyChanged("IsEqualButtonActive");
            }
        }



        public bool IsValidated
        {
            get
            {
                return isValidated;
            }
            set
            {
                isValidated = value;
                OnPropertyChanged("IsValidated");
            }
        }

        public bool TextboxActive
        {
            get
            {
                return textboxActive;
            }
            set
            {
                textboxActive = value;
                OnPropertyChanged("TextboxActive");
            }
        }

        public bool IsPressedGreater
        {
            get
            {
                return isPressedGreater;
            }
            set
            {
                isPressedGreater = value;
                OnPropertyChanged("IsPressedGreater");
            }
        }
        public bool IsPressedLess
        {
            get
            {
                return isPressedLess;
            }
            set
            {
                isPressedLess = value;
                OnPropertyChanged("IsPressedLess");
            }
        }
        public bool IsPressedEqual
        {
            get
            {
                return isPressedEquals;
            }
            set
            {
                isPressedEquals = value;
                OnPropertyChanged("IsPressedEqual");
            }
        }


        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
                OnPropertyChanged("MaxValue");
            }
        }


        public string Error
        {
            get { return error; }
        }
        public string this[string columnName]
        {
            get
            {
                int output;
                List<string> validateErrorList = new List<string>();
                error = string.Empty;

                if (columnName == "DynamicSearchEmployeeName")
                {

                    if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeName))
                    {
                        validateErrorList.Add("Employee Name is required to add a new Employee !");
                    }
                    if ((!Regex.IsMatch(DynamicSearchEmployeeName, @"^[a-zA-Z]+$")))
                    {
                        validateErrorList.Add("Employee Name has to contain only a-z, A-Z letters!");
                    }
                }
                if (columnName == "DynamicSearchEmployeeID" && SelectedEmployee == null)
                {
                    if (!Int32.TryParse(dynamicSearchEmployeeID, out output))
                    {
                        validateErrorList.Add("To serach Employee ID give a number !");
                    }
                }
                if (columnName == "DynamicSearchEmployeeSalary" && SelectedEmployee == null)
                {
                    if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary))
                    {
                        validateErrorList.Add("Employee Salary is required to add a new Employee !");
                    }
                    if (!Int32.TryParse(dynamicSearchEmployeeSalary, out output))
                    {
                        validateErrorList.Add("Employee Salary has to be number !");
                        validateErrorList.Add("Employee Salary cannot be less than 5 !");
                        validateErrorList.Add("Employee Salary cannot be less than 10 !");
                        validateErrorList.Add("Employee Salary cannot be less than 100 !");
                    }
                    if (Int32.TryParse(dynamicSearchEmployeeSalary, out output))
                    {
                        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || Convert.ToInt32(DynamicSearchEmployeeSalary) < 5)
                        {
                            validateErrorList.Add("Employee Salary cannot be less than 5 !");
                        }
                        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || Convert.ToInt32(DynamicSearchEmployeeSalary) < 10)
                        {
                            validateErrorList.Add("Employee Salary cannot be less than 10 !");
                        }
                        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || Convert.ToInt32(DynamicSearchEmployeeSalary) < 100)
                        {
                            validateErrorList.Add("Employee Salary cannot be less than 100 !");
                        }
                    }
                }
                if (columnName == "DynamicSearchEmployeeSalary" && SelectedEmployee != null)
                {
                    if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary))
                    {
                        validateErrorList.Add("Employee Salary is required to add a new Employee !");
                    }
                    if (!Int32.TryParse(DynamicSearchEmployeeSalary, out output))
                    {
                        validateErrorList.Add("Employee Salary has to be number !");
                        validateErrorList.Add("Employee Salary cannot be less than 5 !");
                        validateErrorList.Add("Employee Salary cannot be less than 10 !");
                        validateErrorList.Add("Employee Salary cannot be less than 100 !");
                    }
                    if (Int32.TryParse(DynamicSearchEmployeeSalary, out output))
                    {
                        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || Convert.ToInt32(DynamicSearchEmployeeSalary) < 5)
                        {
                            validateErrorList.Add("Employee Salary cannot be less than 5 !");
                        }
                        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || Convert.ToInt32(DynamicSearchEmployeeSalary) < 10)
                        {
                            validateErrorList.Add("Employee Salary cannot be less than 10 !");
                        }
                        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || Convert.ToInt32(DynamicSearchEmployeeSalary) < 100)
                        {
                            validateErrorList.Add("Employee Salary cannot be less than 100 !");
                        }
                    }
                }
                if (columnName == "DynamicSearchEmployeeDesigner" && string.IsNullOrWhiteSpace(DynamicSearchEmployeeDesigner))
                {
                    validateErrorList.Add("Employee Designer is required to add a new Employee !");
                }

                foreach (var validateerroritem in validateErrorList)
                {
                    error += validateerroritem + "\r\n";
                }
                error = error.ToString().TrimEnd('\r', '\n');

                if (error == string.Empty)
                {
                    IsValidated = true;
                }
                else if (error != string.Empty)
                {
                    IsValidated = false;
                }
                return error;
            }
        }


        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
            set
            {
                employeeName = value;
                OnPropertyChanged("EmployeeName");

            }
        }
        public int? EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
                OnPropertyChanged("EmployeeID");
            }
        }
        public int? EmployeeSalary
        {
            get
            {
                return employeeSalary;
            }
            set
            {
                employeeSalary = value;
                OnPropertyChanged("EmployeeSalary");
            }
        }
        public string EmployeeDesigner
        {
            get
            {
                return employeeDesigner;
            }
            set
            {
                employeeDesigner = value;
                OnPropertyChanged("EmployeeDesigner");
            }
        }
        public string EmployeeEmailID
        {
            get
            {
                return employeeEmailID;
            }
            set
            {
                employeeEmailID = value;
                OnPropertyChanged("EmployeeEmailID");
            }
        }
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }


        public Employee SelectedEmployee
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(selectedEmployee.SelectedEmployee.ToString())));
                return selectedEmployee;
            }
            set
            {
                //if(Mouse.LeftButton == MouseButtonState.Released)
                //{
                    //MessageBox.Show("Mouse button is released");
                    selectedEmployee = value;

                    if (selectedEmployee == null)
                    {
                        ModeOfExecuting = "Searching / Adding Mode";
                    }

                    if (selectedEmployee != null)
                    {
                        //MessageBox.Show(Employees[SelectedIndex.GetValueOrDefault()].EmployeeName.ToString());

                        //List<Employee> FilteredCollectionList = FilteredCollection.Cast<Employee>().ToList();
                        //MessageBox.Show(FilteredCollectionList[0].EmployeeName);

                        if (selectedEmployee.EmployeeName != string.Empty)
                        {
                            RememberValueEmployeeName = selectedEmployee.EmployeeName;
                            DynamicSearchEmployeeName = RememberValueEmployeeName;
                        }
                        if (selectedEmployee.EmployeeID != null)
                        {
                            RememberValueEmployeeID = selectedEmployee.EmployeeID;
                            DynamicSearchEmployeeID = RememberValueEmployeeID.ToString();
                        }
                        if (selectedEmployee.EmployeeSalary != null)
                        {
                            RememberValueEmployeeSalary = selectedEmployee.EmployeeSalary;
                            DynamicSearchEmployeeSalary = RememberValueEmployeeSalary.ToString();
                        }
                        if (selectedEmployee.EmployeeDesigner != string.Empty)
                        {
                            RememberValueEmployeeDesigner = selectedEmployee.EmployeeDesigner;
                            DynamicSearchEmployeeDesigner = RememberValueEmployeeDesigner;
                        }
                        if (selectedEmployee.EmployeeEmailID != string.Empty)
                        {
                            RememberValueEmployeeEmailID = selectedEmployee.EmployeeEmailID;
                            DynamicSearchEmployeeEmailID = RememberValueEmployeeEmailID;
                        }

                        ModeOfExecuting = "Editing Mode";
                    }
                //}
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public string DynamicSearchEmployeeName
        {
            get
            {
                return dynamicSearchEmployeeName;
            }
            set
            {
                dynamicSearchEmployeeName = value;
                DynamicSearch();
                OnPropertyChanged("DynamicSearchEmployeeName");

            }
        }
        public string DynamicSearchEmployeeID
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(dynamicSearchEmployeeID.ToString())));
                return dynamicSearchEmployeeID;
            }
            set
            {
                dynamicSearchEmployeeID = value;

                if (SelectedEmployee == null)
                {
                    TextboxActive = true;
                }
                if (SelectedEmployee != null)
                {
                    TextboxActive = false;
                }
                int output;
                dynamicSearchEmployeeID = value;
                if (Int32.TryParse(dynamicSearchEmployeeID, out output))
                {
                    DynamicSearch();
                }
                if (!Int32.TryParse(dynamicSearchEmployeeID, out output))
                {
                    FilteredCollection.Filter = null;
                }
                OnPropertyChanged("DynamicSearchEmployeeID");
            }
        }
        public string DynamicSearchEmployeeSalary
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show("DYN"+dynamicSearchEmployeeSalary.ToString())));
                return dynamicSearchEmployeeSalary;
            }
            set
            {
                int output;
                dynamicSearchEmployeeSalary = value;
                if (Int32.TryParse(dynamicSearchEmployeeSalary, out output))
                {
                    DynamicSearch();
                }
                if (!Int32.TryParse(dynamicSearchEmployeeSalary, out output))
                {
                    FilteredCollection.Filter = null;
                }
                OnPropertyChanged("DynamicSearchEmployeeSalary");
            }
        }


        public string DynamicSearchEmployeeDesigner
        {
            get
            {
                return dynamicSearchEmployeeDesigner;
            }
            set
            {
                dynamicSearchEmployeeDesigner = value;
                DynamicSearch();
                OnPropertyChanged("DynamicSearchEmployeeDesigner");
            }
        }
        public string DynamicSearchEmployeeEmailID
        {
            get
            {
                return dynamicSearchEmployeeEmailID;
            }
            set
            {
                dynamicSearchEmployeeEmailID = value;
                DynamicSearch();
                OnPropertyChanged("DynamicSearchEmployeeEmailID");
            }

        }

        void DynamicSearch()
        {
            if (SelectedEmployee == null)
            {
                if (IsPressedEqual == true)
                {
                    if (FilteredCollection != null)
                    {
                        FilteredCollection.Filter = x => (
                    (string.IsNullOrEmpty(DynamicSearchEmployeeName) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeName))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeID) || ((Employee)x).EmployeeID == Convert.ToInt32(DynamicSearchEmployeeID))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeSalary) || ((Employee)x).EmployeeSalary == Convert.ToInt32(DynamicSearchEmployeeSalary))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeDesigner) || ((Employee)x).EmployeeDesigner.Contains(DynamicSearchEmployeeDesigner))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeEmailID) || ((Employee)x).EmployeeEmailID.Contains(DynamicSearchEmployeeEmailID))
                    );
                    }
                }

                if (IsPressedLess == true)
                {
                    if (FilteredCollection != null)
                    {
                        FilteredCollection.Filter = x => (
                    (string.IsNullOrEmpty(DynamicSearchEmployeeName) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeName))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeID) || ((Employee)x).EmployeeID == Convert.ToInt32(DynamicSearchEmployeeID))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeSalary) || ((Employee)x).EmployeeSalary < Convert.ToInt32(DynamicSearchEmployeeSalary))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeDesigner) || ((Employee)x).EmployeeDesigner.Contains(DynamicSearchEmployeeDesigner))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeEmailID) || ((Employee)x).EmployeeEmailID.Contains(DynamicSearchEmployeeEmailID))
                    );
                    }
                }

                if (IsPressedGreater == true)
                {
                    if (FilteredCollection != null)
                    {
                        FilteredCollection.Filter = x => (
                    (string.IsNullOrEmpty(DynamicSearchEmployeeName) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeName))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeID) || ((Employee)x).EmployeeID == Convert.ToInt32(DynamicSearchEmployeeID))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeSalary) || ((Employee)x).EmployeeSalary > Convert.ToInt32(DynamicSearchEmployeeSalary))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeDesigner) || ((Employee)x).EmployeeDesigner.Contains(DynamicSearchEmployeeDesigner))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeEmailID) || ((Employee)x).EmployeeEmailID.Contains(DynamicSearchEmployeeEmailID))
                    );
                    }
                }

                if (IsPressedEqual == true && isPressedGreater == true)
                {
                    if (FilteredCollection != null)
                    {
                        FilteredCollection.Filter = x => (
                    (string.IsNullOrEmpty(DynamicSearchEmployeeName) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeName))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeID) || ((Employee)x).EmployeeID == Convert.ToInt32(DynamicSearchEmployeeID))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeSalary) || ((Employee)x).EmployeeSalary >= Convert.ToInt32(DynamicSearchEmployeeSalary))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeDesigner) || ((Employee)x).EmployeeDesigner.Contains(DynamicSearchEmployeeDesigner))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeEmailID) || ((Employee)x).EmployeeEmailID.Contains(DynamicSearchEmployeeEmailID))
                    );
                    }
                }

                if (IsPressedEqual == true && isPressedLess == true)
                {
                    if (FilteredCollection != null)
                    {
                        FilteredCollection.Filter = x => (
                    (string.IsNullOrEmpty(DynamicSearchEmployeeName) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeName))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeID) || ((Employee)x).EmployeeID == Convert.ToInt32(DynamicSearchEmployeeID))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeSalary) || ((Employee)x).EmployeeSalary <= Convert.ToInt32(DynamicSearchEmployeeSalary))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeDesigner) || ((Employee)x).EmployeeDesigner.Contains(DynamicSearchEmployeeDesigner))
                    && (string.IsNullOrEmpty(DynamicSearchEmployeeEmailID) || ((Employee)x).EmployeeEmailID.Contains(DynamicSearchEmployeeEmailID))
                    );
                    }
                }

            }
        }

        public ICollectionView FilteredCollection
        {
            get
            {
                return filteredCollection;
            }
            set
            {
                filteredCollection = value;
                OnPropertyChanged("FilteredCollection");
            }
        }

        public int? SelectedIndex
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(changedPathBinding.ToString())));
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
                //SelectedEmployee.EmployeeName
            }
        }

        public string ModeOfExecuting
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(modeOfExecuting.ToString())));
                return modeOfExecuting;
            }
            set
            {
                modeOfExecuting = value;
                OnPropertyChanged("ModeOfExecuting");
            }
        }
        public string RememberValueEmployeeName
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(changedPathBinding.ToString())));
                return rememberValueEmployeeName;
            }
            set
            {
                rememberValueEmployeeName = value;
                OnPropertyChanged("RememberValueEmployeeName");
            }
        }
        public int? RememberValueEmployeeID
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(changedPathBinding.ToString())));
                return rememberValueEmployeeID;
            }
            set
            {
                rememberValueEmployeeID = value;
                OnPropertyChanged("RememberValueEmployeeID");
            }
        }
        public int? RememberValueEmployeeSalary
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(changedPathBinding.ToString())));
                return rememberValueEmployeeSalary;
            }
            set
            {
                rememberValueEmployeeSalary = value;
                OnPropertyChanged("RememberValueEmployeeSalary");
            }
        }
        public string RememberValueEmployeeDesigner
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(changedPathBinding.ToString())));
                return rememberValueEmployeeDesigner;
            }
            set
            {
                rememberValueEmployeeDesigner = value;
                OnPropertyChanged("RememberValueEmployeeDesigner");
            }
        }
        public string RememberValueEmployeeEmailID
        {
            get
            {
                //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(changedPathBinding.ToString())));
                return rememberValueEmployeeEmailID;
            }
            set
            {
                rememberValueEmployeeEmailID = value;
                OnPropertyChanged("RememberValueEmployeeEmailID");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = null;
        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

