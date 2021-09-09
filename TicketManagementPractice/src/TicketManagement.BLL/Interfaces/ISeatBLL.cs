using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.BLL
{
    /// <summary>
    /// Interface that contains the basic methods of bll-class "SeatBLL".
    /// </summary>
    public interface ISeatBLL
    {
        /// <summary>
        /// Method that returns a record from Seat table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        /// <returns> Seat record with the same id. </returns>
        public Task<Seat> GetSeat(int id);

        /// <summary>
        /// Method that delete a record from Seat table with certain id.
        /// </summary>
        /// <param name="id"> Id of record. </param>
        public Task DeleteSeat(int id);

        /// <summary>
        /// Method that returns a list of records from Seat table.
        /// </summary>
        /// <returns> List of records from Seat table. </returns>
        public List<Seat> GetSeats();

        /// <summary>
        /// Method that create a record in Seat table with certain parameters.
        /// </summary>
        /// <param name="areaId"> Id of area record. </param>
        /// <param name="row"> Row of seat. </param>
        /// <param name="number"> Number of seat. </param>
        public Task CreateSeat(int areaId, int row, int number);

        /// <summary>
        /// Method that update a record in Seat table with certain id.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="areaId"> Id of area record. </param>
        /// <param name="row"> Row of seat. </param>
        /// <param name="number"> Number of seat. </param>
        public Task UpdateSeat(int id, int areaId, int row, int number);

        /// <summary>
        /// Method that validate all data of Seat table record.
        /// </summary>
        /// <param name="id"> Id of record to update. </param>
        /// <param name="areaDescr"> Description of event area record. </param>
        /// <param name="row"> Row of seat. </param>
        /// <param name="number"> Number of seat. </param>
        /// <returns> Keyword that defines if data are valid or not. </returns>
        public string VerificationOfSeat(int id, string areaDescr, int? row, int? number);
    }
}
