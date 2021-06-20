using System;
namespace Restaurant.DTO
{
    /// <summary>
    /// Reservation Data Transfer Object
    /// </summary>
    public class ReservationDTO
    {
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public int PersonCount { get; set; }
    }
}
