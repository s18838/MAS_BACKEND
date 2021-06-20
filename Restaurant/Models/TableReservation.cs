using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class TableReservation : Reservation
    {
        public int TableId { get; set; }
        private Table table;
        public Table Table {
            get => table;
            set
            {
                if (table == value) return;
                table = value;
                value.AddTableReservation(this);
            }
        }
    }
}
