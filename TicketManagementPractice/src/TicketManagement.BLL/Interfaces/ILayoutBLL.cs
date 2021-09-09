using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Interface that contains the basic methods of bll-class "LayoutBLL".
    /// </summary>
    public interface ILayoutBLL
    {
        /// <summary>
        /// Method that returns a record from Layout table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        /// <returns> Layout record with the same id. </returns>
        public Task<Layout> GetLayout(int id);

        /// <summary>
        /// Method that delete a record from Layout table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        public Task DeleteLayout(int id);

        /// <summary>
        /// Method that returns a list of records from Layout table.
        /// </summary>
        /// <returns> List of records from Layout table. </returns>
        public List<Layout> GetLayouts();

        /// <summary>
        /// Method that create a record in Layout table with certain parameters.
        /// </summary>
        /// <param name="venueId"> Id of venue record. </param>
        /// <param name="description"> Description of layout. </param>
        public Task CreateLayout(int venueId, string description);

        /// <summary>
        /// Method that update a record in Layout table with certain id.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="venueId"> Id of venue record. </param>
        /// <param name="description"> Description of layout. </param>
        public Task UpdateLayout(int id, int venueId, string description);

        /// <summary>
        /// Method that validate all data of Layout table record.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="venueId"> Id of venue record. </param>
        /// <param name="description"> Description of layout. </param>
        /// <returns> Keyword that defines if data are valid or not. </returns>
        public string VerificationOfLayout(int id, string description, int venueId);
    }
}
