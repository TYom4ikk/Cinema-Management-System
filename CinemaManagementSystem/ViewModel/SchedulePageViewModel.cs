using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class SchedulePageViewModel
    {
        /// <summary>
        /// Возвращает список всех сеансов с включением данных о фильмах и залах.
        /// </summary>
        /// <returns>Список объектов <see cref="Sessions"/>, включая связанные фильмы и залы.</returns>
        public List<Sessions> GetSessions()
        {
            return Core.GetContext().Sessions
                   .Include("Films")
                   .Include("Halls")
                   .ToList();
        }

        /// <summary>
        /// Возвращает список сеансов, проходящих в указанную дату.
        /// </summary>
        /// <param name="dateFilter">Дата, по которой фильтруются сеансы.</param>
        /// <returns>
        /// Список объектов <see cref="Sessions"/>, соответствующих заданной дате, включая фильмы и залы.
        /// </returns>
        public List<Sessions> GetSessionsDateFilter(DateTime dateFilter)
        {
            return Core.GetContext().Sessions
                       .Include("Films")
                       .Include("Halls")
                       .Where(s => s.StartDateTime.Value.Date == dateFilter)
                       .ToList();
        }
    }
}
