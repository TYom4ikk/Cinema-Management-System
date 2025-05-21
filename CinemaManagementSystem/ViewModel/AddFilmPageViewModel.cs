using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class AddFilmPageViewModel
    {
        /// <summary>
        /// Возвращает список всех стран из базы данных.
        /// </summary>
        /// <returns>Список объектов типа <see cref="Countries"/>.</returns>
        public List<Countries> GetCountries()
        {
            return Core.GetContext().Countries.ToList();
        }
        /// <summary>
        /// Добавляет новый фильм в базу данных.
        /// </summary>
        /// <param name="film">Объект фильма, который необходимо добавить.</param>
        public void AddFilm(Films film)
        {
            Core.GetContext().Films.Add(film);
        }
        /// <summary>
        /// Сохраняет все изменения, сделанные в контексте базы данных.
        /// </summary>
        public void SaveChanges()
        {
            Core.GetContext().SaveChanges();
        }
        /// <summary>
        /// Возвращает список всех актёров из базы данных.
        /// </summary>
        /// <returns>Список объектов типа <see cref="Actors"/>.</returns>
        public List<Actors> GetActors()
        {
            return Core.GetContext().Actors.ToList();
        }
        /// <summary>
        /// Возвращает список всех жанров из базы данных.
        /// </summary>
        /// <returns>Список объектов типа <see cref="Genres"/>.</returns>
        public List<Genres> GetGenres()
        {
            return Core.GetContext().Genres.ToList();
        }
    }
}
