namespace TicketManagement.Models
{
    /// <summary>
    /// Класс, представляющий модель записи
    /// в таблице "Зона"
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Свойство, представляющее столбец "Id"
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Id слоя"
        /// и являющееся внешним ключом
        /// </summary>
        public int LayoutId { get; set; }

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
    }
}
