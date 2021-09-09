using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Bll class for Event seat table that proxy all calls and validate data.
    /// </summary> 
    internal class EventSeatBLL : IEventSeatBLL
    {
        /// <summary>
        /// Event Seat repository
        /// </summary>
        protected IRepository<EventSeat> Repository { get; set; }

        /// <summary>
        /// Event area repository.
        /// </summary>
        protected IRepository<EventArea> AreaRepository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSeatBLL"/> class.
        /// </summary>
        /// <param name="context"> Instance of application context. </param>
        public EventSeatBLL(DbContext context)
        {
            Repository = new EventSeatRepository(context);
            AreaRepository = new EventAreaRepository(context);
        }

        /// <inheritdoc cref="IEventSeatBLL.GetEventSeat(int)"/>
        public async Task<EventSeat> GetEventSeat(int id)
        {
            return await Repository.GetById(id);
        }

        /// <inheritdoc cref="IEventSeatBLL.DeleteEventSeat(int)"/>
        public async Task DeleteEventSeat(int id)
        {
            EventSeat seat = await Repository.GetById(id);
            await Repository.Delete(seat);
        }

        /// <inheritdoc cref="IEventSeatBLL.GetEventSeats"/>
        public List<EventSeat> GetEventSeats()
        {
            return Repository.GetAll().ToList();
        }

        /// <inheritdoc cref="IEventSeatBLL.CreateEventSeat(int, int, int, string)"/>
        public async Task CreateEventSeat(int eventAreaId, int row, int number, string state)
        {
            await Repository.Create(new EventSeat(eventAreaId, row, number, state));
        }

        /// <inheritdoc cref="IEventSeatBLL.UpdateEventSeat(int, int, int, int, string)"/>
        public async Task UpdateEventSeat(int id, int eventAreaId, int row, int number, string state)
        {
            await Repository.Update(new EventSeat(id, eventAreaId, row, number, state));
        }

        /// <inheritdoc cref="IEventSeatBLL.VerificationOfEventSeat(int, int?, int?, string, int)"/>
        public string VerificationOfEventSeat(int id, int? row, int? number, string state, int eventAreaId)
        {
            var seats = GetEventSeats().Where(elem => elem.EventAreaId == eventAreaId && elem.Id != id).ToList();
            var area = AreaRepository.GetById(eventAreaId).Result;
            if (row == null || number == null || state == null)
            {
                return "NoValues";
            }
            var rowCoord = area.StartCoordY + row;
            var numberCoord = area.StartCoordX + number;
            if (rowCoord > area.EndCoordY || numberCoord > area.EndCoordX || row < 1 || number < 1)
            {
                return "NoInArea";
            }
            foreach (var seat in seats)
            {
                if (row == seat.Row && number == seat.Number)
                {
                    return "ExistSeat";
                }
            }
            return "Ok";
        }
    }
}
