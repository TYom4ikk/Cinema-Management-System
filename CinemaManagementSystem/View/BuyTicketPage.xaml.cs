using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CinemaManagementSystem.Classes;
using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;
using Microsoft.Office.Interop.Word;

namespace CinemaManagementSystem.View
{
    public partial class BuyTicketPage : System.Windows.Controls.Page
    {
        private readonly Sessions _session;
        private readonly Cinema_DBEntities _context;
        public event EventHandler<Tickets> TicketPurchased;
        private Seats _selectedSeat;
        private BuyTicketPageViewModel model;
        public BuyTicketPage(Sessions session)
        {
            InitializeComponent();
            _session = session;
            _context = model.GetContext();
            DataContext = new HallViewModel(session.Halls);

            FilmTitle = _session.Films.Title;
            SessionDateTime = _session.StartDateTime?.ToString("dd.MM.yyyy HH:mm");
            HallName = _session.Halls.Name;
            Price = $"{_session.Price:C}";

            var availableSeats = model.GetSeatsByHallId(_session.Halls.Id);
        }

        public string FilmTitle { get; set; }
        public string SessionDateTime { get; set; }
        public string HallName { get; set; }
        public string Price { get; set; }
        public int? SelectedSeatId { get; set; }

        /// <summary>
        /// Обработчик нажатия на кнопку "Купить билет".
        /// Проверяет выбор места, создает билет, помечает место как занятое, сохраняет данные и предлагает экспорт.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BuyTicketButton_Click(object sender, RoutedEventArgs e)
        {

            if (!SelectedSeatId.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите место", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var seat = _context.Seats.Find(SelectedSeatId.Value);
                if (seat == null || seat.IsOccupied)
                {
                    MessageBox.Show("Выбранное место уже занято", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var ticket = new Tickets
                {
                    SessionId = _session.Id,
                    Price = _session.Price,
                    SaleDateTime = DateTime.Now,
                    SeatId = SelectedSeatId.Value
                };
                seat.IsOccupied = true;

                _context.Tickets.Add(ticket);
                _context.SaveChanges();

                TicketPurchased?.Invoke(this, ticket);

                MessageBox.Show("Билет успешно куплен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                Classes.TicketExporter ticketExporter = new Classes.TicketExporter();

                var format = ExportDialog.AskExportFormat();
                switch (format)
                {
                    case ExportFormat.Excel:
                        ticketExporter.ExportTicketToExcel(ticket);
                        break;
                    case ExportFormat.Word:
                        ticketExporter.ExportTicketToWord(ticket);
                        break;
                    case ExportFormat.Cancel:
                        MessageBox.Show("Экспорт отменён пользователем.", "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }

                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Ошибка при покупке билета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Рекурсивно находит все визуальные дочерние элементы заданного типа.
        /// Используется для поиска всех кнопок мест на форме.
        /// </summary>
        /// <typeparam name="T">Тип визуального элемента (например, Button).</typeparam>
        /// <param name="depObj">Родительский элемент, откуда начинается поиск.</param>
        /// <returns>Перечисление всех найденных элементов типа T.</returns>
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
                    if (child is T t)
                        yield return t;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку выбора места.
        /// Устанавливает выбранное место и обновляет визуальное отображение статуса всех мест.
        /// </summary>
        /// <param name="sender">Источник события (кнопка места).</param>
        /// <param name="e">Аргументы события.</param>
        private void SeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Seats seat)
            {
                if (seat.IsOccupied)
                    return;

                _selectedSeat = seat;
                SelectedSeatId = seat.Id;

                // Обновить визуальное выделение
                foreach (var child in FindVisualChildren<Button>(this))
                {
                    if (child.Tag is Seats s)
                    {
                        child.Background = s.IsOccupied ? Brushes.Red :
                            s.Id == SelectedSeatId ? Brushes.DodgerBlue : Brushes.LightGreen;
                    }
                }
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку "Отмена".
        /// Возвращает пользователя на предыдущую страницу.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        /// <summary>
        /// Обработчик нажатия на кнопку "Забронировать билет".
        /// Проверяет выбор места, создает бронь, помечает место как занятое, сохраняет данные и предлагает экспорт.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BookTicketButton_Click(object sender, RoutedEventArgs e)
        {

            if (!SelectedSeatId.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите место", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var seat = _context.Seats.Find(SelectedSeatId.Value);
                if (seat == null || seat.IsOccupied)
                {
                    MessageBox.Show("Выбранное место уже занято", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var booking = new Bookings
                {
                    ExpiresDateTime = DateTime.Now.AddDays(1),
                    SessionId = _session.Id,
                    SaleDateTime = DateTime.Now,
                    SeatId = SelectedSeatId.Value
                };

                seat.IsOccupied = true;

                _context.Bookings.Add(booking);
                _context.SaveChanges();

                Classes.TicketExporter ticketExporter = new Classes.TicketExporter();

                var format = ExportDialog.AskExportFormat();
                switch (format)
                {
                    case ExportFormat.Excel:
                        ticketExporter.ExportBookingToExcel(booking);
                        break;
                    case ExportFormat.Word:
                        ticketExporter.ExportBookingToWord(booking);
                        break;
                    case ExportFormat.Cancel:
                        MessageBox.Show("Экспорт отменён пользователем.", "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }



                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Ошибка при покупке билета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
    }
} 