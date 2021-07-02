using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Web.Models
{
    public class BuyTicketViewModel
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public string AreaDescription { get; set; }

        public decimal Price { get; set; }

        public int Row { get; set; }

        public int Number { get; set; }
    }
}
