   M S B A M L   `   `   `  ����  CinemaManagementSystem.    (CinemaManagementSystem.View.SchedulePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$)  #Расписание сеансов��5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $$ /Assets/Colors/MainColors.xaml?�6%   %    5      .��5      � $��20q�6      BackgroundColor#��[  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $)��#Расписание сеансов��6   $��24(�5      $
��Bold"�5      $��0,0,0,20q�5        PrimaryTextColor#��[ 5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�5      $��0,0,0,10q�5      .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ 
DateFilter��5      $	��150��5       $��0,0,10,0q�5!      �� 5"      -   5        $��Показать��5"      $	��100��5#        ButtonBackground#��[ 5%        ButtonForeground#��[ 5&      ��5'      �� 5(       �� 
TargetType" ��6    �� Triggers 5)      P� 5*      	 P� Property	 �@J�IsMouseOver
 P� Value
 . . �5+   "   ��  �� Property � ��  ButtonBackgroundHover �� Value# [ 6?   5,      P� 5-      	 � ��
 . . �5.   "   ��  � ��# [ 6?   5/      51      53      �� 54      -   5        $��Сбросить��54      $	��100��55      $��10,0,0,0q�56      #��[ 58      #��[ 59      ��5:      �� 5;      " ��6    5<      P� 5=      	 �@J�IsMouseOver
 . . �5>   "   ��  � ��# [ 6?   5?      P� 5@      	 � ��
 . . �5A   "   ��  � ��# [ 6?   5B      5D      5F      5G      &   System.Windows.Controls.DataGrid  5J   
   -   5          Name$ SessionsDataGrid��5J      $��2��5K         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5N         Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Фильм��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Films.Title+6T     5R      $ Дата и время��6%   $ * 6|    6;   �� *StartDateTime+ �� StringFormat$ dd.MM.yyyy HH:mm��6|     5S      $ Цена��6%   $ * 6f    63   �� *Price+$ {0} руб.��6f   4  .System.Windows.Controls.DataGridTemplateColumn  5T      $ * 6)      CellTemplate 5U      �� 5V      .R�5W      �� $��Купить билет��6%   #��[ 5X   %   #��[ 5Y   %   ��5Z   "   �� 5[   &   " ��6,    5\   *   P� 5]   .   	 �@J�IsMouseOver
 . . �5^   2   ��  � ��# [ 6O   5_   /   P� 5`   .   	 � ��
 . . �5a   2   ��  � ��# [ 6O   5b   /   5d   '   5f      5g      5i      5k      5l      5m      