using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class DailyReportPageViewModel
    {
        /// <summary>
        /// Возвращает список билетов, проданных в указанную дату.
        /// </summary>
        /// <param name="date">Дата продажи билетов.</param>
        /// <returns>Список объектов <see cref="Tickets"/>, проданных в указанный день.</returns>
        public List<Tickets> GetTicketsBySaleDateTime(DateTime date)
        {
            return Core.GetContext().Tickets.
                Where(t => t.SaleDateTime.Day == date.Day &&
            t.SaleDateTime.Month == date.Month &&
            t.SaleDateTime.Year == date.Year).ToList();
        }
    }
}
