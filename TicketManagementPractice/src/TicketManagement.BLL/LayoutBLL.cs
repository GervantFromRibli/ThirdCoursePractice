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
    internal class LayoutBLL : ILayoutBLL
    {
        protected IRepository<Layout> Repository { get; set; }

        public LayoutBLL(DbContext context)
        {
            Repository = new LayoutRepository(context);
        }

        public async Task<Layout> GetLayout(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task DeleteLayout(int id)
        {
            Layout layout = await Repository.GetById(id);
            await Repository.Delete(layout);
        }

        public List<Layout> GetLayouts()
        {
            return Repository.GetAll() as List<Layout>;
        }

        public async Task CreateLayout(int venueId, string description)
        {
            List<Layout> layouts = GetLayouts();
            if (!layouts.Where(elem => elem.VenueId == venueId).Select(elem => elem.Description).Contains(description))
            {
                int id = layouts.Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new Layout(id, venueId, description));
            }
            else
            {
                throw new Exception("There is a layout with the same description");
            }
        }

        public async Task UpdateLayout(int id, int venueId, string description)
        {
            List<Layout> layouts = GetLayouts();
            if (!layouts.Where(elem => elem.VenueId == venueId).Select(elem => elem.Description).Contains(description))
            {
                await Repository.Update(new Layout(id, venueId, description));
            }
            else
            {
                throw new Exception("There is a layout with the same description");
            }
        }
    }
}
