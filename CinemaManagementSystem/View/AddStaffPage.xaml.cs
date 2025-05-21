using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;

namespace CinemaManagementSystem.View
{
    public partial class AddStaffPage : Page
    {
        AddStaffPageViewModel model;
        public AddStaffPage()
        {
            InitializeComponent();
            model = new AddStaffPageViewModel();
            LoadPositions();
        }
        /// <summary>
        /// Загружает список должностей и устанавливает их в выпадающий список.
        /// </summary>
        private void LoadPositions()
        {
            try
            {
                PositionComboBox.ItemsSource = model.GetPosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке должностей: {ex.Message}", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки добавления нового сотрудника.
        /// Выполняет валидацию, создает объект Workers и сохраняет его в базу данных.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    var newWorker = new Workers
                    {
                        // id 0???
                        LastName = LastNameTextBox.Text,
                        FirstName = FirstNameTextBox.Text,
                        MiddleName = MiddleNameTextBox.Text,
                        BirthDate = BirthDatePicker.SelectedDate.Value,
                        Gender = ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString(),

                        PostId = ((Posts)PositionComboBox.SelectedItem).Id,
                       
                        
                        Address = AddressTextBox.Text,
                        PhoneNumber = PhoneTextBox.Text,
                        Salary = decimal.Parse(SalaryTextBox.Text),
                        Responsibilities = ResponsibilitiesTextBox.Text,
                        Requirements = RequirementsTextBox.Text,
                        Email = EmailTextBox.Text,
                        Password = PasswordBox.Password,
                        PassportData = PassportData.Text
                    };

                    model.AddWorker(newWorker);
                    model.SaveChanges();

                    MessageBox.Show("Сотрудник успешно добавлен!", 
                        "Успех", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Information);

                    NavigationService.GoBack();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Выполняет валидацию введённых пользователем данных при добавлении сотрудника.
        /// Показывает предупреждения при обнаружении ошибок.
        /// </summary>
        /// <returns>True — если все данные корректны; False — при наличии ошибок.</returns>
        public bool ValidateInput()
        {
            if (model.IsLastNameEmpty(LastNameTextBox.Text))
            {
                return false;
            }

            if (model.IsFirstNameEmpty(FirstNameTextBox.Text))
            {
                return false;
            }

            if (PositionComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите должность", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return false;
            }

            if (BirthDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату рождения", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return false;
            }

            if (GenderComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите пол", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                MessageBox.Show("Введите телефон", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return false;
            }

            if (!decimal.TryParse(SalaryTextBox.Text, out decimal salary) || salary <= 0)
            {
                MessageBox.Show("Введите корректный оклад", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Введите email", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль", 
                    "Ошибка", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки отмены. Возвращает пользователя на предыдущую страницу.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
} 