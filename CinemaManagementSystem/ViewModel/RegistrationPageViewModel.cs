using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CinemaManagementSystem.Model;

namespace CinemaManagementSystem.ViewModel
{
    internal class RegistrationPageViewModel
    {
        /// <summary>
        /// Получает сотрудника по логину и паролю.
        /// </summary>
        /// <param name="login">Логин пользователя (email).</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Объект <see cref="Workers"/> при успешном совпадении, иначе null.</returns>
        public Workers GetWorker(string login, string password)
        {
            return Core.GetContext().Workers.FirstOrDefault(w=>w.Email == login && w.Password == password);
        }
    }
}
