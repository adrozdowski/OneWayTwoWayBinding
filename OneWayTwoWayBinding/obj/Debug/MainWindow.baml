   M S B A M L   `   `   `  ����N  JOneWayTwoWayBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:OneWayTwoWayBindingOneWayTwoWayBinding  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   a ]GongSolutions.WPF.DragDrop, Version=2.0.0.0, Culture=neutral, PublicKeyToken=91f1945125b7a587kLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDropGongSolutions.Wpf.DragDrop 5	   	   $    OneWayTwoWayBinding.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:OneWayTwoWayBinding     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.Command http://www.galasoft.ch/mvvmlight  5   	   UddLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDrop  5	   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1024��6)    � 	Resources 5      2   ,OneWayTwoWayBinding.ConverterStringFiltering   ConverterStringFiltering)   #OneWayTwoWayBinding.ConverterButton  ConverterButton/   )OneWayTwoWayBinding.ConverterIntFiltering  ConverterIntFiltering  ErrorToolTipTemplate_1 � 	Resources  Key �� 
TargetType �� Property �� Value �� CornerRadius  textblockErrorTooltip �� Triggers P� Property	 P� Value
 �� RelativeSource �� Path��%�  &	        &	      &	 &     &	 9     7  '�� �      5   
   6)     5   
   6      5   
   6&   �� 5   
    5      ���� 5      textblockErrorTooltip " ��66   .�5      ��  � ��$ Center=�6<   �� 5       � ��$ Center=�6:   �� 5       � ��$
 Bold"�63   �� 5       � ��
 �����63   �� 5       � ��$ 0 0 0 0q�6/   5      5      .R�5      ]� ��. .+�5      �� $
��Auto��6   $��0,0,0,0q�5      ���#DC000C$ 0��5!      $��Bottom=�5"      ._�5#      �� ��6#   �� ��5$      �� 5%      .R�5&   "   �� 8��  ��5'      �� *ErrorContent+5(      5*      5+      �� 5,      $��customAdorner��6,   .v�5-      �� ���#DC000C$	��1.3q�63   5.      5/      50      �� 52   
   " ��6   .�53      ��  � ��$ Right=�64   �� 54       � ��$	 Top=�62   �� 55       � ��$	 150��6&   �� 56       � ��$ 30��6'   �� 57       �@=�ErrorTemplate# �  58       59      P� 5:       �@=�HasError	 . . �5;      ��  �@�ToolTip 5<      �� 
 �� *Self+$) #(Validation.Errors)[0].ErrorContent�5=      5?      5@      .��5B      � $��0,0,0,0q�6    � RowDefinitions 5C   
   �� 5D      $
��Auto �6   �� 5E      $��* �6   �� 5F      $
��Auto �6   .+�5H   
   �� -   5        $��EmployeeListView��5H      $
��Left=�6+   $	��160��6F   $��	0,153,0,0q�6S   $	��Top=�6f   $	��755��6~   $��1��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6y   �� SelectionMode$ Extended=�6�   J� 	AllowDrop . )  #GongSolutions.Wpf.DragDrop.DragDrop   IsDragSource .    IsDropTarget . "   ShowAlwaysDropTargetAdorner .    UseDefaultDragAdorner .    SelectDroppedItems .    DragDropCopyKeyState$ AltKey=�5O      #   UseDefaultEffectDataTemplate .  �� SelectedIndex 5H   �   �� *SelectedIndex+��6�   �� *FilteredCollection+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6  �� *SelectedEmployee+$ TwoWay=�$ PropertyChanged=�   DropHandler 5N      ��  �� View 5Q      �� 5R      .P�5S      ��  �� Width$	 150��6T    �� DisplayMemberBinding 6%   �� *EmployeeName+.��5T      �� $��EmployeeName��60   $��EmployeeName��5V      ��5U      �� *SortCommand+5V      5W      �� 5X      $	 150��6R    6%   �� *
EmployeeID+.��5Y      �� $��
EmployeeID��60   $��
EmployeeID��5[      ��5Z      �� *SortCommand+5[      5\      �� 5]      $	 150��6V    6%   �� *EmployeeSalary+.��5^      �� $��EmployeeSalary��60   $��EmployeeSalary��5`      ��5_      �� *SortCommand+5`      5a      �� 5b      $	 150��6X    6%   �� *EmployeeDesigner+.��5c      �� $��EmployeeDesigner��60   $��EmployeeDesigner��5e      ��5d      �� *SortCommand+5e      5f      �� 5g      $	 150��6W    6%   �� *EmployeeEmailID+.��5h      �� $��EmployeeEmailID��60   $��EmployeeEmailID��5j      ��5i      �� *SortCommand+5j      5k      5s      ��5u      �� 5v      " ��6   .�5w      ��  �@��
IsSelected 63   �� $ TwoWay=�$ 
IsSelected�$ PropertyChanged=��� 5z       � ��$ 0q�60   �� 5{       � ��$ 0q�6/   �� 5|       � ��$ 0q�68    5      P� 5�       �@��
IsSelected	 . . �5�      ��  � ��
 � � �6;   �� 5�       � ��
 �����6;   5�      P� 5�       �@J�IsMouseOver	 . . �5�      ��  � ��
 ����6;   �� 5�       � ��
 �   �6;   5�      ]� 5�       ]� 
Conditions 5�      �� 5�   "     �� Property  �@J�IsMouseOver! �� Value! . 6C   �� 5�   "     �@��
IsSelected! . 6B   /�5�      �� 5�   "    � ��
 � d �6?   �� 5�   "    � ��
 �����6?   5�      5�      .  (System.Windows.Interactivity.Interaction"   Triggers" 5�      /  )System.Windows.Interactivity.EventTrigger  5�      #   	EventName$# SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase$   Actions.$ 5�      6  0System.Windows.Interactivity.InvokeCommandAction  %   Command% 6,   �� *SelectionChanged+&   CommandParameter& 6Q   �� ' �� ElementName$' EmployeeListView��$ SelectedItems�5�        5�      $# MouseLeftButtonUp��6!   .$ 5�        % 6,   �� *ClickCommand+& 6M   �� $' EmployeeListView��$ SelectedItems�5�        5�      $
# Drop��6!   .$ 5�      /	  )GalaSoft.MvvmLight.Command.EventToCommand	  ( 	  PassEventArgsToCommand( . ) 	  Command) 6.   �� *DropCommand+6N   5�      5�      �� 5�   
   $��Employee Name��6   $
��Left=�6(   $��4,82,0,0q�6C   $	��Top=�6U   $	��151��6m   $��23��6y   �� 5�   
   -   5        $��TextboxEmployeeName��5�      $
��Left=�6.   $��23��6I   $��
169,82,0,0q�6U   $	��Top=�6i   $	��522��6�   .��6�   ��5�      `� 5�      * `� 	Converter#* [  6   + `� Mode$+ TwoWay=�6U   , `� UpdateSourceTrigger$, PropertyChanged=�6c   .1�5�      �� $# SelectedEmployee.EmployeeName�6   $ OneWay=�6C   $ PropertyChanged=�6Q   �� 5�      $ DynamicSearchEmployeeName�6   $ TwoWay=�6@   $ PropertyChanged=�6N   - �� ValidatesOnDataErrors- . 6t   5�      .��5�      5�      �� 5�   
   $��
EmployeeID��6   $
��Left=�6%   $��	5,138,0,0q�6@   $	��Top=�6S   $	��145��6k   $��23��6w   �� 5�   
   -   5        $��TextboxEmployeeID��5�      $
��Left=�6,   $��23��6G   $��170,138,0,0q�6S   $	��Top=�6i   $	��522��6�   {�6�   �� *TextboxActive+.��6�   ��5�      `� 5�      #* [  6   $+ TwoWay=�6U   $, PropertyChanged=�6c   .1�5�      �� $! SelectedEmployee.EmployeeID�6   $ OneWay=�6A   $ PropertyChanged=�6O   �� 5�      $ DynamicSearchEmployeeID�6   $ TwoWay=�6>   $ PropertyChanged=�6L   - . 6r   5�      .��5�      . =� ErrorTemplate. 5�      �� 5�       5�      ��%�   &	       �� 5�      " ��6>   .�5�      ��  � ��$ Center=�6D   �� 5�       � ��$ Center=�6B   �� 5�       � ��$
 Bold"�6;   �� 5�       � ��
 �����6;   �� 5�       � ��$ 0 0 0 0q�67   5�      5�      .R�5�      ]� ��. .+�5�      �� $
