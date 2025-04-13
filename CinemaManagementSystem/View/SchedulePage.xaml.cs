using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;
using CinemaManagementSystem.View;

namespace CinemaManagementSystem.View
{
    public partial class SchedulePage : Page
    {
        private readonly bool _isBookingMode;

        public SchedulePage(bool isBookingMode = false)
        {
            InitializeComponent();
            _isBookingMode = isBookingMode;
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

        private void SessionsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SessionsDataGrid.SelectedItem is Sessions selectedSession)
            {
               /* if (_isBookingMode)
                    NavigationService.Navigate(new BookTicketPage(selectedSession));*/
               
                    NavigationService.Navigate(new SellTicketPage(selectedSession));
            }
        }

        private void SellTicketButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
} 