using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Table
    {
        public Table()
        {
            TableReservations = new HashSet<TableReservation>();
        }

        public int Id { get; set; }
        public int NumberOfSeats { get; set; }
        public int RoomId { get; set; }
        private Room room;
        public Room Room {
            get => room;
            set
            {
                if (room == value) return;
                room = value;
                value.AddTable(this);
            } 
        }
        public ICollection<TableReservation> TableReservations { get; set; }

        public void AddTableReservation(TableReservation tableReservation)
        {
            if (!TableReservations.Contains(tableReservation))
            {
                TableReservations.Add(tableReservation);
                tableReservation.Table = this;
            }
        } 
    }
}
