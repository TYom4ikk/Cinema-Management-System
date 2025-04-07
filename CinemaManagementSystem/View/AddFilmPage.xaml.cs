using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaManagementSystem.View
{
    /// <summary>
    /// Логика взаимодействия для AddFilmPage.xaml
    /// </summary>
    public partial class AddFilmPage : Page
    {
        private Films _currentFilm = new Films();

        public AddFilmPage()
        {
            InitializeComponent();
            DataContext = _currentFilm;
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Загружаем жанры
                GenreComboBox.ItemsSource = Core.GetContext().Genres.ToList();

                // Загружаем страны
                CountryComboBox.ItemsSource = Core.GetContext().Countries.ToList();

                // Заполняем возрастные ограничения
                AgeRestrictionComboBox.ItemsSource = new[] { 0, 6, 12, 16, 18 };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверяем обязательные поля
                if (string.IsNullOrWhiteSpace(_currentFilm.Title))
                {
                    MessageBox.Show("Введите название фильма!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (_currentFilm.Duration <= 0)
                {
                    MessageBox.Show("Введите корректную длительность фильма!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Сохраняем выбранные значения
                _currentFilm.AgeRestriction = (byte)(AgeRestrictionComboBox.SelectedItem ?? 0);

                // Добавляем фильм в базу данных
                if (_currentFilm.Id == 0)
                    Core.GetContext().Films.Add(_currentFilm);

                Core.GetContext().SaveChanges();
                MessageBox.Show("Фильм успешно сохранен!", "Информация", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении фильма: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}

