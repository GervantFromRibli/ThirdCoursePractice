using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.DAL;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Bll class for Venue table that proxy all calls and validate data.
    /// </summary>
    internal class VenueBLL : IVenueBLL
    {
        /// <summary>
        /// Venue repository.
        /// </summary>
        protected IRepository<Venue> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VenueBLL"/> class.
        /// </summary>
        /// <param name="context"> Instance of application context. </param>
        public VenueBLL(ApplicationContext context)
        {
            Repository = new VenueRepository(context);
        }

        /// <inheritdoc cref="IVenueBLL.GetVenue(int)"/>
        public async Task<Venue> GetVenue(int id)
        {
            return await Repository.GetById(id);
        }

        /// <inheritdoc cref="IVenueBLL.DeleteVenue(int)"/>
        public async Task DeleteVenue(int id)
        {
            Venue venue = await Repository.GetById(id);
            await Repository.Delete(venue);
        }

        /// <inheritdoc cref="IVenueBLL.GetVenues"/>
        public List<Venue> GetVenues()
        {
            return Repository.GetAll().ToList();
        }

        /// <inheritdoc cref="IVenueBLL.CreateVenue(string, string, string)"/>
        public async Task CreateVenue(string descr, string address, string phone)
        {
            await Repository.Create(new Venue(descr, address, phone));
        }

        /// <inheritdoc cref="IVenueBLL.UpdateVenue(int, string, string, string)"/>
        public async Task UpdateVenue(int id, string descr, string address, string phone)
        {
            await Repository.Update(new Venue(id, descr, address, phone));
        }

        /// <inheritdoc cref="IVenueBLL.VerificationOfVenue(int, string, string, string)"/>
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
