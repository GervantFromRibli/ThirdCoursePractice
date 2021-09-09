using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Interface that contains the basic methods of bll-class "VenueBLL".
    /// </summary>
    public interface IVenueBLL
    {
        /// <summary>
        /// Method that returns a record from Venue table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        /// <returns> Venue record with the same id. </returns>
        public Task<Venue> GetVenue(int id);

        /// <summary>
        /// Method that delete a record from Venue table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        public Task DeleteVenue(int id);

        /// <summary>
        /// Method that returns a list of records from Venue table.
        /// </summary>
        /// <returns> List of records from Venue table. </returns>
        public List<Venue> GetVenues();

        /// <summary>
        /// Method that create a record in Venue table with certain parameters.
        /// </summary>
        /// <param name="descr"> Description of venue. </param>
        /// <param name="address"> Address of venue. </param>
        /// <param name="phone"> Phone of administration of venue. </param>
        public Task CreateVenue(string descr, string address, string phone);

        /// <summary>
        /// Method that update a record in Venue table with certain id.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="descr"> Description of venue. </param>
        /// <param name="address"> Address of venue. </param>
        /// <param name="phone"> Phone of administration of venue. </param>
        public Task UpdateVenue(int id, string descr, string address, string phone);

        /// <summary>
        /// Method that validate all data of Venue table record.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="description"> Description of venue. </param>
        /// <param name="address"> Address of venue. </param>
        /// <param name="phone"> Phone of administration of venue. </param>
        /// <returns> Keyword that defines if data are valid or not. </returns>
        public string VerificationOfVenue(int id, string description, string address, string phone);
    }
}
