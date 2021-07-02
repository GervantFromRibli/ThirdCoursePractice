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
    internal class AreaBLL : IAreaBLL
    {
        protected IRepository<Area> Repository { get; set; }

        public AreaBLL(ApplicationContext context)
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
            return Repository.GetAll().ToList();
        }

        public async Task CreateArea(int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY)
        {
            List<Area> areas = GetAreas();
            if (areas.Count() == 0)
            {
                await Repository.Create(new Area(1, layoutId, description, startCoordX, startCoordY, endCoordX, endCoordY));
            }
            else
            {
                int id = areas.Select(elem => elem.Id).Max() + 1;
                await Repository.Create(new Area(id, layoutId, description, startCoordX, startCoordY, endCoordX, endCoordY));
            }
        }

        public async Task UpdateArea(int id, int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY)
        {
            await Repository.Update(new Area(id, layoutId, description, startCoordX, startCoordY, endCoordX, endCoordY));
        }

        public string VerificationOfArea(int id, string descr, int? startX, int? startY, int? endX, int? endY)
        {
            var areaElem = Repository.GetById(id).Result;
            var descrs = Repository.GetAll().Where(elem => elem.LayoutId == areaElem.LayoutId && elem.Id != id).Select(elem => elem.Description);
            if (descr == null || startX == null || startY == null || endY == null || endX == null)
            {
                return "NoValue";
            }
            if (descr.Length == 0 || descr.Length > 100 || descrs.Contains(descr))
            {
                return "WrongDescr";
            }
            if (startX >= endX || startY >= endY)
            {
                return "WrongCoordStep";
            }
            foreach (var area in GetAreas() ?? new List<Area>())
            {
                if (startX > area.StartCoordX && startX < area.EndCoordX && startY > area.StartCoordY && startY < endY && area.Id != id)
                {
                    return "WrongStartCoord";
                }
                if (endX > area.StartCoordX && endX < area.EndCoordX && endY > area.StartCoordY && endY < area.EndCoordY && area.Id != id)
                {
                    return "WrongEndCoord";
                }
            }
            return "Ok";
        }
    }
}
