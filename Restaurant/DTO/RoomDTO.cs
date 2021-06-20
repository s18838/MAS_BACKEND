using System;
namespace Restaurant.DTO
{
    /// <summary>
    /// Room Data Transfer Object
    /// </summary>
    public class RoomDTO
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int TableCount { get; set; }
        public string Image { get; set; }
    }
}
