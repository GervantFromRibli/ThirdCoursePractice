using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Web.Models
{
    public class TicketInfoViewModel
    {
        public string EventName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string AreaDescr { get; set; }

        public int Row { get; set; }

        public int Number { get; set; }
    }
}
