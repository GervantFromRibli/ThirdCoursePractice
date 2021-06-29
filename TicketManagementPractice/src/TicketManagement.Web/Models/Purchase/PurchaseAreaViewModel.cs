using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.Web.Models
{
    public class PurchaseAreaViewModel
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StartCoordX { get; set; }

        public int StartCoordY { get; set; }

        public int EndCoordX { get; set; }

        public int EndCoordY { get; set; }

        public List<EventSeat> EventSeats { get; set; }
    }
}
