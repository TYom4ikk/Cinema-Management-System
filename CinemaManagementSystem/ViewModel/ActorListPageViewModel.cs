using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class ActorListPageViewModel
    {
        /// <summary>
        /// Сохраняет все изменения, сделанные в контексте базы данных.
        /// </summary>
        public void SaveChanges()
        {
            Core.GetContext().SaveChanges();
        }

        /// <summary>
        /// Удаляет указанного актёра из контекста базы данных.
        /// </summary>
        /// <param name="actor">Объект <see cref="Actors"/> для удаления.</param>
        public void RemoveActors(Actors actor)
        {
            Core.GetContext().Actors.Remove(actor);
        }
        /// <summary>
        /// Получает список всех актёров из базы данных.
        /// </summary>
        /// <returns>Список объектов <see cref="Actors"/>.</returns>
        public List<Actors> GetActors()
        {
            return Core.GetContext().Actors.ToList();
        }
        /// <summary>
        /// Получает список всех стран из базы данных.
        /// </summary>
        /// <returns>Список объектов <see cref="Countries"/>.</returns>
        public List<Countries> GetCountries()
        {
            return Core.GetContext().Countries.ToList();
        }
    }
}
