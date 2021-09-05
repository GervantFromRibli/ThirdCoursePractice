using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TicketManagement.Models;

[assembly: InternalsVisibleToAttribute("TicketManagement.BLL")]

namespace TicketManagement.DAL
{
    /// <summary>
    /// Класс-имплементация Entity Framework для работы с интерфейсом
    /// IRepository
    /// </summary>
    internal class EventRepository : IRepository<Event>
    {
        public EventRepository(ApplicationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("DBContext");
            }
            else
            {
                DbContext = context;
            }
        }

        protected ApplicationContext DbContext { get; set; }

        /// <inheritdoc cref="IRepository{T}.Create(T)"/>
        public async Task Create(Event item)
        {
            var name = new SqlParameter("@name", item.Name);
            var description = new SqlParameter("@description", item.Description);
            var layoutId = new SqlParameter("@layoutId", item.LayoutId);
            var start = new SqlParameter("@start", item.StartDate);
            var end = new SqlParameter("@end", item.EndDate);
            var imageUrl = new SqlParameter("@imageUrl", item.ImagePath);
            await DbContext.Database.ExecuteSqlRawAsync("CreateEvent @name, @description, @layoutId, @start, @end, @imageUrl", name, description, layoutId, start, end, imageUrl);
        }

        /// <inheritdoc cref="IRepository{T}.Delete(T)"/>
        public async Task Delete(Event item)
        {
            DbContext.Set<Event>().Remove(item);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IRepository{T}.GetAll()"/>
        public IQueryable<Event> GetAll()
        {
            return DbContext.Set<Event>().AsNoTracking();
        }

        /// <inheritdoc cref="IRepository{T}.GetById(int)"/>
        public async Task<Event> GetById(int id)
        {
            return await DbContext.Set<Event>().AsNoTracking().FirstOrDefaultAsync(elem => elem.Id == id);
        }

        /// <inheritdoc cref="IRepository{T}.Update(T)"/>
        public async Task Update(Event item)
        {
            DbContext.Set<Event>().Update(item);
            await DbContext.SaveChangesAsync();
        }
    }
}
