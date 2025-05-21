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
using System.ComponentModel;

namespace CinemaManagementSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isAdmin;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            isAdmin = false;
            CheckUserAccess();
            MainFrame.Navigate(new FilmsListPage());
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
            //MainFrame.Navigate(new AddSessionPage()); // Отменено из-за ненадобности
        }

        private void DailyReportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DailyReportPage());
        }

        private void StatisticsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SalesStatisticsPage());
        }

        private void AddStaffMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddStaffPage());
        }

        private void StaffListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StaffListPage());
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

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (!isAdmin)
            {
                MainFrame.Navigate(new RegistrationPage(this));
            }
            else
            {
                isAdmin = false;
            }
            CheckUserAccess();
        }

        public void CheckUserAccess()
        {
            SignInAndSignOut.Header = isAdmin ? "Выйти" : "Войти как администратор";

            AddFilmMenuItem.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            AddActorMenuItem.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            EditFilmMenuItem.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            
            foreach (MenuItem menuItem in MainMenu.Items)
            {
                if (menuItem.Header.ToString() == "Отчеты")
                {
                    menuItem.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
                    break;
                }
            }
            foreach (MenuItem menuItem in MainMenu.Items)
            {
                if (menuItem.Header.ToString() == "Сотрудники")
                {
                    menuItem.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
                    break;
                }
            }
        }

        private void EditFilmMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EditFilmPage());
        }

        private void EditStaffMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EditStaffPage());
        }
    }
}
