using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TicketManagement.Models;

[assembly: InternalsVisibleTo("TicketManagement.BLL")]

namespace TicketManagement.DAL
{
    internal class AreaRepository : IRepository<Area>
    {
        public AreaRepository(DbContext context)
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
        public async Task Create(Area item)
        {
            await DbContext.Set<Area>().AddAsync(item);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IRepository{T}.Delete(T)"/>
        public async Task Delete(Area item)
        {
            DbContext.Set<Area>().Remove(item);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IRepository{T}.GetAll()"/>
        public IQueryable<Area> GetAll()
        {
            return DbContext.Set<Area>().AsNoTracking();
        }

        /// <inheritdoc cref="IRepository{T}.GetById(int)"/>
        public async Task<Area> GetById(int id)
        {
            return await DbContext.Set<Area>().AsNoTracking().FirstOrDefaultAsync(elem => elem.Id == id);
        }

        /// <inheritdoc cref="IRepository{T}.Update(T)"/>
        public async Task Update(Area item)
        {
            DbContext.Set<Area>().Update(item);
            await DbContext.SaveChangesAsync();
        }
    }
}
