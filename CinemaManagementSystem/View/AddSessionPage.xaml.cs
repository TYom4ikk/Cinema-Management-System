using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.View
{
    public partial class AddSessionPage : Page
    {
        public AddSessionPage()
        {
            InitializeComponent();
            LoadFilms();
            DatePicker.SelectedDate = DateTime.Today;
        }

        private void LoadFilms()
        {
            try
            {
                FilmComboBox.ItemsSource = Core.GetContext().Films.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке фильмов: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверяем обязательные поля
                if (FilmComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите фильм!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!DatePicker.SelectedDate.HasValue)
                {
                    MessageBox.Show("Выберите дату!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TimeTextBox.Text))
                {
                    MessageBox.Show("Введите время начала!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!TimeSpan.TryParse(TimeTextBox.Text, out TimeSpan startTime))
                {
                    MessageBox.Show("Неверный формат времени! Используйте формат ЧЧ:ММ", 
                                  "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(PriceTextBox.Text) || !int.TryParse(PriceTextBox.Text, out int price))
                {
                    MessageBox.Show("Введите корректную цену билета!", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var selectedFilm = FilmComboBox.SelectedItem as Films;
                var sessionDate = DatePicker.SelectedDate.Value;
                var startDateTime = sessionDate.Add(startTime);

                // Создаем новый сеанс
                var session = new Sessions
                {
                    FilmId = selectedFilm.Id,
                    StartDateTime = startDateTime,
                    EndDateTime = startDateTime.AddMinutes(selectedFilm.Duration)
                };

                // Добавляем сеанс в базу данных
                Core.GetContext().Sessions.Add(session);
                Core.GetContext().SaveChanges();

                MessageBox.Show("Сеанс успешно добавлен!", "Информация", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении сеанса: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
} 