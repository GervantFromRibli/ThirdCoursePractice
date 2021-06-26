using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    public interface IEventAreaBLL
    {
        public Task<EventArea> GetEventArea(int id);

        public Task DeleteEventArea(int id);

        public List<EventArea> GetEventAreas();

        public Task CreateEventArea(int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price);

        public Task UpdateEventArea(int id, int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price);
    }
}
