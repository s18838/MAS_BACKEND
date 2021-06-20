using System;
namespace Restaurant.DTO
{
    /// <summary>
    /// ReservationDate Data Transfer Object
    /// </summary>
    public class ReservationDateDTO
    {
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
    }
}
