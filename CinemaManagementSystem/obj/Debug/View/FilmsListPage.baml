   M S B A M L   `   `   `  ����  CinemaManagementSystem/    )CinemaManagementSystem.View.FilmsListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$!  Список фильмов��5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��6-   $��0,0,10,0q�69    � ToolTip$) #Поиск по названию...��5      (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
DateFilter��5      $	��150��6-   $��0,0,10,0q�69   �� 5      -   5        $��
Найти��5      $	��100��6%   61   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ FilmsDataGrid��5      $��1��6*      AutoGenerateColumns .     
IsReadOnly . 	   SelectionMode$	 Single=�5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Title+6Q     5      $ Длительность��6%   $	 100 6X    6;   �� *
Duration+6X     5      $ Жанр��6%   $	 150 6N    63   �� *Genres+6N     5      $ Страна��6%   $	 150 6\    65   �� *ProducingCompanies+6\     5      $1 +Возрастное ограничение��6%   $	 150 6h    6E   �� *AgeRestriction+6h   5      5      5       