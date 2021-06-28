using System;

namespace TicketManagement.Models
{
    /// <summary>
    /// Класс, представляющий модель записи
    /// в таблице "Событие"
    /// </summary>
    public class Event
    {
        public Event(int id, string name, string description, int layoutId, DateTime startDate, DateTime endDate, string imagePath)
        {
            Id = id;
            Name = name;
            Description = description;
            LayoutId = layoutId;
            StartDate = startDate;
            EndDate = endDate;
            ImagePath = imagePath;
        }

        /// <summary>
        /// Свойство, представляющее столбец "Id"
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Название"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Описание"
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Id слоя"
        /// и являющееся внешним ключом
        /// </summary>
        public int LayoutId { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Начало события"
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Конец события"
        /// </summary>
        public DateTime EndDate { get; set; }

        public string ImagePath { get; set; }
    }
}
