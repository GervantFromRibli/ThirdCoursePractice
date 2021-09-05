using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    public interface IEventSeatBLL
    {
        public Task<EventSeat> GetEventSeat(int id);

        public Task DeleteEventSeat(int id);

        public List<EventSeat> GetEventSeats();

        public Task CreateEventSeat(int eventAreaId, int row, int number, string state);

        public Task UpdateEventSeat(int id, int eventAreaId, int row, int number, string state);

        public string VerificationOfEventSeat(int id, int? row, int? number, string state, int eventAreaId);
    }
}
