using CinemaManagementSystem.Classes;
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
    /// Логика взаимодействия для DailyReportPage.xaml
    /// </summary>
    public partial class DailyReportPage : Page
    {
        private DailyReportPageViewModel model;
        public DailyReportPage()
        {
            InitializeComponent();
            model = new DailyReportPageViewModel();
            ReportDatePicker.SelectedDate = DateTime.Today;
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку печати отчёта в Word.
        /// Генерирует отчёт по проданным билетам за выбранную дату.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void PrintWordReport_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = ReportDatePicker.SelectedDate ?? DateTime.Today;

            GenerateReportWord(selectedDate);
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку печати отчёта в Excel.
        /// Генерирует отчёт по проданным билетам за выбранную дату.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void PrintExcelReport_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = ReportDatePicker.SelectedDate ?? DateTime.Today;

            GenerateReportExcel(selectedDate);
        }
        /// <summary>
        /// Генерирует и экспортирует отчёт по проданным билетам в формате Excel за указанную дату.
        /// </summary>
        /// <param name="date">Дата, за которую нужно сформировать отчёт.</param>
        private void GenerateReportExcel(DateTime date)
        {
            var report = new DailyReport();
            var tickets = model.GetTicketsBySaleDateTime(date);

            report.ExportTicketToExcel(tickets, date);
        }
        /// <summary>
        /// Генерирует и экспортирует отчёт по проданным билетам в формате Word за указанную дату.
        /// </summary>
        /// <param name="date">Дата, за которую нужно сформировать отчёт.</param>
        private void GenerateReportWord(DateTime date)
        {
            var report = new DailyReport();
            var tickets = model.GetTicketsBySaleDateTime(date);

            report.ExportTicketToWord(tickets, date);
        }
    }
}
