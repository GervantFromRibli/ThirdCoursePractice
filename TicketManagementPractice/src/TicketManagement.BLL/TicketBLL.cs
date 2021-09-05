using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

[assembly: InternalsVisibleTo("TicketManagement.Web")]
namespace TicketManagement.BLL
{
    internal class TicketBLL : ITicketBLL
    {
        protected IRepository<Ticket> Repository { get; set; }

        public TicketBLL(DbContext context)
        {
            Repository = new TicketRepository(context);
        }

        public List<Ticket> GetTickets()
        {
            return Repository.GetAll().ToList();
        }

        public async Task CreateTicket(int eventSeatId, string userId)
        {
            await Repository.Create(new Ticket(eventSeatId, userId));
        }
    }
}
