   M S B A M L   `   `   `  ����  CinemaManagementSystem0    *CinemaManagementSystem.View.AddSessionPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$'  !Добавление сеанса��5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $4��.Добавление нового сеанса��6   $��24(�5      $
��Bold"�5      $��0,0,0,20q�5      �� 5   
   $��1��6   $��0,0,0,10q�6"   .+�5      �� $��Фильм:��6   $��0,0,0,5q�6&   �� 5      -   5         ��Name$ FilmComboBox��5       �� DisplayMemberPath$ Title��5      $��5q�5      5      �� 5   
   $��2��6   $��0,0,0,10q�6"   .+�5      �� $��	Дата:��6   $��0,0,0,5q�6%   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
DatePicker��5      $��5q�5      5      �� 5!   
   $��3��6   $��0,0,0,10q�6"   .+�5"      �� $��Время начала:��6   $��0,0,0,5q�6-   �� 5#      -   5         ��Name$ TimeTextBox��5#      $��5q�5$      �� 5%      $��Формат: ЧЧ:ММ��6   
�������$��12(�5'      5(      �� 5*   
   $��4��6   $��0,0,0,10q�6"   .+�5+      �� $$��Время окончания:��6   $��0,0,0,5q�60   �� 5,      -   5        $ EndTimeTextBox��5,      $��5q�5-      �� 5.      $��Формат: ЧЧ:ММ��6   
�������$��12(�50      51      �� 53   
   $��5��6   $��0,0,0,10q�6"   .+�54      �� $��Цена билета:��6   $��0,0,0,5q�6,   �� 55      -   5        $ PriceTextBox��55      $��5q�6,   68   56      �� 59   
   $��7��6    �� Orientation$ 
Horizontal=�5:      $��Right=�5;      $��Bottom=�5<      .+�5=      �� -   5        $��Сохранить��5=      $	��100��5?      $��30��5@      $��0,0,10,0q�5A      �� 5B      -   5        $��Отмена��5B      $	��100��5D      $��30��5E      5F      5G      5H      