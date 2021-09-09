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
    /// Bll class for Layout table that proxy all calls and validate data.
    /// </summary>
    internal class LayoutBLL : ILayoutBLL
    {
        /// <summary>
        /// Layout repository
        /// </summary>
        protected IRepository<Layout> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutBLL"/> class.
        /// </summary>
        /// <param name="context"> Instance of application context. </param>
        public LayoutBLL(DbContext context)
        {
            Repository = new LayoutRepository(context);
        }

        /// <inheritdoc cref="ILayoutBLL.GetLayout(int)"/>
        public async Task<Layout> GetLayout(int id)
        {
            return await Repository.GetById(id);
        }

        /// <inheritdoc cref="ILayoutBLL.DeleteLayout(int)"/>
        public async Task DeleteLayout(int id)
        {
            Layout layout = await Repository.GetById(id);
            await Repository.Delete(layout);
        }

        /// <inheritdoc cref="ILayoutBLL.GetLayouts"/>
        public List<Layout> GetLayouts()
        {
            return Repository.GetAll().ToList();
        }

        /// <inheritdoc cref="ILayoutBLL.CreateLayout(int, string)"/>
        public async Task CreateLayout(int venueId, string description)
        {
            await Repository.Create(new Layout(venueId, description));
        }

        /// <inheritdoc cref="ILayoutBLL.UpdateLayout(int, int, string)"/>
        public async Task UpdateLayout(int id, int venueId, string description)
        {
            await Repository.Update(new Layout(id, venueId, description));
        }

        /// <inheritdoc cref="ILayoutBLL.VerificationOfLayout(int, string, int)"/>
        public string VerificationOfLayout(int id, string description, int venueId)
        {
            var descrs = GetLayouts().Where(elem => elem.VenueId == venueId && elem.Id != id).Select(elem => elem.Description);
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