��Auto��6!   $��0,0,0,0q�5�      ���#007ADC$ 0��5�      $��Bottom=�5�      ._�5�      �� ��6+   �� ��5�   "   �� 5�   &   .R�5�   *   �� #��[ 64   ��5�      �� *ErrorContent+5�   '   5�      5�      �� 5�      $��customAdorner��64   .v�5�      �� ���#007ADC$	��1.3q�6;   5�      5�      5�      .��5�   (   5�      �� 5�   
   $��EmpoyeeSalary��6   $
��Left=�6(   $��	4,192,0,0q�6C   $	��Top=�6V   $	��151��6n   $��23��6z   �� 5�   
   -   5        $��TextboxEmployeeSalary��5�      $
��Left=�6/   $��23��6J   $��169,192,0,0q�6V   $	��Top=�6k   $	��522��6�   .��6�   ��5�      `� 5�      #* [  6   $+ TwoWay=�6U   $, PropertyChanged=�6c   .1�5�      �� $% SelectedEmployee.EmployeeSalary�6   $ OneWay=�6E   $ PropertyChanged=�6S   �� 5�      $! DynamicSearchEmployeeSalary�6   $ TwoWay=�6B   $ PropertyChanged=�6P   - . 6v   5�      .��5�      5�      �� 5�   
   $��EmployeeDesigner��6   $
��Left=�6+   $��4,54,0,0q�6F   $	��Top=�6X   $	��151��6p   $��23��6|   $��1��6�   �� 5�   
   -   5        $��TextboxEmployeeDesigner��5�      $
��Left=�62   $��23��6M   $��
169,54,0,0q�6Y   $	��Top=�6m   $	��522��6�   $��1��6�   .��6�   ��5�      `� 5�      #* [  6   $+ TwoWay=�6U   $, PropertyChanged=�6c   .1�5�      �� $' !SelectedEmployee.EmployeeDesigner�6   $ OneWay=�6G   $ PropertyChanged=�6U   �� 5�      $# DynamicSearchEmployeeDesigner�6   $ TwoWay=�6D   $ PropertyChanged=�6R   - . 6x   5�      .��5�      5�      �� 5�   
   $��EmployeeEmailID��6   $
��Left=�6*   $��	4,107,0,0q�6E   $	��Top=�6X   $	��151��6p   $��23��6|   $��1��6�   �� 5�   
   -   5        $��TextboxEmployeeEmailID��5�      $
��Left=�60   $��23��6K   $��169,107,0,0q�6W   $	��Top=�6l   $	��522��6�   $��1��6�   .��6�   ��5�      `� 5�      #* [  6   $+ TwoWay=�6U   $, PropertyChanged=�6c   .1�5�      �� $&  SelectedEmployee.EmployeeEmailID�6   $ OneWay=�6F   $ PropertyChanged=�6T   �� 5�      $" DynamicSearchEmployeeEmailID�6   $ TwoWay=�6C   $ PropertyChanged=�6Q   5�      .��5�      5�      �� 5  
   $��Update��6   $
��Left=�6"   $��
692,76,0,0q�6=   $	��Top=�6Q   $��75��6i   / J� RenderTransformOrigin$/ -0.017,0.456&�6t   ��6�   �� *UpdateCommand+��5     `� 5     #* [ 6   $, PropertyChanged=�6L   $+ TwoWay=�6r   .1�5     �� $' TextboxEmployeeName��6   $
 Text�6@   �� 5     $' TextboxEmployeeID��6   $
 Text�6>   �� 5     $' TextboxEmployeeSalary��6   $
 Text�6B   �� 5     $' TextboxEmployeeDesigner��6   $
 Text�6D   �� 5     $' TextboxEmployeeEmailID��6   $
 Text�6C   5	     5     �� 5  
   $
��Left=�6   $��	10,10,0,0q�6/   $
��Wrap=�6B   $	��Top=�6�   $	��390��6�   $��37��6�   $��20(�6�   ��6V   �� *ModeOfExecuting+$ PropertyChanged=�$ TwoWay=�6�   �� 5  
   $��Clear��6   $
��Left=�6!   $��692,116,0,0q�6<   $	��Top=�6Q   $��75��6i   $/ -0.017,0.456&�6t   ��6�   �� *ClearCommand+5     �� 5  
   $	��Add��6   $
��Left=�6   $��692,161,0,0q�6:   $	��Top=�6O   $��75��6g   $/ -0.017,0.456&�6r   ��6�   �� *
AddCommand+��5     `� 5     #* [ 6   $, PropertyChanged=�6L   $+ TwoWay=�6r   .1�5     �� $' TextboxEmployeeName��6   $
 Text�6@   �� 5     $' TextboxEmployeeID��6   $
 Text�6>   �� 5     $' TextboxEmployeeSalary��6   $
 Text�6B   �� 5     $' TextboxEmployeeDesigner��6   $
 Text�6D   �� 5     $' TextboxEmployeeEmailID��6   $
 Text�6C   5      5"     �� 5#  
   $��Remove��6   $
��Left=�6"   $��692,206,0,0q�6=   $	��Top=�6R   $��75��6j   $/ -0.017,0.456&�6u   ��6�   �� *RemoveCommand+��6�   �� $' EmployeeListView��$ SelectedItems�5.     d� 5/  
   $��<��6   $
��Left=�6&   $��	10,10,0,0q�6A   $��1��6T   $	��Top=�6a   $��37��6y   0 d� 	IsChecked0 6�   �� *IsPressedLess+��6�   �� *IsLessCommand+{�6�   �� *IsLessButtonActive+��50     �� 51     " d�6   .�52     ��  � �� 53     �� 54     1 �� 
TargetType"1 d�6.   .R�55  "   �� #��z��6)   #��z��56  !   ._�57  &   �� $��Center=�67   $��Center=�58  /   59  #   5:     5<      5=     P� 5>      �@d�	IsChecked$
	 TrueY�67   . �5?     ��  � ��
 � ���6;   5@     5B     5D     d� 5E  
   $��=��6   $
��Left=�6#   $��	64,10,0,0q�6>   $��1��6Q   $	��Top=�6^   $��37��6v   0 6�   �� *IsPressedEqual+��6�   �� *IsEqualCommand+{�6�   �� *IsEqualButtonActive+��5F     �� 5G     " d�6   .�5H     ��  � �� 5I     �� 5J     "1 d�6.   .R�5K  "   �� #��z��6)   #��z��5L  !   ._�5M  &   �� $��Center=�67   $��Center=�5N  /   5O  #   5P     5R      5S     P� 5T      �@d�	IsChecked$
	 TrueY�67   . �5U     ��  � ��
 � ���6;   5V     5X     5Z     d� 5[  
   $��>��6   $
��Left=�6#   $��
118,10,0,0q�6>   $��1��6R   $	��Top=�6_   $��37��6w   0 6�   �� *IsPressedGreater+��6�   �� *IsGreaterCommand+{�6�   �� *IsGreaterButtonActive+��5\     �� 5]     " d�6   .�5^     ��  � �� 5_     �� 5`     "1 d�6.   .R�5a  "   �� #��z��6)   #��z��5b  !   ._�5c  &   �� $��Center=�67   $��Center=�5d  /   5e  #   5f     5h      5i     P� 5j      �@d�	IsChecked$
	 TrueY�67   . �5k     ��  � ��
 � ���6;   5l     5n     5p     �� 5q  
   $��Recover All��6   $
��Left=�6'   $��
692,27,0,0q�6B   $	��Top=�6V   $��75��6n   $/ -0.017,0.456&�6y   $��1��6�   ��6�   �� *RecoverAllCommand+6�   �� 5r  
   $
��Left=�6   $��
819,53,0,0q�6/   $��1��6C   $
��Wrap=�6P   $	��Top=�6�   $	��141��6�   $��24��6�   ��6d   �� *CountOfSelectedEmployees+6�   �� 5s  
   $��Count of selected items��6   $
��Left=�62   $��
819,27,0,0q�6M   $��1��6a   $	��Top=�6n   �� 5t  
   $��Export��6   $
��Left=�6"   $��
692,72,0,0q�6=   $	��Top=�6Q   $��75��6i   $/ -0.017,0.456&�6t   $��1��6�   ��6�   �� *ExportToCSVFileCommand+6�   �� 5u  
   $��	More Info��6   $
��Left=�6%   $��692,115,0,0q�6@   $	��Top=�6U   $��75��6m   $/ -0.017,0.456&�6x   $��1��6�   ��6�   �� *OpenMoreInfoCommand+6�   5v     5w     