using System.Collections.Generic;

namespace TicketManagement.Web.Models
{
    public class HomeViewModel
    {
        public List<EventShowViewModel> Events { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
