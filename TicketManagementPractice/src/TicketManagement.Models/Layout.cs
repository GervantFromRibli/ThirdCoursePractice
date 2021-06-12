﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagement.Models
{
    /// <summary>
    /// Класс, представляющий модель записи
    /// в таблице "Слой"
    /// </summary>
    public class Layout
    {
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
