using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class BuyTicketPageViewModel
    {
        /// <summary>
        /// Возвращает текущий экземпляр контекста базы данных.
        /// </summary>
        /// <returns>Экземпляр <see cref="Cinema_DBEntities"/>.</returns>
        public Cinema_DBEntities GetContext()
        {
            return Core.GetContext();
        }
        /// <summary>
        /// Возвращает список мест, принадлежащих заданному залу.
        /// </summary>
        /// <param name="hallId">Идентификатор зала.</param>
        /// <returns>Список объектов <see cref="Seats"/> для указанного зала.</returns>
        public List<Seats> GetSeatsByHallId(short hallId)
        {
            return Core.GetContext().Seats
                .Where(s=>s.HallId == hallId).ToList();
        }
    }
}
