using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
