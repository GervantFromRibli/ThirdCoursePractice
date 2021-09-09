using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Interface that contains the basic methods of bll-class "EventSeatBLL".
    /// </summary>
    public interface IEventSeatBLL
    {
        /// <summary>
        /// Method that returns a record from Event Seat table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        /// <returns> Event Seat record with the same id. </returns>
        public Task<EventSeat> GetEventSeat(int id);

        /// <summary>
        /// Method that delete a record from Event Seat table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        public Task DeleteEventSeat(int id);

        /// <summary>
        /// Method that returns a list of records from Event Seat table.
        /// </summary>
        /// <returns> List of records from Event Seat table. </returns>
        public List<EventSeat> GetEventSeats();

        /// <summary>
        /// Method that create a record in Event Seat table with certain parameters.
        /// </summary>
        /// <param name="eventAreaId"> Id of event area record. </param>
        /// <param name="row"> Row of seat. </param>
        /// <param name="number"> Number of seat. </param>
        /// <param name="state"> State of seat. </param>
        public Task CreateEventSeat(int eventAreaId, int row, int number, string state);

        /// <summary>
        /// Method that update a record in Event Seat table with certain id.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="eventAreaId"> Id of event area record. </param>
        /// <param name="row"> Row of seat. </param>
        /// <param name="number"> Number of seat. </param>
        /// <param name="state"> State of seat. </param>
        public Task UpdateEventSeat(int id, int eventAreaId, int row, int number, string state);

        /// <summary>
        /// Method that validate all data of Event Seat table record.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="eventAreaId"> Id of event area record. </param>
        /// <param name="row"> Row of seat. </param>
        /// <param name="number"> Number of seat. </param>
        /// <param name="state"> State of seat. </param>
        /// <returns> Keyword that defines if data are valid or not. </returns>
        public string VerificationOfEventSeat(int id, int? row, int? number, string state, int eventAreaId);
    }
}
