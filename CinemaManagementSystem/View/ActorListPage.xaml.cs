using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;
using System.Windows.Navigation;
using CinemaManagementSystem.ViewModel;

namespace CinemaManagementSystem.View
{
    public partial class ActorListPage : Page
    {
        private MainWindow mainWindow;
        private ActorListPageViewModel model;
        public ActorListPage()
        {
            InitializeComponent();
            model = new ActorListPageViewModel();
            mainWindow = Application.Current.MainWindow as MainWindow;
            LoadCountries();
            LoadActors();
            UpdateButtonsVisibility();
        }

        /// <summary>
        /// Загружает список стран и устанавливает источник данных для фильтра.
        /// Добавляет дополнительную опцию "Все страны".
        /// </summary>
        private void LoadCountries()
        {
            try
            {
                var countries = model.GetCountries();
                countries.Insert(0, new Countries { Id = 0, Name = "Все страны" });
                CountryFilter.ItemsSource = countries;
                CountryFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка стран: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Загружает и фильтрует список актёров по стране и строке поиска.
        /// </summary>
        private void LoadActors()
        {
            try
            {
                var actors = model.GetActors();

                // Фильтрация по стране
                if (CountryFilter.SelectedItem is Countries selectedCountry && selectedCountry.Id != 0)
                {
                    actors = actors.Where(a => a.CountryId == selectedCountry.Id).ToList();
                }

                // Фильтрация по поиску
                string searchText = SearchTextBox.Text.ToLower();
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    actors = actors.Where(a =>
                        a.FirstName.ToLower().Contains(searchText) ||
                        a.LastName.ToLower().Contains(searchText) ||
                        (a.MiddleName != null && a.MiddleName.ToLower().Contains(searchText))
                    ).ToList();
                }

                ActorsDataGrid.ItemsSource = actors;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки поиска. Повторно загружает актёров с учётом фильтров.
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            LoadActors();
        }
        /// <summary>
        /// Обрабатывает изменение выбранной страны. Перезагружает список актёров.
        /// </summary>
        private void CountryFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadActors();
        }

        private void ActorsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void UpdateButtonsVisibility()
        {
           
        }
        /// <summary>
        /// Обрабатывает удаление выбранного актёра после подтверждения.
        /// </summary>
        private void DeleteActorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorsDataGrid.SelectedItem is Actors selectedActor)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить актёра {selectedActor.FirstName} {selectedActor.LastName}?", 
                                           "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        model.RemoveActors(selectedActor);
                        model.SaveChanges();

                        MessageBox.Show("Актёр успешно удалён", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadActors();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении актёра: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}