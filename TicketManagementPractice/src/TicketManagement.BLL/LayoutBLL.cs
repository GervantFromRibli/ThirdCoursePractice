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
            return Repository.GetAll().ToList();
        }

        public async Task CreateLayout(int venueId, string description)
        {
            List<Layout> layouts = GetLayouts();
            if (layouts.Count() == 0)
            {
                await Repository.Create(new Layout(1, venueId, description));
            }
            else
            {
                int id = layouts.Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new Layout(id, venueId, description));
            }
        }

        public async Task UpdateLayout(int id, int venueId, string description)
        {
            await Repository.Update(new Layout(id, venueId, description));
        }

        public string VerificationOfLayout(int id, string description)
        {
            var layout = GetLayout(id).Result;
            var descrs = GetLayouts().Where(elem => elem.VenueId == layout.VenueId && elem.Id != id).Select(elem => elem.Description);
            if (description == null)
            {
                return "NoValue";
            }
            if (description.Length == 0 || description.Length > 100 || descrs.Contains(description))
            {
                return "WrongDescr";
            }
            return "Ok";
        }
    }
}
