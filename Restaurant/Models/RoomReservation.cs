using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public class RoomReservation : Reservation
    {
        public int PersonCount { get; set; }
        public int PartyRoomId { get; set; }
        private PartyRoom partyRoom;
        public PartyRoom PartyRoom {
            get => partyRoom;
            set
            {
                partyRoom = value;
                value.AddRoomReservation(this);
            }
        }
    }
}
