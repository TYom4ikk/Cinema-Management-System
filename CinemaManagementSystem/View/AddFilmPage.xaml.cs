using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CinemaManagementSystem.View
{
    /// <summary>
    /// Логика взаимодействия для AddFilmPage.xaml
    /// </summary>
    public partial class AddFilmPage : Page
    {
        private Films _currentFilm = new Films();

        private List<Genres> GenresList = new List<Genres>();
        private List<Actors> ActorsList = new List<Actors>();

        AddFilmPageViewModel model;
        public AddFilmPage()
        {
            InitializeComponent();
            model = new AddFilmPageViewModel();
            DataContext = _currentFilm;

            ActorsList = model.GetActors();
            ActorsListBox.ItemsSource = ActorsList;

            GenresList = model.GetGenres();
            GenresListBox.ItemsSource = GenresList;
            LoadComboBoxes();
        }
        /// <summary>
        /// Загружает данные для комбобоксов на странице редактирования фильма.
        /// </summary>
        /// <remarks>
        /// Загружает список стран из модели и устанавливает допустимые возрастные ограничения.
        /// </remarks>
        private void LoadComboBoxes()
        {
            try
            {

                CountryComboBox.ItemsSource = model.GetCountries();

                AgeRestrictionComboBox.ItemsSource = new[] { 0, 6, 12, 16, 18 };

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обрабатывает сохранение данных о фильме.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события нажатия кнопки.</param>
        /// <remarks>
        /// Проверяет корректность введённых данных, сохраняет информацию о фильме, актёрах и жанрах.
        /// </remarks>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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

                _currentFilm.AgeRestriction = byte.Parse(AgeRestrictionComboBox.SelectedItem.ToString());

                if (_currentFilm.Id == 0)
                    model.AddFilm(_currentFilm);

                foreach (Actors selectedActor in ActorsListBox.SelectedItems)
                {
                    var filmActor = new FilmActors
                    {
                        Actors = selectedActor,
                        Films = _currentFilm,
                        Role = " "
                    };

                    _currentFilm.FilmActors.Add(filmActor);
                }

                foreach (Genres selectedGenre in GenresListBox.SelectedItems)
                {
                    var filmGenre= new FilmGenres
                    {
                        Genres = selectedGenre,
                        Films = _currentFilm
                    };
                    _currentFilm.FilmGenres.Add(filmGenre);
                }

                model.SaveChanges();
                MessageBox.Show("Фильм успешно сохранен!", "Информация", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.GoBack();

                ActorsList = model.GetActors();
                ActorsListBox.ItemsSource = ActorsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении фильма: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Возвращает пользователя на предыдущую страницу без сохранения изменений.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события нажатия кнопки.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}