using System;
using System.Collections.Generic;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IRoomDbService
    {
        public ICollection<PartyRoom> GetPartyRooms();
    }
}
