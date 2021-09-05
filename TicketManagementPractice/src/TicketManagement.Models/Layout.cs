namespace TicketManagement.Models
{
    /// <summary>
    /// Класс, представляющий модель записи
    /// в таблице "Слой"
    /// </summary>
    public class Layout
    {
        public Layout() { }
        public Layout(int venueId, string description)
        {
            VenueId = venueId;
            Description = description;
        }
        public Layout(int id, int venueId, string description)
        {
            Id = id;
            VenueId = venueId;
            Description = description;
        }

        /// <summary>
        /// Свойство, представляющее столбец "Id"
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Id места проведения"
        /// и являющееся внешним ключом
        /// </summary>
        public int VenueId { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Описание"
        /// </summary>
        public string Description { get; set; }
    }
}
