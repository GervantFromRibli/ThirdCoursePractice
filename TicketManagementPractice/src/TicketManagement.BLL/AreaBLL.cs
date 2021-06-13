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
    internal class AreaBLL
    {
        protected IRepository<Area> Repository { get; set; }

        public AreaBLL(DbContext context)
        {
            Repository = new AreaRepository(context);
        }

        public async Task<Area> GetArea(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task DeleteArea(int id)
        {
            Area area = await Repository.GetById(id);
            await Repository.Delete(area);
        }

        public List<Area> GetAreas()
        {
            return Repository.GetAll() as List<Area>;
        }

        public async Task CreateArea(int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY)
        {
            List<Area> areas = GetAreas();
            if (!areas.Where(elem => elem.LayoutId == layoutId).Select(elem => elem.Description).Contains(description))
            {
                int id = areas.Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new Area(id, layoutId, description, startCoordX, startCoordY, endCoordX, endCoordY));
            }
            else
            {
                throw new Exception("There is an area with the same description");
            }
        }

        public async Task UpdateArea(int id, int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY)
        {
            List<Area> areas = GetAreas();
            if (!areas.Where(elem => elem.LayoutId == layoutId).Select(elem => elem.Description).Contains(description))
            {
                await Repository.Update(new Area(id, layoutId, description, startCoordX, startCoordY, endCoordX, endCoordY));
            }
            else
            {
                throw new Exception("There is an area with the same description");
            }
        }
    }
}
