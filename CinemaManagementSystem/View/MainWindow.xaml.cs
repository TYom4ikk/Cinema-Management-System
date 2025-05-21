using System.Windows;
using System.Windows.Controls;

namespace CinemaManagementSystem.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                case "Актёры":
                    MainFrame.Navigate(new ActorListPage());
                    break;
                case "Сеансы":
                    MainFrame.Navigate(new SessionListPage());
                    break;
                case "Сотрудники":
                    MainFrame.Navigate(new StaffListPage());
                    break;
            }
        }
    }
} 