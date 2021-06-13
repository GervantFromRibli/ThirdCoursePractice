namespace TicketManagement.Models
{
    /// <summary>
    /// Класс, представляющий модель записи
    /// в таблице "Зона события"
    /// </summary>
    public class EventArea
    {
        public EventArea(int id, int eventId, string description, int startCoordX, int startCoordY, int endCoordX, int endCoordY, decimal price)
        {
            Id = id;
            EventId = eventId;
            Description = description;
            StartCoordX = startCoordX;
            StartCoordY = startCoordY;
            EndCoordX = endCoordX;
            EndCoordY = endCoordY;
            Price = price;
        }

        /// <summary>
        /// Свойство, представляющее столбец "Id"
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Id события"
        /// и являющееся внешним ключом
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Описание"
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Начальная координата X"
        /// </summary>
        public int StartCoordX { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Начальная координата Y"
        /// </summary>
        public int StartCoordY { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Конечная координата X"
        /// </summary>
        public int EndCoordX { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Конечная координата Y"
        /// </summary>
        public int EndCoordY { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Цена"
        /// </summary>
        public decimal Price { get; set; }
    }
}
