   M S B A M L   `   `   `  ����Q  MCinemaManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CinemaManagementSystem.ViewCinemaManagementSystem.View  5      -    'CinemaManagementSystem.View.AddFilmPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CinemaManagementSystem.View     5        N� Title$'  !Добавление фильма��5   	   $	��600��6#   $	��800��60   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $4��.Добавление нового фильма��6   $��24(�5      $
��Bold"�5      $��0,0,0,20q�5      �� 5   
   $��1��6   $��0,0,0,10q�6"   .+�5      �� $$��Название фильма:��6   $��0,0,0,5q�60   �� 5      -   5         ��Name$ NameTextBox��5      $��5q�5      ��5      �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�5      5      �� 5!   
   $��2��6   $��0,0,0,10q�6"   .+�5"      �� $3��-Длительность (в минутах):��6   $��0,0,0,5q�69   �� 5#      -   5        $ DurationTextBox��5#      $��5q�5%      ��5$      �� *
Duration+$ PropertyChanged=�5%      5&      �� 5(   
   $��3��6   $��0,0,0,10q�6"   .+�5)      �� $��	Жанр:��6   $��0,0,0,5q�6%   �� 5*      -   5         ��Name$ GenreComboBox��5*      $��5q�5+       �� DisplayMemberPath$
 Name��5,      5-      �� 5/   
   $��4��6   $��0,0,0,10q�6"   .+�50      �� $��Страна:��6   $��0,0,0,5q�6'   �� 51      -   5        $ CountryComboBox��51      $��5q�52      $
 Name��53      54      �� 56   
   $��5��6   $��0,0,0,10q�6"   .+�57      �� $2��,Возрастное ограничение:��6   $��0,0,0,5q�67   �� 58      -   5        $ AgeRestrictionComboBox��58      $��5q�59      5:      �� 5<   
   $��6��6   $��0,0,0,10q�6"   .+�5=      �� $��Описание:��6   $��0,0,0,5q�6)   �� 5>      -   5        $ DescriptionTextBox��5>      $	��100��5@       �� TextWrapping$
 Wrap=�5A       �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5C      $��5q�5D      ��5?      �� *Description+$ PropertyChanged=�5D      5E      �� 5G   
   $��7��6   	 �� Orientation$	 
Horizontal=�5H      $��Right=�5I      $��Bottom=�5J      .+�5K      �� -   5        $��Сохранить��5K      $	��100��5M      $��30��5N      $��0,0,10,0q�5O      �� 5P      -   5        $��Отмена��5P      $	��100��5R      $��30��5S      5T      5U      5V      