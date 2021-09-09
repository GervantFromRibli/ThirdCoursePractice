using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Interface that contains the basic methods of bll-class "AreaBLL".
    /// </summary>
    public interface IAreaBLL
    {
        /// <summary>
        /// Method that returns a record from Area table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        /// <returns> Area record with the same id. </returns>
        public Task<Area> GetArea(int id);

        /// <summary>
        /// Method that delete a record from Area table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        public Task DeleteArea(int id);

        /// <summary>
        /// Method that returns a list of records from Area table.
        /// </summary>
        /// <returns> List of records from Area table. </returns>
        public List<Area> GetAreas();

        /// <summary>
        /// Method that create a record in Area table with certain parameters.
        /// </summary>
        /// <param name="layoutId"> Id of layout record. </param>
        /// <param name="description"> Description of area. </param>
        /// <param name="endCoordX"> End coordinate X. </param>
        /// <param name="endCoordY"> End coordinate Y. </param>
        /// <param name="startCoordX"> Start coordinate X. </param>
        /// <param name="startCoordY"> Start coordinate Y. </param>
        public Task CreateArea(int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY);

        /// <summary>
        /// Method that update a record in Area table with certain id.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="layoutId"> Id of layout record. </param>
        /// <param name="description"> Description of area. </param>
        /// <param name="endCoordX"> End coordinate X. </param>
        /// <param name="endCoordY"> End coordinate Y. </param>
        /// <param name="startCoordX"> Start coordinate X. </param>
        /// <param name="startCoordY"> Start coordinate Y. </param>
        public Task UpdateArea(int id, int layoutId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY);

        /// <summary>
        /// Method that validate all parameters of Area record.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="layoutId"> Id of layout record. </param>
        /// <param name="descr"> Description of area. </param>
        /// <param name="endX"> End coordinate X. </param>
        /// <param name="endY"> End coordinate Y. </param>
        /// <param name="startX"> Start coordinate X. </param>
        /// <param name="startY"> Start coordinate Y. </param>
        /// <returns> Keyword that defines if data are valid or not. </returns>
        public string VerificationOfArea(int id, string descr, int? startX, int? startY, int? endX, int? endY, int layoutId);
    }
}
