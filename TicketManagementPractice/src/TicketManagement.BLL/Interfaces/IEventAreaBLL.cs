using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Interface that contains the basic methods of bll-class "EventAreaBLL".
    /// </summary>
    public interface IEventAreaBLL
    {
        /// <summary>
        /// Method that returns a record from Event Area table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        /// <returns> Event Area record with the same id. </returns>
        public Task<EventArea> GetEventArea(int id);

        /// <summary>
        /// Method that delete a record from Event Area table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        public Task DeleteEventArea(int id);

        /// <summary>
        /// Method that returns a list of records from Event Area table.
        /// </summary>
        /// <returns> List of records from Event Area table. </returns>
        public List<EventArea> GetEventAreas();

        /// <summary>
        /// Method that create a record in Event Area table with certain parameters.
        /// </summary>
        /// <param name="eventId"> Id of event record. </param>
        /// <param name="description"> Description of area. </param>
        /// <param name="endCoordX"> End coordinate X. </param>
        /// <param name="endCoordY"> End coordinate Y. </param>
        /// <param name="startCoordX"> Start coordinate X. </param>
        /// <param name="startCoordY"> Start coordinate Y. </param>
        /// <param name="price"> Price for each seat in area. </param>
        public Task CreateEventArea(int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price);

        /// <summary>
        /// Method that update a record in Event Area table with certain id.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="eventId"> Id of event record. </param>
        /// <param name="description"> Description of area. </param>
        /// <param name="endCoordX"> End coordinate X. </param>
        /// <param name="endCoordY"> End coordinate Y. </param>
        /// <param name="startCoordX"> Start coordinate X. </param>
        /// <param name="startCoordY"> Start coordinate Y. </param>
        /// <param name="price"> Price for each seat in area. </param>
        public Task UpdateEventArea(int id, int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price);

        /// <summary>
        /// Method that validate all parameters of Event Area record.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="eventId"> Id of event record. </param>
        /// <param name="description"> Description of area. </param>
        /// <param name="endX"> End coordinate X. </param>
        /// <param name="endY"> End coordinate Y. </param>
        /// <param name="startX"> Start coordinate X. </param>
        /// <param name="startY"> Start coordinate Y. </param>
        /// <returns> Keyword that defines if data are valid or not. </returns>
        public string VerificationOfEventArea(int id, string description, int? startX, int? startY, int? endX, int? endY, int eventId);
    }
}
