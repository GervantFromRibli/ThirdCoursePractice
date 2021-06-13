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
    internal class VenueRepository : IRepository<Venue>
    {
        public VenueRepository(DbContext context)
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
        public async Task Create(Venue item)
        {
            string sql = "EXEC AddVenue @Descr, @Addr, @Phone, @StartTime, @EndTime, @Picture, @NewId OUTPUT";

            List<SqlParameter> prms = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "Name",
                    Value = item.Name,
                },
                new SqlParameter
                {
                    ParameterName = "Description",
                    Value = item.Description,
                },
                new SqlParameter
                {
                    ParameterName = "LayoutId",
                    Value = item.LayoutId,
                },
                new SqlParameter
                {
                    ParameterName = "StartTime",
                    Value = item.StartTime,
                },
                new SqlParameter
                {
                    ParameterName = "EndTime",
                    Value = item.EndTime,
                },
                new SqlParameter
                {
                    ParameterName = "Picture",
                    Value = item.Picture,
                },
                new SqlParameter
                {
                    ParameterName = "NewId",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                },
            };

            await DbContext.Database.ExecuteSqlRawAsync(sql, prms);
            return (int)prms[6].Value;
            await DbContext.Set<Venue>().AddAsync(item);
            await DbContext.SaveChangesAsync();
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
            return DbContext.Set<Venue>().AsNoTracking();
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
