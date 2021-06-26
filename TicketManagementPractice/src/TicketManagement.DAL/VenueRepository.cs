using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    internal class VenueRepository : IRepository<Venue>
    {
        public VenueRepository(ApplicationContext context)
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
        public async Task Create(Venue item)
        {
            await DbContext.Set<Venue>().AddAsync(item);
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <inheritdoc cref="IRepository{T}.Delete(T)"/>
        public async Task Delete(Venue item)
        {
            DbContext.Set<Venue>().Remove(item);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IRepository{T}.GetAll()"/>
        public IQueryable<Venue> GetAll()
        {
            return DbContext.Venues.AsNoTracking();
        }

        /// <inheritdoc cref="IRepository{T}.GetById(int)"/>
        public async Task<Venue> GetById(int id)
        {
            return await DbContext.Set<Venue>().AsNoTracking().FirstOrDefaultAsync(elem => elem.Id == id);
        }

        /// <inheritdoc cref="IRepository{T}.Update(T)"/>
        public async Task Update(Venue item)
        {
            DbContext.Set<Venue>().Update(item);
            await DbContext.SaveChangesAsync();
        }
    }
}
