using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    public interface IVenueBLL
    {
        public Task<Venue> GetVenue(int id);

        public Task DeleteVenue(int id);

        public List<Venue> GetVenues();

        public Task CreateVenue(string descr, string address, string phone);

        public Task UpdateVenue(int id, string descr, string address, string phone);

        public string VerificationOfVenue(int id, string description, string address, string phone);
    }
}
