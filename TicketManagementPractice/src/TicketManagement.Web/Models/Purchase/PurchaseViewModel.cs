using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.Web.Models
{
    public class PurchaseViewModel
    {
        public Event Event { get; set; }

        public List<PurchaseAreaViewModel> PurchaseAreaViewModels { get; set; }
    }
}
