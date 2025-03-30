using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaManagementSystem.View;

namespace CinemaManagementSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FilmsListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new FilmsListPage());
        }

        private void AddFilmMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddFilmPage());
        }

        private void ScheduleMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Реализовать просмотр расписания
        }

        private void AddSessionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Реализовать добавление сеанса
        }

        private void SellTicketsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Реализовать продажу билетов
        }

        private void BookingMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Реализовать бронирование
        }

        private void DailyReportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Реализовать ежедневный отчет
        }

        private void StatisticsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Реализовать статистику
        }
    }
}
