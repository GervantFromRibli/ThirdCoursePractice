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
    internal class EventBLL
    {
        protected IEventRepository Repository { get; set; }

        public EventBLL(DbContext context)
        {
            Repository = new EventRepository(context);
        }

        public async Task<Event> GetEvent(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task DeleteEvent(int id)
        {
            Event @event = await Repository.GetById(id);
            await Repository.Delete(@event);
        }

        public List<Event> GetEvents()
        {
            return Repository.GetAll() as List<Event>;
        }

        public async Task CreateEvent(string name, string description, int layoutId, DateTime startDate, DateTime endDate)
        {
            Event @event = new Event(0, name, description, layoutId, startDate, endDate);
            if (!CheckEventIfPast(@event) && !CheckExistEvent(@event) && CheckSeatsInEvent(@event))
            {
                int id = GetEvents().Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new Event(id, name, description, layoutId, startDate, endDate));
            }
            else
            {
                if (CheckEventIfPast(@event))
                {
                    throw new Exception("This event was in the past");
                }
                else if (CheckExistEvent(@event))
                {
                    throw new Exception("There is an event with the same date");
                }
                else
                {
                    throw new Exception("There is no seats for this event");
                }
            }
        }

        public async Task UpdateEvent(int id, string name, string description, int layoutId, DateTime startDate, DateTime endDate)
        {
            Event @event = new Event(id, name, description, layoutId, startDate, endDate);
            if (!CheckEventIfPast(@event) && !CheckExistEvent(@event) && CheckSeatsInEvent(@event))
            {
                await Repository.Update(@event);
            }
            else
            {
                if (CheckEventIfPast(@event))
                {
                    throw new Exception("This event was in the past");
                }
                else if (CheckExistEvent(@event))
                {
                    throw new Exception("There is an event with the same date");
                }
                else
                {
                    throw new Exception("There is no seats for this event");
                }
            }
        }

        private bool CheckEventIfPast(Event @event)
        {
            DateTime date = DateTime.UtcNow;
            return @event.StartDate <= date;
        }

        private bool CheckExistEvent(Event @event)
        {
            return Repository.CheckExistEvent(@event) > 0;
        }

        private bool CheckSeatsInEvent(Event @event)
        {
            return Repository.CheckSeatsInEvent(@event) > 0;
        }
    }
}
