namespace TicketManagement.Models
{
    /// <summary>
    /// Класс, представляющий модель записи
    /// в таблице "Билет"
    /// </summary>
    public class Ticket
    {
        public Ticket(int id, int eventSeatId, string userId)
        {
            Id = id;
            EventSeatId = eventSeatId;
            UserId = userId;
        }

        /// <summary>
        /// Свойство, представляющее столбец "Id"
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Id места события"
        /// и являющееся внешним ключом
        /// </summary>
        public int EventSeatId { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Id пользователя"
        /// и являющееся внешним ключом
        /// </summary>
        public string UserId { get; set; }
    }
}
