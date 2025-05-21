using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class AddSessionPageViewModel
    {
        /// <summary>
        /// Возвращает список всех кинозалов.
        /// </summary>
        /// <returns>Список объектов типа <see cref="Halls"/>.</returns>
        public List<Halls> GetHalls()
        {
            return Core.GetContext().Halls.ToList();
        }
        /// <summary>
        /// Возвращает список всех фильмов из базы данных.
        /// </summary>
        /// <returns>Список объектов типа <see cref="Films"/>.</returns>
        public List<Films> GetFilms()
        {
            return Core.GetContext().Films.ToList();
        }
        /// <summary>
        /// Сохраняет все изменения, сделанные в контексте базы данных.
        /// </summary>
        public void SaveChanges()
        {
            Core.GetContext().SaveChanges();
        }
        /// <summary>
        /// Добавляет новый сеанс в базу данных.
        /// </summary>
        /// <param name="session">Объект сеанса, который необходимо добавить.</param>
        public void AddSession(Sessions session)
        {
            Core.GetContext().Sessions.Add(session);
        }
    }
}
