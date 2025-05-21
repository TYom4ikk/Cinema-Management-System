using CinemaManagementSystem.Model;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaManagementSystem.Classes
{
    internal class DailyReport
    {
        /// <summary>
        /// Экспортирует список проданных билетов за указанную дату в файл Excel с отчётом по продажам.
        /// </summary>
        /// <param name="tickets">Список проданных билетов.</param>
        /// <param name="date">Дата отчёта.</param>
        public void ExportTicketToExcel(List<Tickets> tickets, DateTime date)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application { Visible = false };
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Worksheet)workbook.Sheets[1];

            decimal profit = 0;



            if (tickets.Count != 0)
            {
                foreach (var ticket in tickets)
                {
                    profit += ticket.Price;
                }


                worksheet.Cells[2, 1].Value = "Всего продано:";
                worksheet.Cells[2, 2].Value = $"{tickets.Count}";

                worksheet.Cells[4, 1].Value = "Средняя цена:";
                worksheet.Cells[4, 2].Value = $"{profit / tickets.Count}";


                int row = 6;
                foreach (var ticket in tickets)
                {
                    worksheet.Cells[row, 1].Value = "Название фильма:";
                    worksheet.Cells[row, 2].Value = ticket.Sessions.Films.Title;

                    worksheet.Cells[row, 3].Value = "Зал:";
                    worksheet.Cells[row, 4].Value = ticket.Sessions.Halls.Name;

                    worksheet.Cells[row, 5].Value = "Ряд:";
                    worksheet.Cells[row, 6].Value = ticket.Seats.RowNumber;

                    worksheet.Cells[row, 7].Value = "Место:";
                    worksheet.Cells[row, 8].Value = ticket.Seats.SeatNumber;

                    worksheet.Cells[row, 9].Value = "Цена за билет:";
                    worksheet.Cells[row, 10].Value = $"{ticket.Price} руб.";

                    worksheet.Cells[row, 11].Value = "Дата продажи:";
                    worksheet.Cells[row, 12].Value = ticket.SaleDateTime;

                    row++;
                }
            }
            else
            {
                worksheet.Cells[2, 1].Value = "Всего продано:";
                worksheet.Cells[2, 2].Value = $"{0}";


                worksheet.Cells[4, 1].Value = "Средняя цена:";
                worksheet.Cells[4, 2].Value = $"{0}";

            }
            worksheet.Cells[1, 1].Value = "Информация о продажах за:";
            worksheet.Cells[1, 2].Value = date.ToString("dd.MM.yyyy");

            

            worksheet.Cells[3, 1].Value = "Доход с билетов:";
            worksheet.Cells[3, 2].Value = $"{profit} руб.";

            worksheet.Cells[5, 1].Value = "Билеты:";

            

            worksheet.Columns.AutoFit();

            SaveAndOpenExcel(workbook, excelApp, $"DailySalesReport_{DateTime.Now.ToString("HH_mm_ss_yyyyMMdd")}");
        }

        /// <summary>
        /// Сохраняет книгу Excel по выбранному пользователем пути и открывает файл.
        /// </summary>
        /// <param name="workbook">Объект книги Excel для сохранения.</param>
        /// <param name="app">Экземпляр приложения Microsoft Excel.</param>
        /// <param name="baseFileName">Базовое имя файла для сохранения (без расширения).</param>
        /// <remarks>
        /// Метод отображает диалог выбора пути сохранения с предзаполненным именем файла,
        /// сохраняет книгу в формате .xlsx и открывает ее с помощью стандартного приложения для Excel.
        /// После сохранения книга и приложение закрываются.
        /// В случае ошибки метод ловит исключение, но не выводит сообщение пользователю.
        /// </remarks>
        private void SaveAndOpenExcel(Workbook workbook, Microsoft.Office.Interop.Excel.Application app, string baseFileName)
        {
            try
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
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        /// <summary>
        /// Экспортирует список проданных билетов за указанную дату в документ Word с отчётом по продажам.
        /// </summary>
        /// <param name="tickets">Список проданных билетов.</param>
        /// <param name="date">Дата отчёта.</param>
        public void ExportTicketToWord(List<Tickets> tickets, DateTime date)
        {
            var wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
            var doc = wordApp.Documents.Add();

            var para = doc.Paragraphs.Add();

            decimal profit = 0;

            if (tickets.Count != 0)
            {
                foreach (var ticket in tickets)
                {
                    profit += ticket.Price;
                }
                para.Range.InsertAfter($"Всего продано: {tickets.Count}\n");
                para.Range.InsertAfter($"Средняя цена: {profit / tickets.Count} руб.\n\n");

                foreach (var ticket in tickets)
                {
                    para.Range.InsertAfter($"Название фильма: {ticket.Sessions.Films.Title}\n");
                    para.Range.InsertAfter($"Зал: {ticket.Sessions.Halls.Name}\n");
                    para.Range.InsertAfter($"Ряд: {ticket.Seats.RowNumber}, Место: {ticket.Seats.SeatNumber}\n");
                    para.Range.InsertAfter($"Цена за билет: {ticket.Price} руб.\n");
                    para.Range.InsertAfter($"\nДата продажи: {ticket.SaleDateTime}\n");
                }
            }
            else
            {
                para.Range.InsertAfter($"Всего продано: 0\n");
                para.Range.InsertAfter($"Средняя цена: 0 руб.\n\n");
            }

                para.Range.Text = $"Информация о продажах за: {date.ToString("dd.MM.yyyy")}\n\n";
           
            para.Range.InsertAfter($"Доход с билетов: {profit} руб.\n");

            para.Range.InsertAfter($"Билеты:\n");

            

            SaveAndOpenWord(doc, wordApp, $"DailySalesReport_{DateTime.Now.ToString("HH_mm_ss_yyyyMMdd")}");
        }

        /// <summary>
        /// Сохраняет документ Microsoft Word по выбранному пользователем пути и открывает его.
        /// </summary>
        /// <param name="doc">Документ Word, который необходимо сохранить.</param>
        /// <param name="app">Экземпляр приложения Microsoft Word.</param>
        /// <param name="baseFileName">Базовое имя файла для сохранения (без расширения).</param>
        /// <remarks>
        /// Метод отображает диалог сохранения файла с предзаполненным именем, 
        /// сохраняет документ по выбранному пути и открывает его с помощью стандартного приложения для docx-файлов.
        /// После сохранения документ и приложение Word закрываются.
        /// </remarks>
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
