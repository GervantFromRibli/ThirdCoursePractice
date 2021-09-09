using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Interface that contains the basic methods of bll-class "TicketBLL".
    /// </summary>
    public interface ITicketBLL
    {
        /// <summary>
        /// Method that returns a list of records from Ticket table.
        /// </summary>
        /// <returns> List of records from Ticket table. </returns>
        public List<Ticket> GetTickets();

        /// <summary>
        /// Method that create a record in Ticket table with certain parameters.
        /// </summary>
        /// <param name="eventSeatId"> Id of event seat record. </param>
        /// <param name="userId"> Id of user. </param>
        public Task CreateTicket(int eventSeatId, string userId);
    }
}
