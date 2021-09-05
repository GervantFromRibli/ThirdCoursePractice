using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    public interface ISeatBLL
    {
        public Task<Seat> GetSeat(int id);

        public Task DeleteSeat(int id);

        public List<Seat> GetSeats();

        public Task CreateSeat(int areaId, int row, int number);

        public Task UpdateSeat(int id, int areaId, int row, int number);

        public string VerificationOfSeat(int id, string areaDescr, int? row, int? number);
    }
}
