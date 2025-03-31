using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.View
{
    public partial class ActorsListPage : Page
    {
        public ActorsListPage()
        {
            InitializeComponent();
            LoadActors();
        }

        private void LoadActors()
        {
            try
            {
                ActorsDataGrid.ItemsSource = Core.GetContext().Actors.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadActors();
                return;
            }

            try
            {
                var query = Core.GetContext().Actors.AsQueryable();
                query = query.Where(a => 
                    a.FirstName.ToLower().Contains(searchText) || 
                    a.LastName.ToLower().Contains(searchText) ||
                    (a.MiddleName != null && a.MiddleName.ToLower().Contains(searchText))
                );
                ActorsDataGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddActorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddActorPage());
        }

        private void ActorsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ActorsDataGrid.SelectedItem is Actors selectedActor)
            {
                // Здесь можно добавить логику для редактирования актера
                // Например, открыть страницу редактирования
            }
        }
    }
} 