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
using System.Windows.Shapes;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для FullFilmInfoWindow.xaml
    /// </summary>
    public partial class FullFilmInfoWindow : Window
    {
        Films currentFilm;
        public FullFilmInfoWindow(Films film)
        {
            InitializeComponent();
            currentFilm = film;
            DataContext = currentFilm;
            this.Title = $"{currentFilm.Title}";
        }
    }
}
