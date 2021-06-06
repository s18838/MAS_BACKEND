using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class RoomDbService : IRoomDbService
    {
        private readonly RestaurantContext _restaurantContext;

        public RoomDbService(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public ICollection<PartyRoom> GetPartyRooms()
        {
            return _restaurantContext.PartyRooms
                .Include(e => e.Tables)
                .ToList();
        }
    }
}
