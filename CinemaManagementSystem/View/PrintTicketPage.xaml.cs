using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using CinemaManagementSystem.Model;
using System.Runtime.InteropServices;

namespace CinemaManagementSystem.View
{
    public partial class PrintTicketPage : System.Windows.Controls.Page
    {
        private Tickets _ticket;

        public PrintTicketPage(Tickets ticket)
        {
            InitializeComponent();
            _ticket = ticket;
            DataContext = this;

            // Заполняем данные для отображения
            FilmTitle = _ticket.Sessions.Films.Title;
            SessionDateTime = _ticket.Sessions.StartDateTime?.ToString("dd.MM.yyyy HH:mm");
            HallName = _ticket.Seats.Halls.Name;
            RowNumber = $"Ряд: {_ticket.Seats.RowNumber}";
            SeatNumber = $"Место: {_ticket.Seats.SeatNumber}";
            Price = $"Цена: {_ticket.Price} руб.";
            TicketNumber = $"Номер билета: {_ticket.Id}";
        }

        public string FilmTitle { get; set; }
        public string SessionDateTime { get; set; }
        public string HallName { get; set; }
        public string RowNumber { get; set; }
        public string SeatNumber { get; set; }
        public string Price { get; set; }
        public string TicketNumber { get; set; }

        private void PrintToWordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var doc = wordApp.Documents.Add();
                var range = doc.Range();

                range.Text = "Билет в кино\n\n";
                range.Text += $"Фильм: {FilmTitle}\n";
                range.Text += $"Дата и время: {SessionDateTime}\n";
                range.Text += $"Зал: {HallName}\n";
                range.Text += $"Ряд: {RowNumber}\n";
                range.Text += $"Место: {SeatNumber}\n";
                range.Text += $"Цена: {Price}\n";
                range.Text += $"Номер билета: {TicketNumber}";

                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати в Word: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PrintToExcelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = excelApp.Workbooks.Add();
                var worksheet = (Worksheet)workbook.ActiveSheet;

                worksheet.Cells[1, 1] = "Билет в кино";
                worksheet.Cells[3, 1] = "Фильм:";
                worksheet.Cells[3, 2] = FilmTitle;
                worksheet.Cells[4, 1] = "Дата и время:";
                worksheet.Cells[4, 2] = SessionDateTime;
                worksheet.Cells[5, 1] = "Зал:";
                worksheet.Cells[5, 2] = HallName;
                worksheet.Cells[6, 1] = "Ряд:";
                worksheet.Cells[6, 2] = RowNumber;
                worksheet.Cells[7, 1] = "Место:";
                worksheet.Cells[7, 2] = SeatNumber;
                worksheet.Cells[8, 1] = "Цена:";
                worksheet.Cells[8, 2] = Price;
                worksheet.Cells[9, 1] = "Номер билета:";
                worksheet.Cells[9, 2] = TicketNumber;

                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати в Excel: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 