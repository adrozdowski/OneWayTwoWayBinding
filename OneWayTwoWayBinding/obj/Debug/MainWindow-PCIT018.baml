   M S B A M L   `   `   `  ����N  JOneWayTwoWayBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:OneWayTwoWayBindingOneWayTwoWayBinding  5   	   $    OneWayTwoWayBinding.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:OneWayTwoWayBinding     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	      $   OneWayTwoWayBinding.Converters   NullableValueConverter,   &OneWayTwoWayBinding.ConverterFiltering  ConverterFiltering)   #OneWayTwoWayBinding.ConverterButton  ConverterButton��%W   &	        &	      &	 &       5
   
   6     5   
   6#     5   
   6    5      .��5      � $��0,0,0,20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��EmployeeListView��5      $
��Left=�6+   $	��160��6F   $��	0,259,0,0q�6S   $	��Top=�6f   $	��792��6~   ��6�   �� *FilteredCollection+ �� SelectedItem 6�   �� *SelectedEmployee+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedIndex 6  �� *ChangedPathBinding+ �� View 5      �� 5      .P�5      �� $��EmployeeName��6%    �� Width$	 150��6;   	 �� DisplayMemberBinding	 6G   �� *EmployeeName+�� 5      $��
EmployeeID��6%   $	 150��69   	 6E   �� *
EmployeeID+�� 5      $��EmployeeSalary��6%   $	 150��6=   	 6I   �� *EmployeeSalary+�� 5      $��EmployeeDesigner��6%   $	 150��6?   	 6K   �� *EmployeeDesigner+�� 5      $��EmployeeEmailID��6%   $	 150��6>   	 6J   �� *EmployeeEmailID+5      5      �� 5   
   $��Employee Name��6   $
��Left=�6(   $��	15,52,0,0q�6C   $	��Top=�6V   $��77��6n   $��23��6y   �� 5!   
   -   5        $��TextboxEmployeeName��5!      $
��Left=�6.   $��23��6I   $��	97,52,0,0q�6U   $	��Top=�6h   $	��522��6�   .��6�   ��5"      `� 5#      
 `� 	Converter#
 [ 6    `� Mode$ TwoWay=�6O    `� UpdateSourceTrigger$ PropertyChanged=�6]   .1�5$      ��  �� Path$# SelectedEmployee.EmployeeName�6   $ OneWay=�6C   $ PropertyChanged=�6Q   �� 5%      $ DynamicSearchEmployeeName�6   $ TwoWay=�6@   $ PropertyChanged=�6N   5&      .��5'      5(      �� 5*   
   $��Label��6   $
��Left=�6    $��	15,91,0,0q�6;   $	��Top=�6N   $��77��6f   $��23��6q   �� 5,   
   -   5        $��TextboxEmployeeID��5,      $
��Left=�6,   $��23��6G   $��	97,91,0,0q�6S   $	��Top=�6g   $	��522��6   .��6�   ��5-      `� 5.      #
 [ 6   $ TwoWay=�6O   $ PropertyChanged=�6]   .1�5/      �� $! SelectedEmployee.EmployeeID�6   $ OneWay=�6A   $ PropertyChanged=�6O   �� 50      $ DynamicSearchEmployeeID�6   $ TwoWay=�6>   $ PropertyChanged=�6L   51      .��52      53      �� 56   
   $��Label��6   $
��Left=�6    $��
15,131,0,0q�6;   $	��Top=�6O   $��77��6g   $��23��6r   �� 58   
   -   5        $��TextboxEmployeeSalary��58      $
��Left=�6/   $��23��6J   $��
97,131,0,0q�6V   $	��Top=�6j   $	��522��6�   .��6�   ��59      `� 5:      #
 [ 6#   $ TwoWay=�6S   $ PropertyChanged=�6a   .1�5;      �� $% SelectedEmployee.EmployeeSalary�6"   $ OneWay=�6I   $ PropertyChanged=�6W   �� 5<      $! DynamicSearchEmployeeSalary�6"   $ TwoWay=�6F   $ PropertyChanged=�6T   5=      .��5>       5?      �� 5A      $��Label��6   $
��Left=�6$   $��
15,176,0,0q�6?   $	��Top=�6S   $��77��6k   $��23��6v   �� 5C   
   -   5        $��TextboxEmployeeDesigner��5C      $
��Left=�62   $��23��6M   $��
97,176,0,0q�6Y   $	��Top=�6m   $	��522��6�   .��6�   ��5D      `� 5E      #
 [ 6#   $ TwoWay=�6S   $ PropertyChanged=�6a   .1�5F      �� $' !SelectedEmployee.EmployeeDesigner�6"   $ OneWay=�6K   $ PropertyChanged=�6Y   �� 5G      $# DynamicSearchEmployeeDesigner�6"   $ TwoWay=�6H   $ PropertyChanged=�6V   5H      .��5I       5J      �� 5L   
   $��Label��6   $
��Left=�6    $��
15,221,0,0q�6;   $	��Top=�6O   $��77��6g   $��23��6r   �� 5M   
   -   5        $��TextboxEmployeeEmailID��5M      $
��Left=�60   $��23��6K   $��
97,221,0,0q�6W   $	��Top=�6k   $	��522��6�   .��6�   ��5O   
   `� 5P      #
 [ 6   $ TwoWay=�6O   $ PropertyChanged=�6]   .1�5Q      �� $&  SelectedEmployee.EmployeeEmailID�6   $ OneWay=�6F   $ PropertyChanged=�6T   �� 5R      $" DynamicSearchEmployeeEmailID�6   $ TwoWay=�6C   $ PropertyChanged=�6Q   5S      .��5T      5U      �� 5W   
   $��Button��6   $
��Left=�6"   $��663,116,0,0q�6=   $	��Top=�6R   $��75��6j    J� RenderTransformOrigin$ -0.017,0.456&�6u   ��6�   �� *SaveCommand+��5X      `� 5Y      #
 [ 6   $ PropertyChanged=�6L   $ TwoWay=�6r   .1�5Z      ��  �� ElementName$ TextboxEmployeeName��6   $
 Text�6@   �� 5[      $ TextboxEmployeeID��6   $
 Text�6>   �� 5\      $ TextboxEmployeeSalary��6   $
 Text�6B   �� 5]      $ TextboxEmployeeDesigner��6   $
 Text�6D   �� 5^      $ TextboxEmployeeEmailID��6   $
 Text�6C   5_      5a      5c      5d      