using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Bll class for Seat table that proxy all calls and validate data.
    /// </summary>
    internal class SeatBLL : ISeatBLL
    {
        /// <summary>
        /// Seat repository.
        /// </summary>
        protected IRepository<Seat> Repository { get; set; }

        /// <summary>
        /// Area repository.
        /// </summary>
        protected IRepository<Area> AreaRepository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeatBLL"/> class.
        /// </summary>
        /// <param name="context"> Instance of application context. </param>
        public SeatBLL(DbContext context)
        {
            Repository = new SeatRepository(context);
            AreaRepository = new AreaRepository(context);
        }

        /// <inheritdoc cref="ISeatBLL.GetSeat(int)"/>
        public async Task<Seat> GetSeat(int id)
        {
            return await Repository.GetById(id);
        }

        /// <inheritdoc cref="ISeatBLL.DeleteSeat(int)"/>
        public async Task DeleteSeat(int id)
        {
            Seat seat = await Repository.GetById(id);
            await Repository.Delete(seat);
        }

        /// <inheritdoc cref="ISeatBLL.GetSeats"/>
        public List<Seat> GetSeats()
        {
            return Repository.GetAll().ToList();
        }

        /// <inheritdoc cref="ISeatBLL.CreateSeat(int, int, int)"/>
        public async Task CreateSeat(int areaId, int row, int number)
        {
            await Repository.Create(new Seat(areaId, row, number));
        }

        /// <inheritdoc cref="ISeatBLL.UpdateSeat(int, int, int, int)"/>
        public async Task UpdateSeat(int id, int areaId, int row, int number)
        {
            await Repository.Update(new Seat(id, areaId, row, number));
        }

        /// <inheritdoc cref="ISeatBLL.VerificationOfSeat(int, string, int?, int?)"/>
        public string VerificationOfSeat(int id, string areaDescr, int? row, int? number)
        {
            var area = AreaRepository.GetAll().Where(elem => elem.Description == areaDescr).First();
            var seats = GetSeats().Where(elem => elem.AreaId == area.Id && elem.Id != id).ToList() ?? new List<Seat>();
            if (row == null || number == null)
            {
                return "NoValues";
            }
            var rowCoord = area.StartCoordY + row;
            var numberCoord = area.StartCoordX + number;
            if (rowCoord > area.EndCoordY || numberCoord > area.EndCoordX || row < 1 || number < 1)
            {
                return "OutOfArea";
            }
            foreach (var seat in seats)
            {
                if (row == seat.Row && number == seat.Number)
                {
                    return "ExistPlace";
                }
            }
            return "Ok";
        }
    }
}
