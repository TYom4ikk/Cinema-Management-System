   M S B A M L   `   `   `  ����  CinemaManagementSystem/    )CinemaManagementSystem.View.ActorListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$!  Список актеров��5      $	��600��6   $	��800��6+    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $$ /Assets/Colors/MainColors.xaml?�6%   %    5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $!��Список актеров��6   $��24(�5      $
��Bold"�5      $��0,0,0,20q�5         PrimaryTextColor#��[  6&   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�5      $��0,0,0,20q�5      .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��300��5      $��30��5       $��0,0,10,0q�5!       � ToolTip$9 3Поиск по имени или фамилии...��5"      �� 5#      -   5         ��Name$ CountryFilter��5#      $	��200��5$      $��30��5%      $��0,0,10,0q�5&      	 �� DisplayMemberPath$
	 Name��5(      �� 5)      -   5        $��
Поиск��5)      $	��100��5+      $��30��5,      $��0,0,10,0q�5-      5.      &   System.Windows.Controls.DataGrid  50   
   -   5        
  Name$
 ActorsDataGrid��51      $��2��50         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�54         Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *	FirstName+6P     58      $ Фамилия��6%   $	 150 6S    66   �� *
LastName+6S     59      $ Отчество��6%   $	 150 6V    67   �� *
MiddleName+6V     5:      $ Дата рождения��6%   $	 120 6s    6<   �� *	BirthDate+ �� StringFormat$ 
dd.MM.yyyy��6s     5;      $ Страна��6%   $	 150 6X    65   �� *Countries.Name+6X   5=      5@      5A      