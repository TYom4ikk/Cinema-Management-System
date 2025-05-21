using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using CinemaManagementSystem.Model;
using CinemaManagementSystem.View;
using CinemaManagementSystem.ViewModel;

namespace CinemaManagementSystem.View
{
    public partial class SchedulePage : Page
    {
        private SchedulePageViewModel model;
        public SchedulePage()
        {
            InitializeComponent();
            model = new SchedulePageViewModel();
            DateFilter.SelectedDate = DateTime.Today;
            LoadSessions();
        }

        /// <summary>
        /// Загружает все сеансы из базы данных и отображает их в таблице.
        /// </summary>
        /// <remarks>
        /// При возникновении ошибки выводится сообщение с описанием.
        /// </remarks>
        private void LoadSessions()
        {
            try
            {
                var sessions = model.GetSessions();

                SessionsDataGrid.ItemsSource = sessions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сеансов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки фильтрации сеансов по дате.
        /// </summary>
        /// <param name="sender">Источник события — кнопка "Показать".</param>
        /// <param name="e">Аргументы события нажатия.</param>
        /// <remarks>
        /// Если дата выбрана, загружаются только сеансы на эту дату. В случае ошибки отображается сообщение.
        /// </remarks>
        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateFilter.SelectedDate.HasValue)
            {
                try
                {
                    var sessions = model.GetSessionsDateFilter(DateFilter.SelectedDate.Value.Date);

                    SessionsDataGrid.ItemsSource = sessions;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при фильтрации сеансов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Сбрасывает фильтр по дате и загружает все сеансы.
        /// </summary>
        /// <param name="sender">Источник события — кнопка "Сброс".</param>
        /// <param name="e">Аргументы события нажатия.</param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            DateFilter.SelectedDate = null;
            LoadSessions();
        }

        /// <summary>
        /// Обрабатывает выбор сеанса в таблице и переходит на страницу покупки билета для выбранного сеанса.
        /// </summary>
        /// <param name="sender">Источник события — таблица с сеансами.</param>
        /// <param name="e">Аргументы изменения выбора.</param>
        private void SessionsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SessionsDataGrid.SelectedItem is Sessions selectedSession)
            {
                NavigationService.Navigate(new BuyTicketPage(selectedSession));
            }
        }

      
    }
} 