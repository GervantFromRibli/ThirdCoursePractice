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
    /// <summary>
    /// Bll class for Ticket table that proxy all calls and validate data.
    /// </summary>
    internal class TicketBLL : ITicketBLL
    {
        /// <summary>
        /// Ticket repository.
        /// </summary>
        protected IRepository<Ticket> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketBLL"/> class.
        /// </summary>
        /// <param name="context"> Instance of application context. </param>
        public TicketBLL(DbContext context)
        {
            Repository = new TicketRepository(context);
        }

        /// <inheritdoc cref="ITicketBLL.GetTickets"/>
        public List<Ticket> GetTickets()
        {
            return Repository.GetAll().ToList();
        }

        /// <inheritdoc cref="ITicketBLL.CreateTicket(int, string)"/>
        public async Task CreateTicket(int eventSeatId, string userId)
        {
            await Repository.Create(new Ticket(eventSeatId, userId));
        }
    }
}
