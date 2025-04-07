using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.View
{
    public partial class SalesStatisticsPage : Page
    {
        public SalesStatisticsPage()
        {
            InitializeComponent();
            LoadDefaultDates();
            LoadStatistics();
        }

        private void LoadDefaultDates()
        {
            // Устанавливаем период за последний месяц
            EndDatePicker.SelectedDate = DateTime.Today;
            StartDatePicker.SelectedDate = DateTime.Today.AddMonths(-1);
        }

        private void LoadStatistics()
        {
            try
            {
                var startDate = StartDatePicker.SelectedDate ?? DateTime.Today.AddMonths(-1);
                var endDate = EndDatePicker.SelectedDate ?? DateTime.Today;

                var context = Core.GetContext();

                // Получаем все билеты за выбранный период
                List<Tickets>tickets = context.Tickets
                    .Where(t => t.SaleDateTime >= startDate && t.SaleDateTime <= endDate)
                    .ToList();

                // Общая статистика
                var totalTickets = tickets.Count();
                var totalRevenue = tickets.Sum(t => t.Price);
                var averagePrice = totalTickets > 0 ? totalRevenue / totalTickets : 0;

                TotalTicketsBlock.Text = totalTickets.ToString();
                TotalRevenueBlock.Text = $"{totalRevenue} руб.";
                AveragePriceBlock.Text = $"{averagePrice} руб.";

                // Статистика по фильмам
                var filmsStats = tickets
                    .GroupBy(t => t.Sessions.Films.Title)
                    .Select(g => new
                    {
                        FilmTitle = g.Key,
                        TicketsSold = g.Count(),
                        Revenue = g.Sum(t => t.Price)
                    })
                    .OrderByDescending(f => f.Revenue)
                    .ToList();

                FilmsStatisticsListView.ItemsSource = filmsStats;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке статистики: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate == null || EndDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите период!", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (StartDatePicker.SelectedDate > EndDatePicker.SelectedDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания!", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            LoadStatistics();
        }
    }
} 
 