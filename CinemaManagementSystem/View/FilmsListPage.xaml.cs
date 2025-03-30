using System.Windows;
using System.Windows.Controls;
using System.Linq;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.View
{
    public partial class FilmsListPage : Page
    {
        public FilmsListPage()
        {
            InitializeComponent();
            LoadFilms();
        }

        private void LoadFilms()
        {
            var films = Core.GetContext().Films.ToList();
            FilmsDataGrid.ItemsSource = films;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTextBox.Text.ToLower();
            var selectedDate = DateFilter.SelectedDate;

            var query = Core.GetContext().Films.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(f => f.Title.ToLower().Contains(searchText));
            }

            if (selectedDate.HasValue)
            {
                // TODO: Добавить фильтрацию по дате сеансов
            }

            FilmsDataGrid.ItemsSource = query.ToList();
        }

        private void FilmsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFilm = FilmsDataGrid.SelectedItem as Films;
            if (selectedFilm != null)
            {
                // TODO: Открыть детальную информацию о фильме
            }
        }
    }
} 