using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;
using CinemaManagementSystem.View.Windows;
using CinemaManagementSystem.ViewModel;

namespace CinemaManagementSystem.View
{
    public partial class FilmsListPage : Page
    {
        private FilmsListPageViewModel model;
        public FilmsListPage()
        {
            InitializeComponent();
            model = new FilmsListPageViewModel();
            LoadFilms();
        }

        /// <summary>
        /// Загружает список фильмов и отображает их в таблице.
        /// </summary>
        /// <remarks>
        /// Формирует строку с жанрами для каждого фильма и устанавливает источник данных для <see cref="FilmsDataGrid"/>.
        /// В случае ошибки выводит сообщение.
        /// </remarks>
        private void LoadFilms()
        {
            try
            {
                var films = model.GetFilms();
                foreach (var film in films)
                {
                    film.GenresListFormattedStr = string.Join(", ", film.FilmGenres.Select(fg => fg.Genres.Name));
                }
                FilmsDataGrid.ItemsSource = films;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке фильмов: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска фильмов.
        /// </summary>
        /// <param name="sender">Источник события — кнопка поиска.</param>
        /// <param name="e">Аргументы события нажатия.</param>
        /// <remarks>
        /// Выполняет фильтрацию списка фильмов по введённому тексту в поле поиска и обновляет отображение.
        /// В случае ошибки отображает сообщение.
        /// </remarks>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchText = SearchTextBox.Text.ToLower();

                var query = model.GetFilmsAsQuery();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query = query.Where(f => f.Title.ToLower().Contains(searchText));
                }

                FilmsDataGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске фильмов: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обрабатывает изменение выбранного фильма в таблице.
        /// </summary>
        /// <param name="sender">Источник события — элемент <see cref="FilmsDataGrid"/>.</param>
        /// <param name="e">Аргументы события изменения выбора.</param>
        /// <remarks>
        /// Открывает окно с полной информацией о выбранном фильме.
        /// После закрытия сбрасывает выбор в таблице.
        /// </remarks>
        private void FilmsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilmsDataGrid.SelectedItem is Films selectedFilm)
            {
                FullFilmInfoWindow window = new FullFilmInfoWindow(selectedFilm);
                window.ShowDialog(); // или .Show() если не нужно блокировать текущее окно

                FilmsDataGrid.SelectedItem = null;
            }
        }
    }
} 