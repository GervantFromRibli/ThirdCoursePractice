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
    internal class EventRepository : IEventRepository
    {
        public EventRepository(DbContext context)
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

        public int CheckExistEvent(Event item)
        {
            string sql = "EXEC CheckExistEvent @LayoutId, @StartDate, @EndDate, @Result OUTPUT";

            List<SqlParameter> prms = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "LayoutId",
                    Value = item.LayoutId,
                },
                new SqlParameter
                {
                    ParameterName = "StartDate",
                    Value = item.StartDate,
                },
                new SqlParameter
                {
                    ParameterName = "EndDate",
                    Value = item.EndDate,
                },
                new SqlParameter
                {
                    ParameterName = "Result",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                },
            };

            DbContext.Database.ExecuteSqlRawAsync(sql, prms);
            return (int)prms[3].Value;
        }

        public int CheckSeatsInEvent(Event item)
        {
            string sql = "EXEC CheckSeatsInEvent @LayoutId, @Result OUTPUT";

            List<SqlParameter> prms = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "LayoutId",
                    Value = item.LayoutId,
                },
                new SqlParameter
                {
                    ParameterName = "Result",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                },
            };

            DbContext.Database.ExecuteSqlRawAsync(sql, prms);
            return (int)prms[1].Value;
        }

        /// <inheritdoc cref="IRepository{T}.Create(T)"/>
        public async Task Create(Event item)
        {
            await DbContext.Set<Event>().AddAsync(item);
            await DbContext.SaveChangesAsync();
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
