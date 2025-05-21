using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    internal class AddActorPageViewModel
    {
        /// <summary>
        /// Получает список всех стран из базы данных.
        /// </summary>
        /// <returns>Список объектов <see cref="Countries"/>.</returns>
        public List<Countries> GetCountries()
        {
            return Core.GetContext().Countries.ToList();
        }
        /// <summary>
        /// Добавляет нового актёра в контекст базы данных.
        /// Сохранение необходимо выполнить отдельно через <see cref="SaveChanges"/>.
        /// </summary>
        /// <param name="actor">Объект <see cref="Actors"/>, представляющий нового актёра.</param>
        public void AddActors(Actors actor)
        {
            Core.GetContext().Actors.Add(actor);
        }
        /// <summary>
        /// Сохраняет все изменения, сделанные в контексте базы данных.
        /// </summary>
        public void SaveChanges()
        {
            Core.GetContext().SaveChanges();
        }
    }
}
