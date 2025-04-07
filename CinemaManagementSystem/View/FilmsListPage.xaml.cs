using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            try
            {
                var films = Core.GetContext().Films.ToList();
                FilmsDataGrid.ItemsSource = films;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке фильмов: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
                    // Ищем фильмы, у которых есть сеансы на выбранную дату
                    query = query.Where(f => f.Sessions.Any(s => s.StartDateTime.Value == selectedDate.Value.Date));
                }

                FilmsDataGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске фильмов: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilmsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Пока оставим пустым, здесь будет открытие детальной информации о фильме
        }
    }
} 