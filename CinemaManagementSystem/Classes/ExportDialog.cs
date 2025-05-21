using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaManagementSystem.Classes
{
    public enum ExportFormat
    {
        Excel,
        Word,
        Cancel
    }

    public static class ExportDialog
    {
        /// <summary>
        /// Отображает диалог выбора формата экспорта и возвращает выбранный формат.
        /// </summary>
        /// <returns>Выбранный пользователем формат экспорта <see cref="ExportFormat"/>.</returns>
        public static ExportFormat AskExportFormat()
        {
            MessageBoxResult result = MessageBox.Show(
                "Выберите формат для экспорта:\n\nДа - Excel\nНет - Word\nОтмена - отменить операцию",
                "Выбор формата",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    return ExportFormat.Excel;
                case MessageBoxResult.No:
                    return ExportFormat.Word;
                default:
                    return ExportFormat.Cancel;
            }
        }
    }
}
