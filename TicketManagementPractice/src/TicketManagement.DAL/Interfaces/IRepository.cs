using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.DAL
{
    /// <summary>
    /// Интерфейс для абстракции работы с БД
    /// </summary>
    /// <typeparam name="T"> Класс, представляющий модель записи в определенной таблице </typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Метод записи объекта в БД
        /// </summary>
        /// <param name="item"> Объект для записи </param>
        Task Create(T item);

        /// <summary>
        /// Метод удаления записи из таблицы
        /// </summary>
        /// <param name="item"> Объект для удаления </param>
        Task Delete(T item);

        /// <summary>
        /// Метод получения записи из БД по полю Id
        /// </summary>
        /// <param name="id"> Id записи </param>
        /// <returns> Запись из БД с заданным Id </returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Метод получения всех записей из таблицы заданного типа
        /// </summary>
        /// <returns> Список записей из таблицы заданного типа </returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Метод обновления записи с заданным Id данными из заданного объекта
        /// </summary>
        /// <param name="item"> Объект для обновления </param>
        Task Update(T item);
    }
}
