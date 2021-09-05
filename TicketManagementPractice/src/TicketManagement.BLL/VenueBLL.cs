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
            await Repository.Create(new Venue(descr, address, phone));
        }

        public async Task UpdateVenue(int id, string descr, string address, string phone)
        {
            await Repository.Update(new Venue(id, descr, address, phone));
        }

        public string VerificationOfVenue(int id, string description, string address, string phone)
        {
            var addrs = GetVenues().Where(elem => elem.Id != id).Select(elem => elem.Address);
            var descrs = GetVenues().Where(elem => elem.Id != id).Select(elem => elem.Description);
            if (address == null || description == null || phone == null)
            {
                return "NoValues";
            }
            if (addrs.Contains(address) || address.Length == 0 || address.Length > 60)
            {
                return "WrongAddr";
            }
            if (description.Length == 0 || description.Length > 100 || descrs.Contains(description))
            {
                return "WrongDescr";
            }
            if (phone.Length < 5 || phone.Length > 15)
            {
                return "WrongPhone";
            }
            return "Ok";
        }
    }
}
