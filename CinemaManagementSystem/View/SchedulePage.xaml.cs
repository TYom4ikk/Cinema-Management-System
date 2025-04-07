using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.View
{
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();
            DateFilter.SelectedDate = DateTime.Today;
            LoadSessions();
        }

        private void LoadSessions(DateTime? date = null)
        {
            try
            {
                var query = Core.GetContext().Sessions.AsQueryable();

                if (date.HasValue)
                {
                    query = query.Where(s => s.StartDateTime == date.Value.Date);
                }

                // Сортируем по дате и времени начала
                var sessions = query.OrderBy(s => s.StartDateTime).ToList();
                SessionsDataGrid.ItemsSource = sessions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сеансов: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            LoadSessions(DateFilter.SelectedDate);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            DateFilter.SelectedDate = DateTime.Today;
            LoadSessions(DateFilter.SelectedDate);
        }

        private void SellTicketButton_Click(object sender, RoutedEventArgs e)
        {
            var session = (sender as Button)?.DataContext as Sessions;
            if (session != null)
            {
                // Переходим на страницу продажи билетов для выбранного сеанса
                NavigationService?.Navigate(new SellTicketPage(session));
            }
        }
    }
} 