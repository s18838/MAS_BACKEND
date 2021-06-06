using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class PartyRoom : Room
    {
        public ICollection<RoomReservation> RoomReservations { get; set; }

        public PartyRoom()
        {
            RoomReservations = new HashSet<RoomReservation>();
        }

        public PartyRoom(Room room) : base(room)
        {
            RoomReservations = new HashSet<RoomReservation>();
        }

        public void AddRoomReservation(RoomReservation roomReservation)
        {
            if (!RoomReservations.Contains(roomReservation))
            {
                RoomReservations.Add(roomReservation);
                roomReservation.PartyRoom = this;
            }
        }
    }
}
