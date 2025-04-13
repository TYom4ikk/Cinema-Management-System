using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.View
{
    public partial class SellTicketPage : Page
    {
        private readonly Sessions _currentSession;

        public SellTicketPage(Sessions session)
        {
            InitializeComponent();
            _currentSession = session;
            LoadSessionInfo();
            LoadSeats();
        }

        private void LoadSessionInfo()
        {
            FilmTitleBlock.Text = _currentSession.Films.Title;
            SessionInfoBlock.Text = $"�����: {_currentSession.StartDateTime:dd.MM.yyyy HH:mm}";
        }

        private void LoadSeats()
        {
            try
            {
                var seats = Core.GetContext().Seats.ToList();

                var rows = seats.Select(s => s.RowNumber).Distinct().OrderBy(r => r).ToList();
                RowComboBox.ItemsSource = rows;

                if (rows.Any())
                    RowComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ����: {ex.Message}", 
                              "������", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RowComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RowComboBox.SelectedItem != null)
            {
                var selectedRow = (short)RowComboBox.SelectedItem;
                var seats = Core.GetContext().Seats
                    .Where(s => s.RowNumber == selectedRow && !s.IsOccupied)
                    .Select(s => s.SeatNumber)
                    .OrderBy(s => s)
                    .ToList();

                SeatComboBox.ItemsSource = seats;
                if (seats.Any())
                    SeatComboBox.SelectedIndex = 0;
            }
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RowComboBox.SelectedItem == null || SeatComboBox.SelectedItem == null)
                {
                    MessageBox.Show("�������� �����!", "������", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(PriceTextBox.Text) || 
                    !int.TryParse(PriceTextBox.Text, out int price))
                {
                    MessageBox.Show("������� ���������� ����!", "������", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var selectedRow = (short)RowComboBox.SelectedItem;
                var selectedSeat = (int)SeatComboBox.SelectedItem;

                // ��������� �����
                var seat = Core.GetContext().Seats.FirstOrDefault(s => 
                    s.RowNumber == selectedRow && s.SeatNumber == selectedSeat);

                if (seat == null)
                {
                    MessageBox.Show("����� �� �������!", "������", 
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                var ticket = new Tickets
                {
                    Id = _currentSession.Id,
                    SeatId= seat.Id,
                    Price = price,
                };

                seat.IsOccupied = true;

                Core.GetContext().Tickets.Add(ticket);
                Core.GetContext().SaveChanges();

                MessageBox.Show("����� ������� ������!", "�����", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������� ������: {ex.Message}", 
                              "������", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
} 