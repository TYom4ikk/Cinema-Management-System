using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;

namespace CinemaManagementSystem.View
{
    public partial class SalesStatisticsPage : Page
    {
        private SalesStatisticsPageViewModel model;
        public SalesStatisticsPage()
        {
            InitializeComponent();
            model = new SalesStatisticsPageViewModel();
            LoadDefaultDates();
            LoadStatistics();
        }

        /// <summary>
        /// Устанавливает значения по умолчанию для элементов выбора даты начала и конца периода.
        /// </summary>
        private void LoadDefaultDates()
        {
            EndDatePicker.SelectedDate = DateTime.Today;
            StartDatePicker.SelectedDate = DateTime.Today.AddMonths(-1);
        }
        /// <summary>
        /// Загружает и отображает статистику по проданным билетам за выбранный период.
        /// </summary>
        /// <remarks>
        /// Выполняется подсчет общего количества билетов, общей выручки и средней цены билета.
        /// Также формируется список статистики по фильмам и данные для построения диаграммы.
        /// При возникновении ошибки отображается сообщение.
        /// </remarks>
        private void LoadStatistics()
        {
            try
            {
                var startDate = StartDatePicker.SelectedDate ?? DateTime.Today.AddMonths(-1);
                var endDate = EndDatePicker.SelectedDate ?? DateTime.Today;

                List<Tickets> tickets = model.GetTicketsInDateRange(startDate, endDate);

                var totalTickets = tickets.Count();
                var totalRevenue = tickets.Sum(t => t.Price);
                var averagePrice = totalTickets > 0 ? totalRevenue / totalTickets : 0;

                TotalTicketsBlock.Text = totalTickets.ToString();
                TotalRevenueBlock.Text = $"{totalRevenue} руб.";
                AveragePriceBlock.Text = $"{averagePrice} руб.";

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


                var maxRevenue = filmsStats.Max(f => f.Revenue);

                var chartData = filmsStats.Select(f => new
                {
                    f.FilmTitle,
                    f.Revenue,
                    BarHeight = maxRevenue > 0 ? (f.Revenue / maxRevenue) * 200 : 0 // 200 – масштаб
                }).ToList();

                BarChart.ItemsSource = chartData;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке статистики: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки применения фильтра по дате.
        /// </summary>
        /// <param name="sender">Источник события — кнопка применения фильтра.</param>
        /// <param name="e">Аргументы события нажатия.</param>
        /// <remarks>
        /// Проверяет корректность выбранных дат и вызывает метод загрузки статистики.
        /// В случае некорректного ввода отображаются предупреждающие сообщения.
        /// </remarks>
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
 