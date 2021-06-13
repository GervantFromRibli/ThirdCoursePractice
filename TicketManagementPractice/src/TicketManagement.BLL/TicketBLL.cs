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
    internal class TicketBLL
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
            return Repository.GetAll() as List<Ticket>;
        }

        public async Task CreateTicket(int eventSeatId, int userId)
        {
            var tickets = GetTickets();
            int id = tickets.Select(elem => elem.Id).Max() + 1;
            await Repository.Create(new Ticket(id, eventSeatId, userId));
        }

        public async Task UpdateTicket(int id, int eventSeatId, int userId)
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
    }
}
