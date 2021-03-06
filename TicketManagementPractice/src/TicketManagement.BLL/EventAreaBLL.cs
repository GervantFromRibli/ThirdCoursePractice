using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Bll class for Event area table that proxy all calls and validate data.
    /// </summary>
    internal class EventAreaBLL : IEventAreaBLL
    {
        /// <summary>
        ///  Event area repository.
        /// </summary>
        protected IRepository<EventArea> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventAreaBLL"/> class.
        /// </summary>
        /// <param name="context"> Instance of application context. </param>
        public EventAreaBLL(ApplicationContext context)
        {
            Repository = new EventAreaRepository(context);
        }

        /// <inheritdoc cref="IEventAreaBLL.GetEventArea(int)"/>
        public async Task<EventArea> GetEventArea(int id)
        {
            return await Repository.GetById(id);
        }

        /// <inheritdoc cref="IEventAreaBLL.DeleteEventArea(int)"/>
        public async Task DeleteEventArea(int id)
        {
            EventArea eventArea = await Repository.GetById(id);
            await Repository.Delete(eventArea);
        }

        /// <inheritdoc cref="IEventAreaBLL.GetEventAreas"/>
        public List<EventArea> GetEventAreas()
        {
            return Repository.GetAll().ToList();
        }

        /// <inheritdoc cref="IEventAreaBLL.CreateEventArea(int, string, int, int, int, int, decimal)"/>
        public async Task CreateEventArea(int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price)
        {
            await Repository.Create(new EventArea(eventId, description, startCoordX, startCoordY, endCoordX, endCoordY, price));
        }

        /// <inheritdoc cref="IEventAreaBLL.UpdateEventArea(int, int, string, int, int, int, int, decimal)"/>
        public async Task UpdateEventArea(int id, int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price)
        {
            await Repository.Update(new EventArea(id, eventId, description, startCoordX, startCoordY, endCoordX, endCoordY, price));
        }

        /// <inheritdoc cref="IEventAreaBLL.VerificationOfEventArea(int, string, int?, int?, int?, int?, int)"/>
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
