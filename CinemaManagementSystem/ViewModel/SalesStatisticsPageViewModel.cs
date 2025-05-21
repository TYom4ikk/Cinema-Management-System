using CinemaManagementSystem.Model;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class SalesStatisticsPageViewModel
    {
        /// <summary>
        /// Получает список проданных билетов за указанный диапазон дат.
        /// </summary>
        /// <param name="startDate">Дата начала периода.</param>
        /// <param name="endDate">Дата окончания периода.</param>
        /// <returns>Список объектов <see cref="Tickets"/>, проданных в указанный период.</returns>
        public List<Tickets> GetTicketsInDateRange(DateTime startDate, DateTime endDate)
        {
            return Core.GetContext().Tickets
                    .Where(t => t.SaleDateTime >= startDate && t.SaleDateTime <= endDate)
                    .ToList();
        }
    }
}
