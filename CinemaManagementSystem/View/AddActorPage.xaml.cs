using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;

namespace CinemaManagementSystem.View
{
    public partial class AddActorPage : Page
    {
        AddActorPageViewModel model;
        public AddActorPage()
        {
            InitializeComponent();
            model = new AddActorPageViewModel();
            LoadCountries();
        }
        /// <summary>
        /// Загружает список стран для ComboBox на форме добавления актёра.
        /// </summary>
        private void LoadCountries()
        {
            try
            {
                var countries = model.GetCountries();
                CountryComboBox.ItemsSource = countries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка стран: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки добавления нового актёра.
        /// Проверяет обязательные поля и сохраняет нового актёра в базу данных.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка заполнения обязательных полей
                if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || string.IsNullOrWhiteSpace(LastNameTextBox.Text))
                {
                    MessageBox.Show("Имя и фамилия являются обязательными полями", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (BirthDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Дата рождения является обязательным полем", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (CountryComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Страна является обязательным полем", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Создание нового актёра
                var newActor = new Actors
                {
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    MiddleName = MiddleNameTextBox.Text,
                    BirthDate = BirthDatePicker.SelectedDate.Value,
                    CountryId = (CountryComboBox.SelectedItem as Countries).Id
                };

                model.AddActors(newActor);
                model.SaveChanges();

                MessageBox.Show("Актёр успешно добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                
                // Возврат на страницу списка актёров
                NavigationService.Navigate(new ActorListPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении актёра: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки "Отмена" на форме добавления актёра.
        /// Возвращает пользователя на страницу списка актёров.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActorListPage());
        }
    }
} 