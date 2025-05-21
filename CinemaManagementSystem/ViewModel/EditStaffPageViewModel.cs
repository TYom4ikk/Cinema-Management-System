using CinemaManagementSystem.Model;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class EditStaffPageViewModel
    {
        /// <summary>
        /// Получает список всех сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        public List<Workers> GetWorkers()
        {
            return Core.GetContext().Workers.ToList();
        }
        /// <summary>
        /// Получает список всех должностей.
        /// </summary>
        /// <returns>Список должностей.</returns>
        public List<Posts> GetPosts()
        {
            return Core.GetContext().Posts.ToList();
        }

        /// <summary>
        /// Сохраняет все изменения в контексте данных.
        /// </summary>
        public void SaveChanges()
        {
            Core.GetContext().SaveChanges();
        }
        /// <summary>
        /// Удаляет указанного сотрудника из контекста.
        /// </summary>
        /// <param name="_currentWorker">Объект сотрудника для удаления.</param>
        public void RemoveWorkers(Workers _currentWorker)
        {
            Core.GetContext().Workers.Remove(_currentWorker);
        }
    }
}
