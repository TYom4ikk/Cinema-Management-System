using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;

namespace CinemaManagementSystem.View
{
    public partial class StaffListPage : Page
    {
        private StaffListPageViewModel model; 
        public StaffListPage()
        {
            InitializeComponent();
            model = new StaffListPageViewModel();
            LoadStaff();
        }

        /// <summary>
        /// Загружает список всех сотрудников из базы данных и отображает его в таблице.
        /// </summary>
        /// <remarks>
        /// В случае ошибки при получении данных из базы выводится сообщение об ошибке.
        /// </remarks>
        private void LoadStaff()
        {
            try
            {
                var staff = model.GetWorkers();

                StaffDataGrid.ItemsSource = staff;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка сотрудников: {ex.Message}", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска. Выполняет фильтрацию списка сотрудников по введенному тексту.
        /// </summary>
        /// <param name="sender">Источник события — кнопка поиска.</param>
        /// <param name="e">Аргументы события нажатия.</param>
        /// <remarks>
        /// В случае ошибки при поиске выводится сообщение об ошибке.
        /// </remarks>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchText = SearchTextBox.Text.ToLower();
                var staff =

                StaffDataGrid.ItemsSource = model.GetWorkersByText(searchText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске сотрудников: {ex.Message}", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }
    }
} 