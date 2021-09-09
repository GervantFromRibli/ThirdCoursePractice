using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Interface that contains the basic methods of bll-class "EventBLL".
    /// </summary>
    public interface IEventBLL
    {
        /// <summary>
        /// Method that returns a record from Event table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        /// <returns> Event record with the same id. </returns>
        public Task<Event> GetEvent(int id);

        /// <summary>
        /// Method that delete a record from Event table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        public Task DeleteEvent(int id);

        /// <summary>
        /// Method that returns a list of records from Event table.
        /// </summary>
        /// <returns> List of records from Event table. </returns>
        public List<Event> GetEvents();

        /// <summary>
        /// Method that create a record in Event table with certain parameters.
        /// </summary>
        /// <param name="name"> Name of event. </param>
        /// <param name="description"> Description of event. </param>
        /// <param name="layoutId"> Id of layout record. </param>
        /// <param name="startDate"> Start of period of event. </param>
        /// <param name="endDate"> End of period of event. </param>
        /// <param name="imagePath"> URL of image. </param>
        public Task CreateEvent(string name, string description, int layoutId, DateTime startDate, DateTime endDate, string imagePath);

        /// <summary>
        /// Method that update a record in Event table with certain id.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="name"> Name of event. </param>
        /// <param name="description"> Description of event. </param>
        /// <param name="layoutId"> Id of layout record. </param>
        /// <param name="startDate"> Start of period of event. </param>
        /// <param name="endDate"> End of period of event. </param>
        /// <param name="imagePath"> URL of image. </param>
        public Task UpdateEvent(int id, string name, string description, int layoutId, DateTime startDate, DateTime endDate, string imagePath);

        /// <summary>
        /// Method that validate all data of Event table record.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="name"> Name of event. </param>
        /// <param name="description"> Description of event. </param>
        /// <param name="layoutId"> Id of layout record. </param>
        /// <param name="startDate"> Start of period of event. </param>
        /// <param name="endDate"> End of period of event. </param>
        /// <returns> Keyword that defines if data are valid or not. </returns>
        public string VerificationOfEvent(int id, string name, string description, DateTime startDate, DateTime endDate, int layoutId);
    }
}
