using Microsoft.AspNetCore.Identity;

namespace TicketManagement.Web.Models
{
    /// <summary>
    /// Класс пользователя с характеристиками
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Язык отображения информации на сайте
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Баланс пользователя для покупок
        /// </summary>
        public decimal Balance { get; set; }
    }
}
