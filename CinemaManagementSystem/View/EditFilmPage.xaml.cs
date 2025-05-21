using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;
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
    /// Логика взаимодействия для EditFilmPage.xaml
    /// </summary>
    public partial class EditFilmPage : Page
    {
        private EditFilmPageViewModel model;
        private Films _currentFilm;
        private List<Genres> GenresList = new List<Genres>();
        private List<Actors> ActorsList = new List<Actors>();

        public EditFilmPage()
        {
            InitializeComponent();
            model = new EditFilmPageViewModel();

            var films = model.GetFilms();
            if (films.Count == 0)
            {
                MessageBox.Show("Нет фильмов для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            FilmsComboBox.ItemsSource = films;
            FilmsComboBox.SelectedIndex = 0;

            AgeRestrictionComboBox.SelectedIndex = 0; 
        }
        /// <summary>
        /// Загружает данные выбранного фильма и связанные элементы управления.
        /// </summary>
        /// <param name="selectedFilm">Выбранный фильм.</param>
        private void LoadData(Films selectedFilm)
        {
            _currentFilm = selectedFilm;
            DataContext = _currentFilm;

            ActorsList = model.GetActors();
            GenresList = model.GetGenres();

            ActorsListBox.ItemsSource = ActorsList;
            GenresListBox.ItemsSource = GenresList;

            LoadComboBoxes();
            LoadSelectedItems();
        }
        /// <summary>
        /// Загружает значения в комбобоксы (ограничение по возрасту).
        /// </summary>
        private void LoadComboBoxes()
        {
            AgeRestrictionComboBox.ItemsSource = new[] { 0, 6, 12, 16, 18 };
            AgeRestrictionComboBox.SelectedItem = _currentFilm.AgeRestriction;
        }
        /// <summary>
        /// Загружает выбранных актёров и жанры в списки выбора.
        /// </summary>
        private void LoadSelectedItems()
        {
            ActorsListBox.SelectedItems.Clear();
            GenresListBox.SelectedItems.Clear();

            foreach (var actor in _currentFilm.FilmActors.Select(fa => fa.Actors))
            {
                ActorsListBox.SelectedItems.Add(actor);
            }

            foreach (var genre in _currentFilm.FilmGenres.Select(fg => fg.Genres))
            {
                GenresListBox.SelectedItems.Add(genre);
            }
        }
        /// <summary>
        /// Обработка изменения выбора фильма в комбобоксе.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события выбора.</param>
        private void FilmsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilmsComboBox.SelectedItem is Films selectedFilm)
            {
                LoadData(selectedFilm);
            }
        }
        /// <summary>
        /// Сохраняет изменения данных фильма.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_currentFilm.Title))
                {
                    MessageBox.Show("Введите название фильма!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (_currentFilm.Duration <= 0)
                {
                    MessageBox.Show("Введите корректную длительность!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                _currentFilm.AgeRestriction = byte.Parse(AgeRestrictionComboBox.SelectedItem.ToString());

                // Очистка старых связей
                _currentFilm.FilmActors.Clear();
                _currentFilm.FilmGenres.Clear();

                foreach (Actors selectedActor in ActorsListBox.SelectedItems)
                {
                    _currentFilm.FilmActors.Add(new FilmActors
                    {
                        ActorId = selectedActor.Id,
                        Actors = selectedActor,
                        Films = _currentFilm,
                        FilmId = _currentFilm.Id,
                        Role = " "
                    });
                }

                foreach (Genres selectedGenre in GenresListBox.SelectedItems)
                {
                    _currentFilm.FilmGenres.Add(new FilmGenres
                    {
                        GenreId = selectedGenre.Id,
                        Genres = selectedGenre,
                        Films = _currentFilm,
                        FilmId = _currentFilm.Id
                    });
                    GenresList.Add(selectedGenre);
                }

                model.SaveChanges();
                MessageBox.Show("Фильм успешно обновлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении фильма: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Отменяет редактирование фильма и возвращается назад.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
        /// <summary>
        /// Удаляет выбранный фильм после подтверждения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данный фильм?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                model.RemoveFilm(_currentFilm);
                model.SaveChanges();
                MessageBox.Show("Фильм удалён!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.GoBack();
            }
        }
    }
}