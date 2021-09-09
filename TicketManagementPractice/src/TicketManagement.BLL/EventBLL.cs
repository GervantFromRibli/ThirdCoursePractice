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
    /// Bll class for Event table that proxy all calls and validate data.
    /// </summary>
    internal class EventBLL : IEventBLL
    {
        /// <summary>
        /// Event repository
        /// </summary>
        protected IRepository<Event> Repository { get; set; }

        /// <summary>
        /// Area repository.
        /// </summary>
        protected IRepository<Area> AreaRepository { get; set; }

        /// <summary>
        /// Seat repository.
        /// </summary>
        protected IRepository<Seat> SeatRepository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBLL"/> class.
        /// </summary>
        /// <param name="context"> Instance of application context. </param>
        public EventBLL(ApplicationContext context)
        {
            Repository = new EventRepository(context);
            AreaRepository = new AreaRepository(context);
            SeatRepository = new SeatRepository(context);
        }

        /// <inheritdoc cref="IEventBLL.GetEvent(int)"/>
        public async Task<Event> GetEvent(int id)
        {
            return await Repository.GetById(id);
        }

        /// <inheritdoc cref="IEventBLL.DeleteEvent(int)"/>
        public async Task DeleteEvent(int id)
        {
            Event @event = await Repository.GetById(id);
            await Repository.Delete(@event);
        }

        /// <inheritdoc cref="IEventBLL.GetEvents"/>
        public List<Event> GetEvents()
        {
            return Repository.GetAll().ToList();
        }

        /// <inheritdoc cref="IEventBLL.CreateEvent(string, string, int, DateTime, DateTime, string)"/>
        public async Task CreateEvent(string name, string description, int layoutId, DateTime startDate, DateTime endDate, string imagePath)
        {
            await Repository.Create(new Event(name, description, layoutId, startDate, endDate, imagePath));
        }

        /// <inheritdoc cref="IEventBLL.UpdateEvent(int, string, string, int, DateTime, DateTime, string)"/>
        public async Task UpdateEvent(int id, string name, string description, int layoutId, DateTime startDate, DateTime endDate, string imagePath)
        {
            Event @event = new Event(id, name, description, layoutId, startDate, endDate, imagePath);
            await Repository.Update(@event);
        }

        /// <inheritdoc cref="IEventBLL.VerificationOfEvent(int, string, string, DateTime, DateTime, int)"/>
        public string VerificationOfEvent(int id, string name, string description, DateTime startDate, DateTime endDate, int layoutId)
        {
            var names = GetEvents().Where(elem => elem.Id != id).Select(elem => elem.Name);
            var descrs = GetEvents().Where(elem => elem.Id != id).Select(elem => elem.Description);
            var events = GetEvents().Where(elem => elem.Id != id);
            var seatsCount = GetSeatsCount(layoutId);
            if (description == null || name == null || startDate == null || endDate == null)
            {
                return "NoValues";
            }
            if (description.Length == 0 || description.Length > 100 || descrs.Contains(description))
            {
                return "WrongDescr";
            }
            if (name.Length == 0 || name.Length > 20 || names.Contains(name))
            {
                return "WrongName";
            }
            if (startDate >= endDate || startDate <= DateTime.Now)
            {
                return "WrongData";
            }
            foreach (var elem in events)
            {
                if (elem.LayoutId == layoutId && !(startDate > elem.EndDate || endDate < elem.StartDate))
                {
                    return "ExistEvent";
                }
            }
            if (seatsCount == 0)
            {
                return "NoSeats";
            }
            if (startDate <= DateTime.UtcNow)
            {
                return "EventInPast";
            }
            return "Ok";
        }

        private int GetSeatsCount(int layoutId)
        {
            var areas = AreaRepository.GetAll().Where(elem => elem.LayoutId == layoutId).Select(elem => elem.Id).ToList();
            var seats = SeatRepository.GetAll().Where(elem => areas.Contains(elem.AreaId)).ToList();
            return seats.Count();
        }
    }
}
