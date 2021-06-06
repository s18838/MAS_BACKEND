using System;
namespace Restaurant.Models
{
    public class StandardRoom : Room
    {
        public StandardRoom() { }

        public StandardRoom(Room room): base(room) { }
    }
}
