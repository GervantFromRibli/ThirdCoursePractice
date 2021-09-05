using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await Repository.Create(new EventArea(eventId, description, startCoordX, startCoordY, endCoordX, endCoordY, price));
        }

        public async Task UpdateEventArea(int id, int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price)
        {
            await Repository.Update(new EventArea(id, eventId, description, startCoordX, startCoordY, endCoordX, endCoordY, price));
        }

        public string VerificationOfEventArea(int id, string description, int? startX, int? startY, int? endX, int? endY, int eventId)
        {
            var descrs = GetEventAreas().Where(elem => elem.EventId == eventId && elem.Id != id).Select(elem => elem.Description);
            if (description == null || startX == null || startY == null || endY == null || endX == null)
            {
                return "NoValues";
            }
            if (description.Length == 0 || description.Length > 100 || descrs.Contains(description))
            {
                return "WrongDescr";
            }
            if (startX >= endX || startY >= endY)
            {
                return "WrongCoordStep";
            }
            foreach (var area in GetEventAreas().Where(elem => elem.EventId == eventId && elem.Id != id) ?? new List<EventArea>())
            {
                if (startX > area.StartCoordX && startX < area.EndCoordX && startY > area.StartCoordY && startY < endY)
                {
                    return "WrongStartCoord";
                }
                if (endX > area.StartCoordX && endX < area.EndCoordX && endY > area.StartCoordY && endY < area.EndCoordY)
                {
                    return "WrongEndCoord";
                }
            }
            return "Ok";
        }
    }
}
