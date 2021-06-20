using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurant.DTO;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class ReservationDbService : IReservationDbService
    {
        private readonly RestaurantContext _restaurantContext;

        public ReservationDbService(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public bool Check(ReservationDateDTO reservationDateDTO)
        {
            if (reservationDateDTO.Date < DateTime.Now) { return false; }
            return _restaurantContext.RoomReservations.Where(e =>
                e.PartyRoomId == reservationDateDTO.RoomId &&
                e.ReservationDate == reservationDateDTO.Date
            ).Count() == 0;
        }

        public bool Check(ReservationDTO reservationDTO)
        {
            if (reservationDTO.Date < DateTime.Now) { return false; }
            return _restaurantContext.RoomReservations.Where(e =>
                e.PartyRoomId == reservationDTO.RoomId &&
                e.ReservationDate == reservationDTO.Date
            ).Count() == 0;
        }

        public void Reserve(ReservationDTO reservationDTO, int userId)
        {
            _restaurantContext.RoomReservations.Add(new RoomReservation()
            {
                PersonCount = reservationDTO.PersonCount,
                ReservationDate = reservationDTO.Date,
                PartyRoomId = reservationDTO.RoomId,
                ClientId = userId,
                Status = ReservationStatus.Active
            });
            _restaurantContext.SaveChanges();
        }

        public ICollection<RoomDTO> GetReservedRooms(int userId)
        {
            return _restaurantContext.PartyRooms
                .Where(e => e.RoomReservations
                    .Where(e => e.ClientId == userId)
                    .Any()
                ).Include(e => e.Tables)
                .Select(e => new RoomDTO() {
                    Id = e.Id,
                    Level = e.Level,
                    Image = e.Image,
                    TableCount = e.Tables.Count
                }).ToList();
        }
    }
}
