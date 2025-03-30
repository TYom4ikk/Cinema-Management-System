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
        private Films _film;

        public AddFilmPage()
        {
            InitializeComponent();
            _film = new Films();
            DataContext = _film;

            // Загрузка жанров
            GenreComboBox.ItemsSource = Core.GetContext().Genres.ToList();

            // Загрузка стран
            CountryComboBox.ItemsSource = Core.GetContext().Countries.ToList();

            // Загрузка возрастных ограничений
            AgeRestrictionComboBox.ItemsSource = new List<string> { "0+", "6+", "12+", "16+", "18+" };
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    // Создаем новый фильм
                    var newFilm = new Films
                    {
                        Title = _film.Title,
                        Duration = _film.Duration,
                        AgeRestriction = GetAgeRestrictionValue(AgeRestrictionComboBox.SelectedItem.ToString()),
                        Description = _film.Description
                    };

                    // Добавляем выбранный жанр
                    if (GenreComboBox.SelectedItem is Genres selectedGenre)
                    {
                        newFilm.Genres.Add(selectedGenre);
                    }

                    // Сохраняем в базу данных
                    Core.GetContext().Films.Add(newFilm);
                    Core.GetContext().SaveChanges();

                    MessageBox.Show("Фильм успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new FilmsListPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private byte GetAgeRestrictionValue(string ageRestriction)
        {
            switch (ageRestriction)
            {
                case "0+":
                    return 0;
                case "6+":
                    return 6;
                case "12+":
                    return 12;
                case "16+":
                    return 16;
                case "18+":
                    return 18;
                default:
                    return 0;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_film.Title))
            {
                MessageBox.Show("Введите название фильма", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (_film.Duration <= 0)
            {
                MessageBox.Show("Введите корректную длительность фильма", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (GenreComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите жанр фильма", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (AgeRestrictionComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите возрастное ограничение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FilmsListPage());
        }
    }
}

