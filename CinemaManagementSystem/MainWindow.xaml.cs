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
            MainFrame.Navigate(new FilmsListPage()); // Открываем список фильмов при запуске
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FilmsListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new FilmsListPage());
        }

        private void AddFilmMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddFilmPage());
        }

        private void ActorListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ActorListPage());
        }

        private void AddActorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddActorPage());
        }

        private void ScheduleMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SchedulePage());
        }

        private void AddSessionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddSessionPage());
        }

        private void SellTicketsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SchedulePage());
        }

        private void BookingMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функционал в разработке", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DailyReportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функционал в разработке", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void StatisticsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SalesStatisticsPage());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem == null) return;

            switch (menuItem.Header.ToString())
            {
                case "Фильмы":
                    MainFrame.Navigate(new FilmsListPage());
                    break;
                case "Актеры":
                    MainFrame.Navigate(new ActorListPage());
                    break;
                case "Сеансы":
                    MainFrame.Navigate(new AddSessionPage());
                    break;
                case "Расписание":
                    MainFrame.Navigate(new SchedulePage());
                    break;
                case "Статистика продаж":
                    MainFrame.Navigate(new SalesStatisticsPage());
                    break;
            }
        }
    }
}
