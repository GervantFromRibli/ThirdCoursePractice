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

        public int RowCount { get; set; }

        public int NumbCount { get; set; }

        public List<PurchaseSeatViewModel> PurchaseSeatViewModels { get; set; }
    }
}
