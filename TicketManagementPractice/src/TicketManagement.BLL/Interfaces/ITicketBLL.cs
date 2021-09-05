using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    public interface ITicketBLL
    {
        public List<Ticket> GetTickets();

        public Task CreateTicket(int eventSeatId, string userId);
    }
}
