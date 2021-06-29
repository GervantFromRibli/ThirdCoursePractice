using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Web.Models
{
    public class HomeViewModel
    {
        public List<EventShowViewModel> Events { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
