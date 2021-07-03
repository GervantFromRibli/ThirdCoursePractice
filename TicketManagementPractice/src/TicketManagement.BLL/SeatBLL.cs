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
        protected IRepository<Area> AreaRepository { get; set; }

        public SeatBLL(DbContext context)
        {
            Repository = new SeatRepository(context);
            AreaRepository = new AreaRepository(context);
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
                int id = Repository.GetAll().Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new Seat(id, areaId, row, number));
            }
        }

        public async Task UpdateSeat(int id, int areaId, int row, int number)
        {
            await Repository.Update(new Seat(id, areaId, row, number));
        }

        public string VerificationOfSeat(int id, string areaDescr, int? row, int? number)
        {
            var area = AreaRepository.GetAll().Where(elem => elem.Description == areaDescr).First();
            var seats = GetSeats().Where(elem => elem.AreaId == area.Id && elem.Id != id).ToList() ?? new List<Seat>();
            if (row == null || number == null)
            {
                return "NoValues";
            }
            var rowCoord = area.StartCoordY + row;
            var numberCoord = area.StartCoordX + number;
            if (rowCoord > area.EndCoordY || numberCoord > area.EndCoordX || row < 1 || number < 1)
            {
                return "OutOfArea";
            }
            foreach (var seat in seats)
            {
                if (row == seat.Row && number == seat.Number)
                {
                    return "ExistPlace";
                }
            }
            return "Ok";
        }
    }
}
