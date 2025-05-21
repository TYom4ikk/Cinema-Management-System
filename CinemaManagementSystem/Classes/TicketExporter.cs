using System;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.Classes
{
    internal class TicketExporter
    {
        // ===== EXCEL =====
        /// <summary>
        /// Экспортирует информацию о купленном билете в файл Excel.
        /// </summary>
        /// <param name="ticket">Объект билета для экспорта.</param>
        public void ExportTicketToExcel(Tickets ticket)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application { Visible = false };
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Worksheet)workbook.Sheets[1];

            worksheet.Cells[1, 1].Value = "Информация о купленном билете";
            worksheet.Cells[2, 1].Value = "Номер билета:";
            worksheet.Cells[2, 2].Value = ticket.Id;

            worksheet.Cells[3, 1].Value = "Фильм:";
            worksheet.Cells[3, 2].Value = ticket.Sessions.Films.Title;

            worksheet.Cells[4, 1].Value = "Дата и время:";
            worksheet.Cells[4, 2].Value = ticket.Sessions.StartDateTime.Value.ToString("dd.MM.yy");

            worksheet.Cells[5, 1].Value = "Место:";
            worksheet.Cells[5, 2].Value = $"Ряд {ticket.Seats.RowNumber}, Место {ticket.Seats.SeatNumber}";

            worksheet.Cells[6, 1].Value = "Цена:";
            worksheet.Cells[6, 2].Value = $"{ticket.Price} руб.";

            worksheet.Columns.AutoFit();

            SaveAndOpenExcel(workbook, excelApp, $"Ticket_{ticket.Id}");
        }
        /// <summary>
        /// Экспортирует информацию о брони в файл Excel.
        /// </summary>
        /// <param name="booking">Объект брони для экспорта.</param>
        public void ExportBookingToExcel(Bookings booking)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application { Visible = false };
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Worksheet)workbook.Sheets[1];

            worksheet.Cells[1, 1].Value = "Информация о брони";
            worksheet.Cells[2, 1].Value = "Номер брони:";
            worksheet.Cells[2, 2].Value = booking.Id;

            worksheet.Cells[3, 1].Value = "Фильм:";
            worksheet.Cells[3, 2].Value = booking.Sessions.Films.Title;

            worksheet.Cells[4, 1].Value = "Дата и время:";
            worksheet.Cells[4, 2].Value = booking.Sessions.StartDateTime.Value.ToString("dd.MM.yy");

            worksheet.Cells[5, 1].Value = "Место:";
            worksheet.Cells[5, 2].Value = $"Ряд {booking.Seats.RowNumber}, Место {booking.Seats.SeatNumber}";

            worksheet.Cells[6, 1].Value = "Бронь до:";
            worksheet.Cells[6, 2].Value = booking.ExpiresDateTime.ToString("HH:mm dd.MM.yy");

            worksheet.Columns.AutoFit();

            SaveAndOpenExcel(workbook, excelApp, $"Booking_{booking.Id}");
        }

        /// <summary>
        /// Сохраняет и открывает Excel-файл.
        /// </summary>
        /// <param name="workbook">Рабочая книга Excel.</param>
        /// <param name="app">Экземпляр Excel-приложения.</param>
        /// <param name="baseFileName">Базовое имя файла для сохранения.</param>
        private void SaveAndOpenExcel(Workbook workbook, Microsoft.Office.Interop.Excel.Application app, string baseFileName)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"{baseFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (dialog.ShowDialog() == true)
            {
                workbook.SaveAs(dialog.FileName);
                Process.Start(new ProcessStartInfo(dialog.FileName) { UseShellExecute = true });
            }

            workbook.Close(false);
            app.Quit();
        }

        // ===== WORD =====

        /// <summary>
        /// Экспортирует информацию о купленном билете в документ Word.
        /// </summary>
        /// <param name="ticket">Объект билета для экспорта.</param>
        public void ExportTicketToWord(Tickets ticket)
        {
            var wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
            var doc = wordApp.Documents.Add();

            var para = doc.Paragraphs.Add();
            para.Range.Text = "Информация о купленном билете\n\n";
            para.Range.InsertAfter($"Номер билета: {ticket.Id}\n");
            para.Range.InsertAfter($"Фильм: {ticket.Sessions.Films.Title}\n");
            para.Range.InsertAfter($"Дата и время: {ticket.Sessions.StartDateTime.Value:g}\n");
            para.Range.InsertAfter($"Место: Ряд {ticket.Seats.RowNumber}, Место {ticket.Seats.SeatNumber}\n");
            para.Range.InsertAfter($"Цена: {ticket.Price} руб.\n");

            SaveAndOpenWord(doc, wordApp, $"Ticket_{ticket.Id}");
        }
        /// <summary>
        /// Экспортирует информацию о брони в документ Word.
        /// </summary>
        /// <param name="booking">Объект брони для экспорта.</param>
        public void ExportBookingToWord(Bookings booking)
        {
            var wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
            var doc = wordApp.Documents.Add();

            var para = doc.Paragraphs.Add();
            para.Range.Text = "Информация о брони\n\n";
            para.Range.InsertAfter($"Номер брони: {booking.Id}\n");
            para.Range.InsertAfter($"Фильм: {booking.Sessions.Films.Title}\n");
            para.Range.InsertAfter($"Дата и время: {booking.Sessions.StartDateTime.Value.ToString("dd.MM.yy")}\n");
            para.Range.InsertAfter($"Место: Ряд {booking.Seats.RowNumber}, Место {booking.Seats.SeatNumber}\n");
            para.Range.InsertAfter($"Бронь действует до: {booking.ExpiresDateTime.ToString("HH:mm dd.MM.yy")}\n");

            SaveAndOpenWord(doc, wordApp, $"Booking_{booking.Id}");
        }

        /// <summary>
        /// Сохраняет и открывает Word-документ.
        /// </summary>
        /// <param name="doc">Документ Word.</param>
        /// <param name="app">Экземпляр Word-приложения.</param>
        /// <param name="baseFileName">Базовое имя файла для сохранения.</param>
        private void SaveAndOpenWord(Document doc, Microsoft.Office.Interop.Word.Application app, string baseFileName)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Word Documents|*.docx",
                FileName = $"{baseFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.docx"
            };

            if (dialog.ShowDialog() == true)
            {
                doc.SaveAs2(dialog.FileName);
                Process.Start(new ProcessStartInfo(dialog.FileName) { UseShellExecute = true });
            }

            doc.Close(false);
            app.Quit();
        }
    }
}
