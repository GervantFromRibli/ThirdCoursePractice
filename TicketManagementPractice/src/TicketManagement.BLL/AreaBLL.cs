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
    /// Bll class for Area table that proxy all calls and validate data.
    /// </summary>
    internal class AreaBLL : IAreaBLL
    {
        /// <summary>
        /// Area repository.
        /// </summary>
        protected IRepository<Area> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaBLL"/> class.
        /// </summary>
        /// <param name="context"> Instance of application context. </param>
        public AreaBLL(ApplicationContext context)
        {
            Repository = new AreaRepository(context);
        }

        /// <inheritdoc cref="IAreaBLL.GetArea(int)"/>
        public async Task<Area> GetArea(int id)
        {
            return await Repository.GetById(id);
        }

        /// <inheritdoc cref="IAreaBLL.DeleteArea(int)"/>
        public async Task DeleteArea(int id)
        {
            Area area = await Repository.GetById(id);
            await Repository.Delete(area);
        }

        /// <inheritdoc cref="IAreaBLL.GetAreas"/>
        public List<Area> GetAreas()
        {
            return Repository.GetAll().ToList();
        }

        /// <inheritdoc cref="IAreaBLL.CreateArea(int, string, int, int, int, int)"/>
        public async Task CreateArea(int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY)
        {
            await Repository.Create(new Area(layoutId, description, startCoordX, startCoordY, endCoordX, endCoordY));
        }

        /// <inheritdoc cref="IAreaBLL.UpdateArea(int, int, string, int, int, int, int)"/>
        public async Task UpdateArea(int id, int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY)
        {
            await Repository.Update(new Area(id, layoutId, description, startCoordX, startCoordY, endCoordX, endCoordY));
        }

        /// <inheritdoc cref="IAreaBLL.VerificationOfArea(int, string, int?, int?, int?, int?, int)"/>
        public string VerificationOfArea(int id, string descr, int? startX, int? startY, int? endX, int? endY, int layoutId)
        {
            var descrs = Repository.GetAll().Where(elem => elem.LayoutId == layoutId && elem.Id != id).Select(elem => elem.Description);
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
