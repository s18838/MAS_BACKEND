using System;
using System.Collections.Generic;
using Restaurant.DTO;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IRoomDbService
    {
        public ICollection<RoomDTO> GetPartyRooms();
        public ICollection<RoomReservation> GetRoomReservations(int id, int userId);
    }
}
