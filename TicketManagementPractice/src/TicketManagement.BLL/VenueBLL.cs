using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    internal class VenueBLL : IVenueBLL
    {
        protected IRepository<Venue> Repository { get; set; }

        public VenueBLL(ApplicationContext context)
        {
            Repository = new VenueRepository(context);
        }

        public async Task<Venue> GetVenue(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task DeleteVenue(int id)
        {
            Venue venue = await Repository.GetById(id);
            await Repository.Delete(venue);
        }

        public List<Venue> GetVenues()
        {
            return Repository.GetAll().ToList();
        }

        public async Task CreateVenue(string descr, string address, string phone)
        {
            List<Venue> venues = GetVenues();
            if (venues.Count() == 0)
            {
                await Repository.Create(new Venue(1, descr, address, phone));
            }
            else if (!venues.Select(elem => elem.Description).Contains(descr))
            {
                int id = venues.Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new Venue(id, descr, address, phone));
            }
            else
            {
                throw new Exception("There is a venue with the same description");
            }
        }

        public async Task UpdateVenue(int id, string descr, string address, string phone)
        {
            List<Venue> venues = GetVenues();
            if (!venues.Select(elem => elem.Description).Contains(descr))
            {
                await Repository.Update(new Venue(id, descr, address, phone));
            }
            else
            {
                throw new Exception("There is a venue with the same description");
            }
        }
    }
}
