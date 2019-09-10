﻿using GalaSoft.MvvmLight.Command;
using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace OneWayTwoWayBinding
{
    public class EmployeeViewModel : Employee, IDropTarget
    {
        public EmployeeViewModel()
        {
            IndexesOfSelectedEmployees = new OrderedSet<int>();
            SelectedEmployees = new ObservableCollection<Employee>();
            Employees = new ObservableCollection<Employee>()
            {
                new Employee { EmployeeName = "Zdrian", EmployeeID = 1, EmployeeSalary = 10000, EmployeeDesigner = "SoftwareEngingeer", EmployeeEmailID = "First1@gmail.com" },
                new Employee { EmployeeName = "Adrian", EmployeeID = 2, EmployeeSalary = 15000, EmployeeDesigner = "Architect", EmployeeEmailID = "Second2@gmail.com" },
                new Employee { EmployeeName = "Adrian", EmployeeID = 3, EmployeeSalary = 15000, EmployeeDesigner = "Architect", EmployeeEmailID = "Third3@gmail.com" },
                new Employee { EmployeeName = "Bartek", EmployeeID = 4, EmployeeSalary = 30000, EmployeeDesigner = "Tester", EmployeeEmailID = "Fourth4@gmailGG.com" },
                new Employee { EmployeeName = "Cezary", EmployeeID = 5, EmployeeSalary = 60000, EmployeeDesigner = "Developer", EmployeeEmailID = "FGDFDF@gmailGG.com" },
                new Employee { EmployeeName = "Darek", EmployeeID = 6, EmployeeSalary = 70000, EmployeeDesigner = "Developer", EmployeeEmailID = "Slawek@gmailGG.com" },
                new Employee { EmployeeName = "Ernest", EmployeeID = 7, EmployeeSalary = 80000, EmployeeDesigner = "Developer", EmployeeEmailID = "magda01@gmailGG.com" },
                new Employee { EmployeeName = "Fiodor", EmployeeID = 8, EmployeeSalary = 35000, EmployeeDesigner = "Tester", EmployeeEmailID = "sebix@gmailGG.com" },
                new Employee { EmployeeName = "Filip", EmployeeID = 9, EmployeeSalary = 49000, EmployeeDesigner = "Manager", EmployeeEmailID = "mirux@gmailGG.com" },
                new Employee { EmployeeName = "Gabriel", EmployeeID = 10, EmployeeSalary = 130000, EmployeeDesigner = "Tester", EmployeeEmailID = "neno@gmailGG.com" },
                new Employee { EmployeeName = "Henryk", EmployeeID = 11, EmployeeSalary = 300000, EmployeeDesigner = "SoftwareEngingeer", EmployeeEmailID = "aja@gmailGG.com" }
            };

            //SelectedEmployees = Employees.Where(o => o.IsSelected).ToList();
            FilteredCollection = CollectionViewSource.GetDefaultView(Employees);

            //FilteredCollection.Filter = null;
            //SelectedEmployee = null;
            EmployeeName = string.Empty;
            EmployeeID = null;
            EmployeeSalary = null;
            EmployeeDesigner = string.Empty;
            EmployeeEmailID = string.Empty;
            DynamicSearchEmployeeName = string.Empty;
            DynamicSearchEmployeeID = null;
            DynamicSearchEmployeeSalary = null;
            DynamicSearchEmployeeDesigner = string.Empty;
            DynamicSearchEmployeeEmailID = string.Empty;
            RememberValueEmployeeName = string.Empty;
            RememberValueEmployeeID = null;
            RememberValueEmployeeSalary = null;
            RememberValueEmployeeDesigner = string.Empty;
            RememberValueEmployeeEmailID = string.Empty;

            SelectedIndex = null;
            MaxValue = (int)Employees.Max(x => x.EmployeeID) + 1;
            //MaxValue = 1;
            IsPressedEqual = true;
            //IsPressedGreater = true;
            //IsPressedLess = true;
            IsEqualButtonActive = true;
            IsLessButtonActive = true;
            IsGreaterButtonActive = true;
            //DynamicSearchEmployeeName = "B";
            //DynamicSearchEmployeeID = 1;
            //DynamicSearchEmployeeSalary = "15000";
            //DynamicSearchEmployeeDesigner = "SoftwareEngingeer11";
            //DynamicSearchEmployeeEmailID = "drozd001@gmailGG.com";
            //Employees[0].IsSelected = true;
            //Employees[1].IsSelected = true;
            ModeOfExecuting = "Searching / Adding Mode";
        }

        private RelayCommand _updateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand((param) => this.Update(param),
                        param => this.CanUpdate);
                }
                return _updateCommand;
            }
        }

        private RelayCommand _clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new RelayCommand((param) => this.Clear(param),
                        param => this.CanClear);
                }
                return _clearCommand;
            }
        }

        private RelayCommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand((param) => this.Add(param),
                        param => this.CanAdd);
                }
                return _addCommand;
            }
        }

        private RelayCommand _removeCommand;

        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand((param) => this.Remove(param),
                        param => this.CanRemove);
                }
                return _removeCommand;
            }
        }

        private RelayCommand _recoverAllCommand;

        public ICommand RecoverAllCommand
        {
            get
            {
                if (_recoverAllCommand == null)
                {
                    _recoverAllCommand = new RelayCommand((param) => this.RecoverAll(param),
                        param => this.CanUpdate);
                }
                return _recoverAllCommand;
            }
        }

        private RelayCommand _isEqualCommand;

        public ICommand IsEqualCommand
        {
            get
            {
                if (_isEqualCommand == null)
                {
                    _isEqualCommand = new RelayCommand((param) => this.Equal(param),
                        param => this.CanEqual);
                }
                return _isEqualCommand;
            }
        }

        private RelayCommand _isGreaterCommand;

        public ICommand IsGreaterCommand
        {
            get
            {
                if (_isGreaterCommand == null)
                {
                    _isGreaterCommand = new RelayCommand((param) => this.Greater(param),
                        param => this.CanEqual);
                }
                return _isGreaterCommand;
            }
        }

        private RelayCommand _isLessCommand;

        public ICommand IsLessCommand
        {
            get
            {
                if (_isLessCommand == null)
                {
                    _isLessCommand = new RelayCommand((param) => this.Less(param),
                        param => this.CanEqual);
                }
                return _isLessCommand;
            }
        }

        private RelayCommand _selectionChanged;

        public ICommand SelectionChanged
        {
            get
            {
                if (_selectionChanged == null)
                {
                    _selectionChanged = new RelayCommand((param) => this.OnSelectionChanged(param),
                        param => true);
                }
                return _selectionChanged;
            }
        }

        private RelayCommand _exportToCSVFileCommand;
        public ICommand ExportToCSVFileCommand
        {
            get
            {
                if (_exportToCSVFileCommand == null)
                {
                    _exportToCSVFileCommand = new RelayCommand((param) => this.ExportToCSVFile(param),
                        param => this.CanExport);
                }
                return _exportToCSVFileCommand;
            }
        }

        private RelayCommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (_clickCommand == null)
                {
                    _clickCommand = new RelayCommand((param) => this.ClickMethod(param),
                        param => true);
                }
                return _clickCommand;
            }
        }

        private RelayCommand<DragEventArgs> _dropCommand;
        public RelayCommand<DragEventArgs> DropCommand
        {
                get
                {
                    return _dropCommand ?? (_dropCommand = new RelayCommand<DragEventArgs>(DropMethod));
                }
        }

        private RelayCommand _sortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_sortCommand == null)
                {
                    _sortCommand = new RelayCommand((param) => this.Sort(param),
                        param => true);
                }
                return _sortCommand;
            }
        }

        string _sortColumn;
        ListSortDirection _sortDirection;

        public void Sort(object parameter)
        {
            SelectedEmployee = null;
            DynamicSearchEmployeeName = String.Empty;
            DynamicSearchEmployeeID = String.Empty;
            DynamicSearchEmployeeSalary = String.Empty;
            DynamicSearchEmployeeDesigner = String.Empty;
            DynamicSearchEmployeeEmailID = String.Empty;

            string column = parameter as string;

            if (_sortColumn == column)
            {
                // Toggle sorting direction 
                _sortDirection = _sortDirection == ListSortDirection.Ascending ?
                                                   ListSortDirection.Descending :
                                                   ListSortDirection.Ascending;
            }
            else
            {
                _sortColumn = column;
                _sortDirection = ListSortDirection.Ascending;
            }

            FilteredCollection.SortDescriptions.Clear();
            FilteredCollection.SortDescriptions.Add(
                                     new SortDescription(_sortColumn, _sortDirection));

        }

        public void DropMethod(DragEventArgs e) 
        {
            bool IsFileCorrected = true;

            IsFileCorrected = Scanner(e);

            if(IsFileCorrected == true)
            {
                ImportRecordsFromCSVFile(e);
            }
        }

        public bool Scanner(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var fileName in fileNames)
                {
                    var FileLines = File.ReadAllLines(fileName);
                    foreach (var fileLane in FileLines)
                    {
                        string[] columns = fileLane.Split(',');
                        //MessageBox.Show(columns[1]);
                            
                        if (columns.Count() != 5)
                        {
                            MessageBoxResult result = MessageBox.Show("You have dropped a corrupted file.", "Confirmation Window", MessageBoxButton.OK);
                            return false;
                        } 
                    }
                }
            }
            return true;
        }

        public void ImportRecordsFromCSVFile(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var fileName in fileNames)
                {
                    var FileLines = File.ReadAllLines(fileName);
                    foreach (var fileLane in FileLines)
                    {
                        string[] columns = fileLane.Split(',');
                        //MessageBox.Show(columns[1]);

                            Employees.Add
                                (new Employee
                                {
                                    EmployeeName = columns[0],
                                    EmployeeID = Convert.ToInt32(columns[1]),
                                    EmployeeSalary = Convert.ToInt32(columns[2]),
                                    EmployeeDesigner = columns[3],
                                    EmployeeEmailID = columns[4]
                                }
                                );
                    }
                }
            }
        }

        public void ClickMethod(object parameter)
        {
            //List<Employee> selection = ((IList)parameter).Cast<Employee>().ToList();
            IList selection = (IList)parameter;

            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (SelectedEmployee == null)
                {
                    IndexesOfSelectedEmployees.Clear();
                    CountOfSelectedEmployees = 0;
                    DynamicSearchEmployeeName = String.Empty;
                    DynamicSearchEmployeeID = String.Empty;
                    DynamicSearchEmployeeSalary = String.Empty;
                    DynamicSearchEmployeeDesigner = String.Empty;
                    DynamicSearchEmployeeEmailID = String.Empty;
                }

                if (SelectedEmployee != null)
                {
                    foreach (Employee item in Employees)
                    {
                        if (item.IsSelected == true)
                        {
                            IndexesOfSelectedEmployees.Add(Employees.IndexOf(item));
                        }
                        if (item.IsSelected == false)
                        {
                            IndexesOfSelectedEmployees.Remove(Employees.IndexOf(item));
                        }
                    }

                    SelectedEmployee = Employees[IndexesOfSelectedEmployees.Last()];
                    //SelectedEmployee = selection.Last();

                    foreach (int itemIndexesOfSelectedEmployees in IndexesOfSelectedEmployees.Reverse())
                    {
                        foreach (Employee itemEmployees in Employees)
                        {
                            if (itemIndexesOfSelectedEmployees == Employees.IndexOf(itemEmployees))
                            {
                                itemEmployees.IsSelected = true;
                            }
                        }
                    }
                    CountOfSelectedEmployees = selection.Count;
                }
            }
            else if (!IndexesOfSelectedEmployees.Any())
            {
                IndexesOfSelectedEmployees.Clear();
                IndexesOfSelectedEmployees.Add(SelectedIndex.GetValueOrDefault());
                CountOfSelectedEmployees = selection.Count;
            }
            else if (IndexesOfSelectedEmployees.Any())
            {
                if (IndexesOfSelectedEmployees.Count == 1 && IndexesOfSelectedEmployees.Contains((int)SelectedIndex))
                {
                    //IndexesOfSelectedEmployees.Add(Employees.IndexOf(SelectedEmployee));
                    //SelectedEmployee.IsSelected = false;
                    //SelectedEmployee = null;
                    selection.Clear();
                    CountOfSelectedEmployees = selection.Count; //0
                    IndexesOfSelectedEmployees.Clear();
                    DynamicSearchEmployeeName = String.Empty;
                    DynamicSearchEmployeeID = String.Empty;
                    DynamicSearchEmployeeSalary = String.Empty;
                    DynamicSearchEmployeeDesigner = String.Empty;
                    DynamicSearchEmployeeEmailID = String.Empty;
                  
                }
                else if (IndexesOfSelectedEmployees.Count == 1 && !IndexesOfSelectedEmployees.Contains((int)SelectedIndex))
                {
                    IndexesOfSelectedEmployees.Clear();
                    IndexesOfSelectedEmployees.Add(SelectedIndex.GetValueOrDefault());
                    CountOfSelectedEmployees = selection.Count; //1
                }
                else if (IndexesOfSelectedEmployees.Count != 1)
                {
                    IndexesOfSelectedEmployees.Clear();
                    IndexesOfSelectedEmployees.Add(SelectedIndex.GetValueOrDefault());
                    SelectedEmployee = Employees[IndexesOfSelectedEmployees.Last()];
                    foreach (int itemIndexesOfSelectedEmployees in IndexesOfSelectedEmployees)
                    {
                        foreach (Employee itemEmployees in Employees)
                        {
                            if (itemIndexesOfSelectedEmployees == Employees.IndexOf(itemEmployees))
                            {
                                itemEmployees.IsSelected = true;
                            }
                            if (itemIndexesOfSelectedEmployees != Employees.IndexOf(itemEmployees))
                            {
                                itemEmployees.IsSelected = false;
                            }
                        }
                    }
                    CountOfSelectedEmployees = selection.Count;
                }
            }

            
        }
        //FilteredCollection.MoveCurrentToFirst();
        //foreach (int item in IndexesOfSelectedEmployees)
        //{
        //    MessageBox.Show(item.ToString());
        //}
        public void ExportToCSVFile(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true };
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    if (SelectedEmployee != null)
                    {
                        foreach (Employee item in Employees)
                        {
                            if(item.IsSelected == true)
                            {
                                writer.WriteLine(item.EmployeeName + "," + item.EmployeeID + "," + item.EmployeeSalary + "," + item.EmployeeDesigner + "," + item.EmployeeEmailID);
                            }                            
                        }
                    }
                    //writer.WriteLine("EmployeeName " + "EmployeeID " + "EmployeeSalary " + "EmployeeDesigner " + "EmployeeEmailID");
                    else if (SelectedEmployee == null)
                    {
                        foreach (Employee item in FilteredCollection)
                        {
                            writer.WriteLine(item.EmployeeName + "," + item.EmployeeID + "," + item.EmployeeSalary + "," + item.EmployeeDesigner + "," + item.EmployeeEmailID);
                        }
                    }                        
                }
            }
        }

        public void OnSelectionChanged(object parameter)
        {
            IList selection = (IList)parameter;

            if ((Keyboard.IsKeyDown(Key.LeftCtrl) && (Keyboard.IsKeyDown(Key.A))) == true || (Keyboard.IsKeyDown(Key.LeftShift) && Keyboard.IsKeyDown(Key.Up)) || (Keyboard.IsKeyDown(Key.LeftShift) && Keyboard.IsKeyDown(Key.Down)))
            {
                CountOfSelectedEmployees = selection.Count;

                foreach (Employee item in selection)
                {
                    IndexesOfSelectedEmployees.Add(Employees.IndexOf(item));
                }
                foreach (int itemIndexesOfSelectedEmployees in IndexesOfSelectedEmployees)
                {
                    foreach (Employee itemEmployees in Employees)
                    {
                        if (itemIndexesOfSelectedEmployees == Employees.IndexOf(itemEmployees))
                        {
                            itemEmployees.IsSelected = true;
                        }
                    }
                }
            }
        }

        public void Greater(object parameter)
        {
            if (IsPressedGreater == true)
            {
                if (FilteredCollection != null)
                {
                    FilteredCollection.Filter = x => (
                (string.IsNullOrEmpty(DynamicSearchEmployeeName) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeName))
                && (string.IsNullOrEmpty(DynamicSearchEmployeeID) || ((Employee)x).EmployeeID == Convert.ToInt32(DynamicSearchEmployeeID))
                && (string.IsNullOrEmpty(DynamicSearchEmployeeSalary) || ((Employee)x).EmployeeSalary > Convert.ToInt32(DynamicSearchEmployeeSalary))
                && (string.IsNullOrEmpty(DynamicSearchEmployeeDesigner) || ((Employee)x).EmployeeDesigner.Contains(DynamicSearchEmployeeDesigner))
                && (string.IsNullOrEmpty(DynamicSearchEmployeeEmailID) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeEmailID))
                );
                }
            }
            if (IsPressedGreater == true && IsPressedEqual == true)
            {
                if (FilteredCollection != null)
                {
                    FilteredCollection.Filter = x => (
                (string.IsNullOrEmpty(DynamicSearchEmployeeName) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeName))
                && (string.IsNullOrEmpty(DynamicSearchEmployeeID) || ((Employee)x).EmployeeID == Convert.ToInt32(DynamicSearchEmployeeID))
                && (string.IsNullOrEmpty(DynamicSearchEmployeeSalary) || ((Employee)x).EmployeeSalary >= Convert.ToInt32(DynamicSearchEmployeeSalary))
                && (string.IsNullOrEmpty(DynamicSearchEmployeeDesigner) || ((Employee)x).EmployeeDesigner.Contains(DynamicSearchEmployeeDesigner))
                && (string.IsNullOrEmpty(DynamicSearchEmployeeEmailID) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeEmailID))
                );
                }
            }
            if (IsPressedGreater == false)
            {
                if (FilteredCollection != null)
                {
                FilteredCollection.Filter = x => (
                    (
                        string.IsNullOrEmpty(DynamicSearchEmployeeName) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeName))
                        && (string.IsNullOrEmpty(DynamicSearchEmployeeID) || ((Employee)x).EmployeeID == Convert.ToInt32(DynamicSearchEmployeeID))
                        && (string.IsNullOrEmpty(DynamicSearchEmployeeSalary) || ((Employee)x).EmployeeSalary == Convert.ToInt32(DynamicSearchEmployeeSalary))
                        && (string.IsNullOrEmpty(DynamicSearchEmployeeDesigner) || ((Employee)x).EmployeeDesigner.Contains(DynamicSearchEmployeeDesigner))
                        && (string.IsNullOrEmpty(DynamicSearchEmployeeEmailID) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeEmailID))
                    );
                }
            }
            if (IsPressedLess == false && IsPressedGreater == false)
            {
                IsPressedEqual = true;
            }
            if (IsPressedEqual == true && IsPressedGreater == true)
            {
                IsPressedLess = false;
            }
            if (IsPressedEqual == false && IsPressedGreater == true)
            {
                IsPressedLess = false;
            }
        }

        public void Equal(object parameter)
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
            if (IsPressedEqual == false && IsPressedLess == true)
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
            if (IsPressedEqual == false && IsPressedGreater == true)
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
            if (IsPressedGreater == true && IsPressedEqual == true)
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
            if (IsPressedLess == true && IsPressedEqual == true)
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
            if (IsPressedLess == false && IsPressedGreater == false)
            {
                IsPressedEqual = true;
            }
        }

        public void Less(object parameter)
        {
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
            if (IsPressedLess == true && IsPressedEqual == true)
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
            if (IsPressedLess == false)
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
            if (IsPressedLess == false && IsPressedGreater == false)
            {
                IsPressedEqual = true;
            }
            if (IsPressedEqual == true && IsPressedLess == true)
            {
                IsPressedGreater = false;
            }
            if (IsPressedEqual == false && IsPressedLess == true)
            {
                IsPressedGreater = false;
            }
        }

        public void Update(object parameter)
        {
            string[] SearchedCollection = ((string)parameter).Split(new char[] { ':' });
            SelectedEmployee.EmployeeName = SearchedCollection[0];
            SelectedEmployee.EmployeeID = Convert.ToInt32(SearchedCollection[1]);
            SelectedEmployee.EmployeeSalary = Convert.ToInt32(SearchedCollection[2]);
            SelectedEmployee.EmployeeDesigner = SearchedCollection[3];
            SelectedEmployee.EmployeeEmailID = SearchedCollection[4];
        }

        public void Clear(object parameter)
        {
            // iteracja po FilteredColelction (CollectionView)

            //var selectedItems = FilteredCollection
            //                   .Cast<Employee>()
            //                   .ToList();

            //foreach (Employee item in FilteredCollection)
            //{
            //    MessageBox.Show(item.EmployeeName);
            //    //selectedItems.Remove(item);
            //}
            foreach (Employee item in Employees)
            {
                if(item.IsSelected == true)
                {
                    item.IsSelected = false;
                }
            }
            SelectedEmployee = null;
            EmployeeName = string.Empty;
            EmployeeID = null;
            EmployeeSalary = null;
            EmployeeDesigner = string.Empty;
            EmployeeEmailID = string.Empty;
            DynamicSearchEmployeeName = string.Empty;
            DynamicSearchEmployeeID = null;
            DynamicSearchEmployeeSalary = string.Empty;
            DynamicSearchEmployeeDesigner = string.Empty;
            DynamicSearchEmployeeEmailID = string.Empty;
            RememberValueEmployeeName = string.Empty;
            RememberValueEmployeeID = null;
            RememberValueEmployeeSalary = null;
            RememberValueEmployeeDesigner = string.Empty;
            RememberValueEmployeeEmailID = string.Empty;
            IsPressedEqual = true;
            IsPressedGreater = false;
            IsPressedLess = false;
            FilteredCollection.Filter = null;
            IndexesOfSelectedEmployees.Clear();
            CountOfSelectedEmployees = 0;

            //if (FilteredCollection != null)
            //{ 
                FilteredCollection.SortDescriptions.Clear();
                FilteredCollection.SortDescriptions.Add(new SortDescription("EmployeeID", ListSortDirection.Ascending));
            //}
        }

        public void Add(object parameter)
        {
            // Dodawanie z poziomu textboxow
            if (!SelectedEmployees.Any()) //jesli kolekcja jest pusta
            {
                string[] AddedCollection = ((string)parameter).Split(new char[] { ':' });
                Employees.Add
                    (new Employee
                    {
                        EmployeeName = AddedCollection[0],
                        EmployeeID = MaxValue,
                        EmployeeSalary = Convert.ToInt32(AddedCollection[2]),
                        EmployeeDesigner = AddedCollection[3],
                        EmployeeEmailID = AddedCollection[4] == string.Empty ? "NONE" : AddedCollection[4]
                    }
                    );
                MaxValue = MaxValue + 1;
            }
            // Dodawanie z poziomu wybierania elementow w liscie
            if (SelectedEmployees.Any()) //jesli jest jakikolwiek
            {
                foreach (Employee item in SelectedEmployees)
                {
                    Employees.Add
                    (new Employee
                    {
                        EmployeeName = item.EmployeeName,
                        EmployeeID = MaxValue,
                        EmployeeSalary = item.EmployeeSalary,
                        EmployeeDesigner = item.EmployeeDesigner,
                        EmployeeEmailID = item.EmployeeEmailID
                    }
                    );
                    MaxValue = MaxValue + 1;
                }
            }
            SelectedEmployee = Employees.Last();
            FilteredCollection.Filter = null;
            IndexesOfSelectedEmployees.Clear();
            CountOfSelectedEmployees = 0;
        }

        public void Remove(object parameter)
        {

            List<Employee> selection = ((IList)parameter).Cast<Employee>().ToList();
            foreach (Employee item in selection)
            {
                Employees.Remove(item);
            }

            SelectedEmployee = null;
            EmployeeName = string.Empty;
            EmployeeID = null;
            EmployeeSalary = null;
            EmployeeDesigner = string.Empty;
            EmployeeEmailID = string.Empty;
            DynamicSearchEmployeeName = string.Empty;
            DynamicSearchEmployeeID = null;
            DynamicSearchEmployeeSalary = null;
            DynamicSearchEmployeeDesigner = string.Empty;
            DynamicSearchEmployeeEmailID = string.Empty;
            RememberValueEmployeeName = string.Empty;
            RememberValueEmployeeID = null;
            RememberValueEmployeeSalary = null;
            RememberValueEmployeeDesigner = string.Empty;
            RememberValueEmployeeEmailID = string.Empty;
            FilteredCollection.Filter = null;
            //IsRemovingOrClearingOption = false;
        }

        public void RecoverAll(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to recover all changes of selected employee?", "Confirmation Window", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    DynamicSearchEmployeeName = RememberValueEmployeeName;
                    DynamicSearchEmployeeID = RememberValueEmployeeID.ToString();
                    DynamicSearchEmployeeSalary = RememberValueEmployeeSalary.ToString();
                    DynamicSearchEmployeeDesigner = RememberValueEmployeeDesigner;
                    DynamicSearchEmployeeEmailID = RememberValueEmployeeEmailID;
                    SelectedEmployee.EmployeeName = RememberValueEmployeeName;
                    SelectedEmployee.EmployeeID = RememberValueEmployeeID;
                    SelectedEmployee.EmployeeSalary = RememberValueEmployeeSalary;
                    SelectedEmployee.EmployeeDesigner = RememberValueEmployeeDesigner;
                    SelectedEmployee.EmployeeEmailID = RememberValueEmployeeEmailID;
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }
        public static bool CanAcceptData(IDropInfo dropInfo)
        {
            if (dropInfo == null || dropInfo.DragInfo == null)
            {
                return false;
            }

            if (!dropInfo.IsSameDragDropContextAsSource)
            {
                return false;
            }

            // do not drop on itself
            var isTreeViewItem = dropInfo.InsertPosition.HasFlag(RelativeInsertPosition.TargetItemCenter)
                                 && dropInfo.VisualTargetItem is TreeViewItem;
            if (isTreeViewItem && dropInfo.VisualTargetItem == dropInfo.DragInfo.VisualSourceItem)
            {
                return false;
            }

            if (dropInfo.DragInfo.SourceCollection == dropInfo.TargetCollection)
            {
                var targetList = dropInfo.TargetCollection.TryGetList();
                return targetList != null;
            }
            //      else if (dropInfo.DragInfo.SourceCollection is ItemCollection) {
            //        return false;
            //      }
            else if (dropInfo.TargetCollection == null)
            {
                return false;
            }
            else
            {
                if (TestCompatibleTypes(dropInfo.TargetCollection, dropInfo.Data))
                {
                    var isChildOf = IsChildOf(dropInfo.VisualTargetItem, dropInfo.DragInfo.VisualSourceItem);
                    return !isChildOf;
                }
                else
                {
                    return false;
                }
            }
        }

        public static IEnumerable ExtractData(object data)
        {
            if (data is IEnumerable && !(data is string))
            {
                return (IEnumerable)data;
            }

            return Enumerable.Repeat(data, 1);
        }
        public static void SelectDroppedItems(IDropInfo dropInfo, IEnumerable items, bool applyTemplate = true, bool focusVisualTarget = true)
        {
            if (dropInfo == null) throw new ArgumentNullException(nameof(dropInfo));
            if (items == null) throw new ArgumentNullException(nameof(items));
            var itemsControl = dropInfo.VisualTarget as ItemsControl;
            if (itemsControl != null)
            {
                var tvItem = dropInfo.VisualTargetItem as TreeViewItem;
                var tvItemIsExpanded = tvItem != null && tvItem.HasHeader && tvItem.HasItems && tvItem.IsExpanded;

                var itemsParent = tvItemIsExpanded ? tvItem : (dropInfo.VisualTargetItem != null ? ItemsControl.ItemsControlFromItemContainer(dropInfo.VisualTargetItem) : itemsControl);
                itemsParent = itemsParent ?? itemsControl;

                itemsParent.ClearSelectedItems();

                foreach (var obj in items)
                {
                    if (applyTemplate)
                    {
                        // call ApplyTemplate for TabItem in TabControl to avoid this error:
                        //
                        // System.Windows.Data Error: 4 : Cannot find source for binding with reference
                        var container = itemsParent.ItemContainerGenerator.ContainerFromItem(obj) as FrameworkElement;
                        container?.ApplyTemplate();
                    }
                    itemsParent.SetItemSelected(obj, true);
                }

                if (focusVisualTarget)
                {
                    itemsControl.Focus();
                }
            }
        }

        public static bool ShouldCopyData(IDropInfo dropInfo)
        {
            // default should always the move action/effect
            if (dropInfo == null || dropInfo.DragInfo == null)
            {
                return false;
            }
            var copyData = ((dropInfo.DragInfo.DragDropCopyKeyState != default(DragDropKeyStates)) && dropInfo.KeyStates.HasFlag(dropInfo.DragInfo.DragDropCopyKeyState))
                           || dropInfo.DragInfo.DragDropCopyKeyState.HasFlag(DragDropKeyStates.LeftMouseButton);
            copyData = copyData
                       //&& (dropInfo.DragInfo.VisualSource != dropInfo.VisualTarget)
                       && !(dropInfo.DragInfo.SourceItem is HeaderedContentControl)
                       && !(dropInfo.DragInfo.SourceItem is HeaderedItemsControl)
                       && !(dropInfo.DragInfo.SourceItem is ListViewItem);
            return copyData;
        }
        public virtual void DragOver(IDropInfo dropInfo)
        {
                if (CanAcceptData(dropInfo))
                {
                    dropInfo.Effects = ShouldCopyData(dropInfo) ? DragDropEffects.Copy : DragDropEffects.Move;
                    var isTreeViewItem = dropInfo.InsertPosition.HasFlag(RelativeInsertPosition.TargetItemCenter) && dropInfo.VisualTargetItem is TreeViewItem;
                    dropInfo.DropTargetAdorner = isTreeViewItem ? DropTargetAdorners.Highlight : DropTargetAdorners.Insert;
                }
        }
        public virtual void Drop(IDropInfo dropInfo)
        {
                if (dropInfo == null || dropInfo.DragInfo == null)
                {
                    return;
                }

                var insertIndex = dropInfo.UnfilteredInsertIndex;

                var itemsControl = dropInfo.VisualTarget as ItemsControl;
                if (itemsControl != null)
                {
                    var editableItems = itemsControl.Items as IEditableCollectionView;
                    if (editableItems != null)
                    {
                        var newItemPlaceholderPosition = editableItems.NewItemPlaceholderPosition;
                        if (newItemPlaceholderPosition == NewItemPlaceholderPosition.AtBeginning && insertIndex == 0)
                        {
                            ++insertIndex;
                        }
                        else if (newItemPlaceholderPosition == NewItemPlaceholderPosition.AtEnd && insertIndex == itemsControl.Items.Count)
                        {
                            --insertIndex;
                        }
                    }
                }

                var destinationList = dropInfo.TargetCollection.TryGetList();
                var data = ExtractData(dropInfo.Data).OfType<object>().ToList();
                var sourceList = dropInfo.DragInfo.SourceCollection.TryGetList();

                var copyData = ShouldCopyData(dropInfo);
                if (!copyData)
                {
                    //var sourceList = dropInfo.DragInfo.SourceCollection.TryGetList();
                    if (sourceList != null)
                    {
                        foreach (var o in data)
                        {
                            var index = sourceList.IndexOf(o);
                            if (index != -1)
                            {
                                sourceList.RemoveAt(index);
                                // so, is the source list the destination list too ?
                                if (destinationList != null && Equals(sourceList, destinationList) && index < insertIndex)
                                {
                                    --insertIndex;
                                }
                            }
                        }
                    }
                }

                if (destinationList != null) 
                {
                    var objects2Insert = new List<object>();

                    // check for cloning
                    var cloneData = dropInfo.Effects.HasFlag(DragDropEffects.Copy) || dropInfo.Effects.HasFlag(DragDropEffects.Link);
                    foreach (var o in data)
                    {
                        var obj2Insert = o;
                        if (cloneData)
                        {
                            var cloneable = o as ICloneable;
                            if (cloneable != null)
                            {
                                obj2Insert = cloneable.Clone();
                            }
                        }
                        objects2Insert.Add(obj2Insert);
                        destinationList.Insert(insertIndex++, obj2Insert);

                    }
                    // Robimy drag and drop i odznaczamy zaznaczony element (nie odznaczal sie) - naprawione
                    IndexesOfSelectedEmployees.Clear();
                    IndexesOfSelectedEmployees.Add(--insertIndex);

                    // Z CTRL dziala przenoszenie

                    var selectDroppedItems = itemsControl is TabControl || (itemsControl != null && GongSolutions.Wpf.DragDrop.DragDrop.GetSelectDroppedItems(itemsControl));
                    if (selectDroppedItems)
                    {
                        SelectDroppedItems(dropInfo, objects2Insert);
                    }
                }
        }

        protected static bool IsChildOf(UIElement targetItem, UIElement sourceItem)
        {
            var parent = ItemsControl.ItemsControlFromItemContainer(targetItem);

            while (parent != null)
            {
                if (parent == sourceItem)
                {
                    return true;
                }

                parent = ItemsControl.ItemsControlFromItemContainer(parent);
            }

            return false;
        }

        protected static bool TestCompatibleTypes(IEnumerable target, object data)
        {
            TypeFilter filter = (t, o) => { return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)); };

            var enumerableInterfaces = target.GetType().FindInterfaces(filter, null);
            var enumerableTypes = from i in enumerableInterfaces
                                  select i.GetGenericArguments().Single();

            if (enumerableTypes.Count() > 0)
            {
                var dataType = TypeUtilities.GetCommonBaseClass(ExtractData(data));
                return enumerableTypes.Any(t => t.IsAssignableFrom(dataType));
            }
            else
            {
                return target is IList;
            }
        }
        public static readonly DependencyProperty SelectDroppedItemsProperty;
        public static bool GetSelectDroppedItems(UIElement target)
        {
            return (bool)target.GetValue(SelectDroppedItemsProperty);
        }

        private bool CanUpdate
        {
            get
            {
                return IsValidated
                && (((SelectedEmployee != null) && (RememberValueEmployeeName != DynamicSearchEmployeeName))
                || ((SelectedEmployee != null) && (RememberValueEmployeeID.ToString() != DynamicSearchEmployeeID))
                || ((SelectedEmployee != null) && (RememberValueEmployeeSalary.ToString() != DynamicSearchEmployeeSalary))
                || ((SelectedEmployee != null) && (RememberValueEmployeeDesigner != DynamicSearchEmployeeDesigner))
                || ((SelectedEmployee != null) && (RememberValueEmployeeEmailID != DynamicSearchEmployeeEmailID)));
                // return (SelectedEmployee != null);
            }
        }

        private bool CanClear
        {
            get
            {
                return (!string.IsNullOrEmpty(DynamicSearchEmployeeName)
                    || !string.IsNullOrEmpty(DynamicSearchEmployeeID)
                    || !string.IsNullOrEmpty(DynamicSearchEmployeeSalary)
                    || !string.IsNullOrEmpty(DynamicSearchEmployeeDesigner)
                    || !string.IsNullOrEmpty(DynamicSearchEmployeeEmailID)
                    || SelectedEmployee != null
                    );
            }
        }

        private bool CanAdd
        {
            get
            {
                return
                    (
                    IsValidated
                    && (SelectedEmployee == null && !string.IsNullOrEmpty(DynamicSearchEmployeeName))
                    //&& (SelectedEmployee != null && !string.IsNullOrEmpty(DynamicSearchEmployeeSalary))
                    && (SelectedEmployee == null && !string.IsNullOrEmpty(DynamicSearchEmployeeDesigner))
                    || (IsValidated && SelectedEmployee != null)
                     );
            }
        }

        private bool CanRemove
        {
            get
            {
                return
                     SelectedEmployee != null;
            }
        }

        private bool CanEqual
        {
            get
            {
                return
                     SelectedEmployee == null;
            }
        }

        private bool CanExport
        {
            get
            {
                return
                     !FilteredCollection.IsEmpty;
            }
        }
    }
}