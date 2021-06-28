using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    internal class EventAreaBLL : IEventAreaBLL
    {
        protected IRepository<EventArea> Repository { get; set; }

        public EventAreaBLL(ApplicationContext context)
        {
            Repository = new EventAreaRepository(context);
        }

        public async Task<EventArea> GetEventArea(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task DeleteEventArea(int id)
        {
            EventArea eventArea = await Repository.GetById(id);
            await Repository.Delete(eventArea);
        }

        public List<EventArea> GetEventAreas()
        {
            return Repository.GetAll().ToList();
        }

        public async Task CreateEventArea(int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price)
        {
            List<EventArea> areas = GetEventAreas();
            if (areas.Count() == 0)
            {
                await Repository.Create(new EventArea(1, eventId, description, startCoordX, startCoordY, endCoordX, endCoordY, price));
            }
            else if (!areas.Where(elem => elem.EventId == eventId).Select(elem => elem.Description).Contains(description))
            {
                int id = areas.Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new EventArea(id, eventId, description, startCoordX, startCoordY, endCoordX, endCoordY, price));
            }
            else
            {
                throw new Exception("There is an event area with the same description");
            }
        }

        public async Task UpdateEventArea(int id, int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price)
        {
            List<EventArea> areas = GetEventAreas();
            if (!areas.Where(elem => elem.EventId == eventId).Select(elem => elem.Description).Contains(description))
            {
                await Repository.Create(new EventArea(id, eventId, description, startCoordX, startCoordY, endCoordX, endCoordY, price));
            }
            else
            {
                throw new Exception("There is an event area with the same description");
            }
        }
    }
}
