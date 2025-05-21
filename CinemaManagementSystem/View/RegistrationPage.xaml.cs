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
using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;

namespace CinemaManagementSystem.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        const byte ADMIN_ID = 4;
        RegistrationPageViewModel model;
        MainWindow parentWindow;
        public RegistrationPage(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
            model = new RegistrationPageViewModel();
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки входа в систему.
        /// </summary>
        /// <param name="sender">Источник события — кнопка входа.</param>
        /// <param name="e">Аргументы события нажатия.</param>
        /// <remarks>
        /// Проверяет заполненность полей логина и пароля, выполняет проверку пользователя в базе.
        /// Если пользователь найден и является администратором, устанавливает соответствующие права и переходит к списку фильмов.
        /// В случае ошибки отображает сообщение.
        /// </remarks>
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(LoginTextBox.Text) && !string.IsNullOrEmpty(PasswordPasswordBox.Password))
                {
                    var worker = model.GetWorker(LoginTextBox.Text, PasswordPasswordBox.Password);
                    if (worker != null && worker.PostId == ADMIN_ID)
                    {

                        parentWindow.isAdmin = true;

                        MessageBox.Show($"Вы вошли в систему как \"{worker.Posts.Name}\"", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        parentWindow.CheckUserAccess();
                        this.NavigationService.Navigate(new FilmsListPage());
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!", "Ошибка при входе", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    throw new Exception("Заполните все поля!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при входе", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
