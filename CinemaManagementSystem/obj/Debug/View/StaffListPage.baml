   M S B A M L   `   `   `  ����  CinemaManagementSystem/    )CinemaManagementSystem.View.StaffListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Сотрудники��5      $	��600��6   $	��950��6'    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $) #/Assets/Styles/StaffPagesStyle.xaml?�6%   %    5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $)��#Список сотрудников��6   $��24(�5      $
��Bold"�5      $��0,0,0,20q�5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��5      $��0,0,10,0q�5       � ToolTip$9 3Поиск по ФИО или должности...��5      �� 5       -   5        $��
Найти��5       $	��100��5!      5"      5#      &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ StaffDataGrid��5%      $��2��5&      	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     SelectionMode$ Single=�5,         SelectionUnit$ FullRow=�5-         Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *
LastName+6S     50      $ Имя��6%   $ * 6P    62   �� *	FirstName+6P     51      $ Отчество��6%   $ * 6V    67   �� *
MiddleName+6V     52      $ Должность��6%   $ * 6W    68   �� *
Posts.Name+6W     53      $ Телефон��6%   $ * 6V    66   �� *PhoneNumber+6V     54      $ Дата рождения��6%   $ * 6y    6<   �� *	BirthDate+ �� StringFormat$ {0:dd.MM.yyyy}��6y     55      $ Пол��6%   $ * 6M    62   �� *Gender+6M     56      $ 
Адрес��6%   $ * 6P    64   �� *	Address+6P     57      $ 
Оклад��6%   $ * 6O    64   �� *Salary+6O     58      $ Обязанности��6%   $ * 6_    6:   �� *Responsibilities+6_     59      $ Требования��6%   $ * 6Z    69   �� *Requirements+6Z   5;      5<      5=      