using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    public interface IEventBLL
    {
        public Task<Event> GetEvent(int id);

        public Task DeleteEvent(int id);

        public List<Event> GetEvents();

        public Task CreateEvent(string name, string description, int layoutId, DateTime startDate, DateTime endDate, string imagePath);

        public Task UpdateEvent(int id, string name, string description, int layoutId, DateTime startDate, DateTime endDate, string imagePath);

        public string VerificationOfEvent(int id, string name, string description, DateTime startDate, DateTime endDate, int layoutId);
    }
}
