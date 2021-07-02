using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

        public async Task<Ticket> GetTicket(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task DeleteTicket(int id)
        {
            Ticket ticket = await Repository.GetById(id);
            await Repository.Delete(ticket);
        }

        public List<Ticket> GetTickets()
        {
            return Repository.GetAll().ToList();
        }

        public async Task CreateTicket(int eventSeatId, string userId)
        {
            var tickets = GetTickets() ?? new List<Ticket>();
            if (tickets.Count() == 0)
            {
                await Repository.Create(new Ticket(1, eventSeatId, userId));
            }
            else
            {
                int id = tickets.Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new Ticket(id, eventSeatId, userId));
            }
        }

        public async Task UpdateTicket(int id, int eventSeatId, string userId)
        {
            var tickets = GetTickets().Where(elem => elem.EventSeatId == eventSeatId);
            if (!tickets.Any())
            {
                await Repository.Update(new Ticket(id, eventSeatId, userId));
            }
            else
            {
                throw new Exception("There is a ticket with the same attributes");
            }
        }

        public List<Ticket> GetUserTickets(string userId)
        {
            return Repository.GetAll().Where(elem => elem.UserId == userId) as List<Ticket>;
        }
    }
}
