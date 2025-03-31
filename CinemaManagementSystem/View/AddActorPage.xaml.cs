using System;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.View
{
    public partial class AddActorPage : Page
    {
        private Actors _actor;

        public AddActorPage()
        {
            InitializeComponent();
            _actor = new Actors();
            DataContext = _actor;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    // Создаем нового актера
                    var newActor = new Actors
                    {
                        FirstName = _actor.FirstName,
                        LastName = _actor.LastName,
                        MiddleName = _actor.MiddleName,
                        BirthDate = _actor.BirthDate
                    };

                    // Сохраняем в базу данных
                    Core.GetContext().Actors.Add(newActor);
                    Core.GetContext().SaveChanges();

                    MessageBox.Show("Актер успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new FilmsListPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_actor.FirstName))
            {
                MessageBox.Show("Введите имя актера", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(_actor.LastName))
            {
                MessageBox.Show("Введите фамилию актера", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (_actor.BirthDate == null || _actor.BirthDate > DateTime.Now)
            {
                MessageBox.Show("Введите корректную дату рождения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FilmsListPage());
        }
    }
} 