using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.Web.Models
{
    public class PurchaseSeatViewModel
    {
        public int Id { get; set; }

        public int RowIndex { get; set; }

        public int NumbIndex { get; set; }

        public string State { get; set; }
    }
}
