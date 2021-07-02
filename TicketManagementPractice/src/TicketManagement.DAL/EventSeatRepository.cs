using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    internal class EventSeatRepository : IRepository<EventSeat>
    {
        public EventSeatRepository(DbContext context)
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

        protected DbContext DbContext { get; set; }

        /// <inheritdoc cref="IRepository{T}.Create(T)"/>
        public async Task Create(EventSeat item)
        {
            await DbContext.Set<EventSeat>().AddAsync(item);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IRepository{T}.Delete(T)"/>
        public async Task Delete(EventSeat item)
        {
            DbContext.Set<EventSeat>().Remove(item);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IRepository{T}.GetAll()"/>
        public IQueryable<EventSeat> GetAll()
        {
            return DbContext.Set<EventSeat>().AsNoTracking();
        }

        /// <inheritdoc cref="IRepository{T}.GetById(int)"/>
        public async Task<EventSeat> GetById(int id)
        {
            return await DbContext.Set<EventSeat>().AsNoTracking().FirstOrDefaultAsync(elem => elem.Id == id);
        }

        /// <inheritdoc cref="IRepository{T}.Update(T)"/>
        public async Task Update(EventSeat item)
        {
            try
            {
                DbContext.Set<EventSeat>().Update(item);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
