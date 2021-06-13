namespace TicketManagement.Models
{
    /// <summary>
    /// Класс, представляющий модель записи
    /// в таблице "Места проведения"
    /// </summary>
    public class Venue
    {
        public Venue() { }

        public Venue(int id, string descr, string address, string phone)
        {
            Id = id;
            Description = descr;
            Address = address;
            Phone = phone;
        }
        /// <summary>
        /// Свойство, представляющее столбец "Id"
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Описание"
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Адрес"
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Свойство, представляющее столбец "Телефон
        /// </summary>
        public string Phone { get; set; }
    }
}
