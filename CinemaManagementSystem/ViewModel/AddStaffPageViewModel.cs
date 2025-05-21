using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaManagementSystem.ViewModel
{
    public class AddStaffPageViewModel
    {
        /// <summary>
        /// Получает список всех должностей из базы данных.
        /// </summary>
        /// <returns>Список объектов <see cref="Posts"/>.</returns>
        public List<Posts> GetPosts()
        {
            return Core.GetContext().Posts.ToList();
        }

        /// <summary>
        /// Сохраняет все изменения, сделанные в контексте базы данных.
        /// </summary>
        public void SaveChanges()
        {
            Core.GetContext().SaveChanges();
        }
        /// <summary>
        /// Добавляет нового сотрудника в контекст базы данных.
        /// Сохранение необходимо выполнить отдельно через <see cref="SaveChanges"/>.
        /// </summary>
        /// <param name="newWorker">Объект <see cref="Workers"/>, представляющий нового сотрудника.</param>
        public void AddWorker(Workers newWorker)
        {
            Core.GetContext().Workers.Add(newWorker);
        }

        /// <summary>
        /// Проверяет, заполнено ли поле фамилии.
        /// </summary>
        /// <param name="LastName">Фамилия сотрудника.</param>
        /// <returns>True — если поле пустое; False — если заполнено.</returns>
        public bool IsLastNameEmpty(string LastName)
        {
            if (string.IsNullOrWhiteSpace(LastName))
            {
              
                return true;
            }
            return false;
        }


        /// <summary>
        /// Проверяет, заполнено ли поле имени.
        /// </summary>
        /// <param name="FirstName">Имя сотрудника.</param>
        /// <returns>True — если поле пустое; False — если заполнено.</returns>
        public bool IsFirstNameEmpty(string FirstName)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
               
                return true;
            }
            return false;
        }
    }
}
