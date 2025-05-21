using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;

namespace CinemaManagementSystem.View
{
    public partial class AddSessionPage : Page
    {
        private List<Halls> HallsList = new List<Halls>();
        private AddSessionPageViewModel model;
        public AddSessionPage()
        {
            InitializeComponent();
            model = new AddSessionPageViewModel();
            LoadFilms();
            DatePicker.SelectedDate = DateTime.Today;

            HallsList = model.GetHalls();
            foreach (var hall in HallsList)
            {
                
            }
        }
        /// <summary>
        /// Загружает список фильмов в комбобокс на странице добавления сеанса.
        /// </summary>
        /// <remarks>
        /// Загружает данные из модели и устанавливает их как источник для выпадающего списка.
        /// </remarks>
        private void LoadFilms()
        {
            try
            {
                FilmComboBox.ItemsSource = model.GetFilms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке фильмов: {ex.Message}", 
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Сохраняет новый сеанс в базу данных.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события нажатия кнопки.</param>
        /// <remarks>
        /// Выполняет валидацию данных формы, создает объект сеанса и сохраняет его через модель.
        /// </remarks>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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

                if (string.IsNullOrWhiteSpace(PriceTextBox.Text) || !decimal.TryParse(PriceTextBox.Text, out decimal rubPrice))
                {
                    MessageBox.Show("Введите корректную цену билета (например, 450,00)!",
                                  "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Перевод в копейки
                int price = (int)Math.Round(rubPrice * 100, MidpointRounding.AwayFromZero);

                var selectedFilm = FilmComboBox.SelectedItem as Films;
                var sessionDate = DatePicker.SelectedDate.Value;
                var startDateTime = sessionDate.Add(startTime);

                var session = new Sessions
                {
                    FilmId = selectedFilm.Id,
                    StartDateTime = startDateTime,
                    EndDateTime = startDateTime.AddMinutes(selectedFilm.Duration)
                };

                model.AddSession(session);
                model.SaveChanges();

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
        /// <summary>
        /// Отменяет добавление сеанса и возвращает пользователя на предыдущую страницу.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события нажатия кнопки.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
        /// <summary>
        /// Ограничивает ввод в поле цены допустимыми символами (числа и запятая).
        /// </summary>
        /// <param name="sender">Текстовое поле, в котором производится ввод.</param>
        /// <param name="e">Аргументы текстового ввода.</param>
        /// <remarks>
        /// Предотвращает ввод недопустимых символов и ограничивает формат до двух знаков после запятой.
        /// </remarks>
        private void PriceTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex _regex = new Regex(@"^\d*\,?\d{0,2}$");
            TextBox textBox = sender as TextBox;

            // Текущий текст + вводимый символ
            string fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
            e.Handled = !_regex.IsMatch(fullText);
        }
    }
} 