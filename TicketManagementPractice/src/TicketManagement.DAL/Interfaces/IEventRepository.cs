using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.DAL
{
    public interface IEventRepository : IRepository<Event>
    {
        int CheckExistEvent(Event item);

        int CheckSeatsInEvent(Event item);
    }
}
