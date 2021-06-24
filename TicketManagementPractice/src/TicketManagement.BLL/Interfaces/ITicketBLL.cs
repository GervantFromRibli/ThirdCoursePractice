using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    public interface ITicketBLL
    {
        public Task<Ticket> GetTicket(int id);

        public Task DeleteTicket(int id);

        public List<Ticket> GetTickets();

        public Task CreateTicket(int eventSeatId, string userId);

        public Task UpdateTicket(int id, int eventSeatId, string userId);

        public List<Ticket> GetUserTickets(string userId);
    }
}
