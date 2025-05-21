using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class FilmsListPageViewModel
    {
        /// <summary>
        /// Получает список всех фильмов из базы данных.
        /// </summary>
        /// <returns>Список объектов <see cref="Films"/>.</returns>
        public List<Films> GetFilms()
        {
            return Core.GetContext().Films.ToList();
        }

        /// <summary>
        /// Получает IQueryable для фильмов, что позволяет построить запросы с фильтрацией и сортировкой.
        /// </summary>
        /// <returns>IQueryable объектов <see cref="Films"/>.</returns>
        public IQueryable<Films> GetFilmsAsQuery()
        {
            return Core.GetContext().Films.AsQueryable();
        }
    }
}
