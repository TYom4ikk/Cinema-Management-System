using CinemaManagementSystem.Model;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class StaffListPageViewModel
    {
        /// <summary>
        /// Получает полный список сотрудников из базы данных.
        /// </summary>
        /// <returns>Список объектов типа <see cref="Workers"/>.</returns>
        public List<Workers> GetWorkers()
        {
            return Core.GetContext().Workers.ToList();
        }

        /// <summary>
        /// Выполняет поиск сотрудников по заданному тексту.
        /// </summary>
        /// <param name="searchText">Строка для поиска (имя, фамилия, отчество или должность).</param>
        /// <returns>
        /// Список сотрудников, чьи имя, фамилия, отчество (если указано) или название должности содержат указанный текст.
        /// </returns>
        public List<Workers> GetWorkersByText(string searchText)
        {
            return Core.GetContext().Workers
                    .Where(w =>
                        w.FirstName.ToLower().Contains(searchText) ||
                        w.LastName.ToLower().Contains(searchText) ||
                        (w.MiddleName != null && w.MiddleName.ToLower().Contains(searchText)) ||
                        w.Posts.Name.ToLower().Contains(searchText)).ToList();
        }
    }
}
