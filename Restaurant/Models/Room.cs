using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public abstract class Room
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Image { get; set; }
        public ICollection<Table> Tables { get; set; }

        public Room()
        {
            Tables = new HashSet<Table>();
        }

        public Room(Room room) : this() {
            Id = room.Id;
            Level = room.Level;
            Image = room.Image;
            Tables = room.Tables;
        }

        public void AddTable(Table table)
        {
            if (!Tables.Contains(table))
            {
                Tables.Add(table);
                table.RoomId = Id;
                table.Room = this;
            }
        }
    }
}
