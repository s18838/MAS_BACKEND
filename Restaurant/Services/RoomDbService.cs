using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurant.DTO;
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

        public ICollection<RoomDTO> GetPartyRooms()
        {
            return _restaurantContext.PartyRooms
                .Include(e => e.Tables)
                .Select(e => new RoomDTO() {
                    Id = e.Id,
                    Level = e.Level,
                    Image = e.Image,
                    TableCount = e.Tables.Count
                }).ToList();
        }

        public ICollection<RoomReservation> GetRoomReservations(int id, int userId)
        {
            PartyRoom room = _restaurantContext.PartyRooms
                .Include(e => e.RoomReservations.Where(e => e.ClientId == userId)
                    .OrderByDescending(e => e.ReservationDate)
                )
                .Where(e => e.Id == id).FirstOrDefault();

            if (room == null)
            {
                return new List<RoomReservation>();
            }

            return room.RoomReservations;
        }
    }
}
