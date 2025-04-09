using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.View
{
    public partial class BookTicketPage : Page
    {
        private readonly Sessions _currentSession;

        public BookTicketPage(Sessions session)
        {
            InitializeComponent();
            _currentSession = session;
            LoadSessionInfo();
            LoadSeats();
        }

        private void LoadSessionInfo()
        {
            FilmTitleBlock.Text = _currentSession.Films.Title;
            SessionInfoBlock.Text = $"Сеанс: {_currentSession.StartDateTime:dd.MM.yyyy HH:mm}";
        }

        private void LoadSeats()
        {
            try
            {
                // Получаем все места в зале
                var seats = Core.GetContext().Seats.ToList();

                // Получаем уникальные номера рядов
                var rows = seats.Select(s => s.RowNumber).Distinct().OrderBy(r => r).ToList();
                RowComboBox.ItemsSource = rows;

                if (rows.Any())
                    RowComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке мест: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RowComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RowComboBox.SelectedItem != null)
            {
                var selectedRow = (short)RowComboBox.SelectedItem;
                var seats = Core.GetContext().Seats
                    .Where(s => s.RowNumber == selectedRow && !s.IsOccupied && !s.IsBooked)
                    .Select(s => s.SeatNumber)
                    .OrderBy(s => s)
                    .ToList();

                SeatComboBox.ItemsSource = seats;
                if (seats.Any())
                    SeatComboBox.SelectedIndex = 0;
            }
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка выбора места
                if (RowComboBox.SelectedItem == null || SeatComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите место!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка контактной информации
                if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PhoneTextBox.Text))
                {
                    MessageBox.Show("Заполните ФИО и телефон!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка цены
                if (string.IsNullOrWhiteSpace(PriceTextBox.Text) || 
                    !decimal.TryParse(PriceTextBox.Text, out decimal price))
                {
                    MessageBox.Show("Введите корректную цену!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var selectedRow = (short)RowComboBox.SelectedItem;
                var selectedSeat = (int)SeatComboBox.SelectedItem;

                // Находим выбранное место
                var seat = Core.GetContext().Seats.FirstOrDefault(s => 
                    s.RowNumber == selectedRow && s.SeatNumber == selectedSeat);

                if (seat == null)
                {
                    MessageBox.Show("Место не найдено!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Создаем новое бронирование
                var booking = new Bookings
                {
                    SessionID = _currentSession.SessionID,
                    SeatID = seat.SeatID,
                    CustomerName = NameTextBox.Text,
                    CustomerPhone = PhoneTextBox.Text,
                    CustomerEmail = EmailTextBox.Text,
                    BookingDateTime = DateTime.Now,
                    Price = price
                };

                // Помечаем место как забронированное
                seat.IsBooked = true;

                // Сохраняем изменения
                Core.GetContext().Bookings.Add(booking);
                Core.GetContext().SaveChanges();

                MessageBox.Show("Бронирование успешно создано!", "Успех", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при бронировании: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
} 
 