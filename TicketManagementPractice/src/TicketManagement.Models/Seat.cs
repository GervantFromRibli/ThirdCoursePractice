namespace TicketManagement.Models
{
    /// <summary>
    /// Класс, представляющий модель записи
    /// в таблице "Место"
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Свойство, представляющее столбец "Id"
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Id зоны"
        /// и являющееся внешним ключом
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Ряд"
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Место"
        /// </summary>
        public int Number { get; set; }
    }
}
