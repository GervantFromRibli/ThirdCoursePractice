using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    internal class EventSeatBLL : IEventSeatBLL
    {
        protected IRepository<EventSeat> Repository { get; set; }
        protected IRepository<EventArea> AreaRepository { get; set; }

        public EventSeatBLL(DbContext context)
        {
            Repository = new EventSeatRepository(context);
            AreaRepository = new EventAreaRepository(context);
        }

        public async Task<EventSeat> GetEventSeat(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task DeleteEventSeat(int id)
        {
            EventSeat seat = await Repository.GetById(id);
            await Repository.Delete(seat);
        }

        public List<EventSeat> GetEventSeats()
        {
            return Repository.GetAll().ToList();
        }

        public async Task CreateEventSeat(int eventAreaId, int row, int number, string state)
        {
            await Repository.Create(new EventSeat(eventAreaId, row, number, state));
        }

        public async Task UpdateEventSeat(int id, int eventAreaId, int row, int number, string state)
        {
            await Repository.Update(new EventSeat(id, eventAreaId, row, number, state));
        }

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
