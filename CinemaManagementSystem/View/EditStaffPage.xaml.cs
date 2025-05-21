using CinemaManagementSystem.Model;
using CinemaManagementSystem.ViewModel;
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

namespace CinemaManagementSystem.View
{
    /// <summary>
    /// Логика взаимодействия для EditStaffPage.xaml
    /// </summary>
    public partial class EditStaffPage : Page
    {
        private EditStaffPageViewModel model;
        private Workers _currentWorker;
        private List<Workers> WorkersList;
        private List<Posts> PositionsList;

        public EditStaffPage()
        {
            InitializeComponent();
            model = new EditStaffPageViewModel();

            WorkersList = model.GetWorkers();
            PositionsList = model.GetPosts();

            StaffComboBox.ItemsSource = WorkersList;
            StaffComboBox.DisplayMemberPath = "FullName";
            PositionComboBox.ItemsSource = PositionsList;
            GenderComboBox.ItemsSource = new[] { "М", "Ж" };

            if (WorkersList.Any())
                StaffComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Загружает данные выбранного сотрудника в элементы управления.
        /// </summary>
        /// <param name="worker">Объект сотрудника.</param>
        private void LoadData(Workers worker)
        {
            _currentWorker = worker;
            DataContext = _currentWorker;

            FirstNameTextBox.Text = worker.FirstName;
            LastNameTextBox.Text = worker.LastName;
            MiddleNameTextBox.Text = worker.MiddleName;
            PhoneNumberTextBox.Text = worker.PhoneNumber;
            AddressTextBox.Text = worker.Address;
            BirthDatePicker.SelectedDate = worker.BirthDate;
            GenderComboBox.SelectedItem = worker.Gender;
            PositionComboBox.SelectedItem = worker.Posts;
            SalaryTextBox.Text = worker.Salary.ToString();
            ResponsibilitiesTextBox.Text = worker.Responsibilities;
            RequirementsTextBox.Text = worker.Requirements;
            EmailTextBox.Text = worker.Email;
            PasswordBox.Password = worker.Password;
        }
        /// <summary>
        /// Обрабатывает изменение выбранного сотрудника в ComboBox.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события выбора.</param>
        private void StaffComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StaffComboBox.SelectedItem is Workers selected)
                LoadData(selected);
        }
        /// <summary>
        /// Сохраняет изменения данных сотрудника.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentWorker.FirstName = FirstNameTextBox.Text;
                _currentWorker.LastName = LastNameTextBox.Text;
                _currentWorker.MiddleName = MiddleNameTextBox.Text;
                _currentWorker.PhoneNumber = PhoneNumberTextBox.Text;
                _currentWorker.Address = AddressTextBox.Text;
                _currentWorker.BirthDate = BirthDatePicker.SelectedDate ?? DateTime.Now;
                _currentWorker.Gender = GenderComboBox.SelectedItem?.ToString();
                _currentWorker.PostId = ((Posts)PositionComboBox.SelectedValue).Id;
                _currentWorker.Salary = decimal.TryParse(SalaryTextBox.Text, out decimal salary) ? salary : 0;
                _currentWorker.Responsibilities = ResponsibilitiesTextBox.Text;
                _currentWorker.Requirements = RequirementsTextBox.Text;
                _currentWorker.Email = EmailTextBox.Text;
                _currentWorker.Password = PasswordBox.Password;

                model.SaveChanges();
                MessageBox.Show("Данные сотрудника успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Удаляет выбранного сотрудника после подтверждения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить этого сотрудника?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                model.RemoveWorkers(_currentWorker);
                model.SaveChanges();
                MessageBox.Show("Сотрудник удален.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.GoBack();
            }
        }
        /// <summary>
        /// Отменяет редактирование и возвращается на предыдущую страницу.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
