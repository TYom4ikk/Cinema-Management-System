   M S B A M L   `   `   `  ����Q  MCinemaManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CinemaManagementSystem.ViewCinemaManagementSystem.View  5      1    +CinemaManagementSystem.View.DailyReportPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CinemaManagementSystem.View     5        N� Title$%  Ежедневный отчет��5	       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $$ /Assets/Colors/MainColors.xaml?�6%   %    5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $i��cФормирование ежедневного отчета по проданным билетам��6   $��20(�5      $
��Bold"�5      $��0,0,0,20q�5         PrimaryTextColor#��[  6&   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��0,0,0,20q�6;   .+�5       �� $ ��Выберите дату:��6   $��Center=�6.   $��0,0,10,0q�6I   #��[  6[   (  "System.Windows.Controls.DatePicker  5!      -   5          Name$ ReportDatePicker��5!      5"      �� 5$   
   -   5        $/��)Сформировать отчёт Excel��5$      $	��160��5%      $��40��5&      $��2��5'      $
��Left=�5(      5)      �� 5*   
   -   5        $.��(Сформировать отчёт Word��5*      $	��160��5+   	   $��40��5,   	   $��2��5-   	   $
��Left=�5.   	   $��
190 0 0 0 q�5/   '   50      51      