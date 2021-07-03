using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    public interface ILayoutBLL
    {
        public Task<Layout> GetLayout(int id);

        public Task DeleteLayout(int id);

        public List<Layout> GetLayouts();

        public Task CreateLayout(int venueId, string description);

        public Task UpdateLayout(int id, int venueId, string description);

        public string VerificationOfLayout(int id, string description);
    }
}
