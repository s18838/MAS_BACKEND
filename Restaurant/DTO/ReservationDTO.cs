using System;
namespace Restaurant.DTO
{
    public class ReservationDTO
    {
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public int PersonCount { get; set; }
    }
}
