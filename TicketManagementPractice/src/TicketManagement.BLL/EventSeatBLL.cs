﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    internal class EventSeatBLL
    {
        protected IRepository<EventSeat> Repository { get; set; }

        public EventSeatBLL(DbContext context)
        {
            Repository = new EventSeatRepository(context);
        }

        public async Task<EventSeat> GetEventSeat(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task DeleteEventSeat(int id)
        {
            EventSeat seat = await Repository.GetById(id);
            await Repository.Delete(seat);
        }

        public List<EventSeat> GetEventSeats()
        {
            return Repository.GetAll() as List<EventSeat>;
        }

        public async Task CreateEventSeat(int eventAreaId, int row, int number, string state)
        {
            var seats = GetEventSeats().Where(elem => elem.EventAreaId == eventAreaId && elem.Row == row && elem.Number == number);
            if (!seats.Any())
            {
                int id = seats.Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new EventSeat(id, eventAreaId, row, number, state));
            }
            else
            {
                throw new Exception("There is an event seat with the same coordinates");
            }
        }

        public async Task UpdateEventSeat(int id, int eventAreaId, int row, int number, string state)
        {
            var seats = GetEventSeats().Where(elem => elem.EventAreaId == eventAreaId && elem.Row == row && elem.Number == number);
            if (!seats.Any())
            {
                await Repository.Update(new EventSeat(id, eventAreaId, row, number, state));
            }
            else
            {
                throw new Exception("There is an event seat with the same coordinates");
            }
        }
    }
}