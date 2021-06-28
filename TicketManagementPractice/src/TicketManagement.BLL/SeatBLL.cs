using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    internal class SeatBLL : ISeatBLL
    {
        protected IRepository<Seat> Repository { get; set; }

        public SeatBLL(DbContext context)
        {
            Repository = new SeatRepository(context);
        }

        public async Task<Seat> GetSeat(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task DeleteSeat(int id)
        {
            Seat seat = await Repository.GetById(id);
            await Repository.Delete(seat);
        }

        public List<Seat> GetSeats()
        {
            return Repository.GetAll().ToList();
        }

        public async Task CreateSeat(int areaId, int row, int number)
        {
            if (Repository.GetAll().Count() == 0)
            {
                await Repository.Create(new Seat(1, areaId, row, number));
            }
            else
            {
                var seats = GetSeats().Where(elem => elem.AreaId == areaId && elem.Row == row && elem.Number == number);
                if (!seats.Any())
                {
                    int id = Repository.GetAll().Select(elem => elem.Id).Max() + 1;
                    await Repository.Create(new Seat(id, areaId, row, number));
                }
                else
                {
                    throw new Exception("There is a seat with the same coordinates");
                }
            }
        }

        public async Task UpdateSeat(int id, int areaId, int row, int number)
        {
            var seats = GetSeats().Where(elem => elem.AreaId == areaId && elem.Row == row && elem.Number == number);
            if (!seats.Any())
            {
                await Repository.Update(new Seat(id, areaId, row, number));
            }
            else
            {
                throw new Exception("There is a seat with the same coordinates");
            }
        }
    }
}
