using Microsoft.EntityFrameworkCore;
using System;
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
    internal class LayoutRepository : IRepository<Layout>
    {
        public LayoutRepository(DbContext context)
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
        public async Task Create(Layout item)
        {
            await DbContext.Set<Layout>().AddAsync(item);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IRepository{T}.Delete(T)"/>
        public async Task Delete(Layout item)
        {
            DbContext.Set<Layout>().Remove(item);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IRepository{T}.GetAll()"/>
        public IQueryable<Layout> GetAll()
        {
            return DbContext.Set<Layout>().AsNoTracking();
        }

        /// <inheritdoc cref="IRepository{T}.GetById(int)"/>
        public async Task<Layout> GetById(int id)
        {
            return await DbContext.Set<Layout>().AsNoTracking().FirstOrDefaultAsync(elem => elem.Id == id);
        }

        /// <inheritdoc cref="IRepository{T}.Update(T)"/>
        public async Task Update(Layout item)
        {
            DbContext.Set<Layout>().Update(item);
            await DbContext.SaveChangesAsync();
        }
    }
}
