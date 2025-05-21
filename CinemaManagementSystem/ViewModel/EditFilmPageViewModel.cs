using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class EditFilmPageViewModel
    {
        /// <summary>
        /// Получает список всех фильмов.
        /// </summary>
        /// <returns>Список фильмов.</returns>
        public List<Films> GetFilms()
        {
            return Core.GetContext().Films.ToList();
        }
        /// <summary>
        /// Получает список всех актёров.
        /// </summary>
        /// <returns>Список актёров.</returns>
        public List<Actors> GetActors()
        {
            return Core.GetContext().Actors.ToList();
        }
        /// <summary>
        /// Получает список всех жанров.
        /// </summary>
        /// <returns>Список жанров.</returns>
        public List<Genres> GetGenres()
        {
            return Core.GetContext().Genres.ToList();
        }
        /// <summary>
        /// Сохраняет изменения в базе данных.
        /// </summary>
        public void SaveChanges()
        {
            Core.GetContext().SaveChanges();
        }
        /// <summary>
        /// Удаляет фильм из контекста.
        /// </summary>
        /// <param name="_currentFilm">Объект фильма для удаления.</param>
        public void RemoveFilm(Films _currentFilm)
        {
            Core.GetContext().Films.Remove(_currentFilm);
        }
    }
}
