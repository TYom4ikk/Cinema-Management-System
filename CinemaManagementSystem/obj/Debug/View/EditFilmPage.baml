   M S B A M L   `   `   `  ����Q  MCinemaManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CinemaManagementSystem.ViewCinemaManagementSystem.View  5      .    (CinemaManagementSystem.View.EditFilmPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CinemaManagementSystem.View     5        N� Title$/  )Редактирование фильма��5	       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $, &/Assets/Styles/EditActorPageStyle.xaml?�6%   %    5      .��5      �� .��5   
   � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5!   
   �� $/��)Редактирование фильма��6   $��24(�61   $
��Bold"�6?   $��0,0,0,20q�6Q      
BlackTitle#��[  6c   �� 5#      -   5         ��Name$ FilmsComboBox��5#       �� DisplayMemberPath$ Title��5$      $��0,0,0,20q�5&      �� 5(      $��1��6   $��0,0,0,10q�6*   .+�5)      �� $$��Название фильма:��6   $��0,0,0,5q�60   #��[  6A   �� 5*      -   5         ��Name$ NameTextBox��5*      $��5q�6g   ��6+   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6g   5+      �� 5-      $��2��6   $��0,0,0,10q�6&   .+�5.      �� $3��-Длительность (в минутах):��6   $��0,0,0,5q�6=   #��[  6N   �� 5/      -   5        $ DurationTextBox��5/      $��5q�6r   ��63   �� *
Duration+$ PropertyChanged=�6r   50      �� 52      $��3��6   $��0,0,0,10q�6&   .+�53      �� $2��,Возрастное ограничение:��6   $��0,0,0,5q�67   #��[  6H   �� 54      -   5        $ AgeRestrictionComboBox��54      $��5q�67   55      �� 57   
   $��4��6   $��0,0,0,10q�6"   .+�58      �� $��Актёры:��6   $��0,0,0,5q�6'   #��[  68   �� 59      -   5        	 ��Name$	 ActorsListBox��59      $ FullName��6P   
 �� SelectionMode$
 Multiple=�6m   $	��100��6�   $
��Auto=�6�   $��5q�6�   ��6-   �� *
ActorsList+6�   5:      �� 5<   
   $��5��6   $��0,0,0,10q�6"   .+�5=      �� $��Жанры:��6   $��0,0,0,5q�6&   #��[  67   �� 5>      -   5        $	 GenresListBox��5>      $
 Name��6P   $
 Multiple=�6i   $	��100��6�   $
��Auto=�6�   $��5q�6�   ��6-   �� *
GenresList+6�   5?      �� 5A   
   $��6��6   $��0,0,0,10q�6"   .+�5B      �� $��Описание:��6   $��0,0,0,5q�6)   #��[  6:   �� 5C      -   5        $ DescriptionTextBox��5C      $	��100��6t    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6�   $��5q�6�   ��62   �� *Description+$ PropertyChanged=�6�   5D      �� 5F   
   $��7��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��Bottom=�6W   .+�5G      �� -   5        $��Сохранить��5G      $	��100��6B   $��30��6N   $��0,0,10,0q�6Z   �� 5H      -	   5        $��Отмена��5H      $	��100��6A   $��30��6M   �� 5I      -
   5        $��Удалить��5I      $	��100��6B   $��30��6N   $��10,0,0,0q�6Z   5J      5K      5L      5M      