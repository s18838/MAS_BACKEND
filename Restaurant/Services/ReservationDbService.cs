using System;
using System.Linq;
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
            return _restaurantContext.RoomReservations.Where(e =>
                e.PartyRoomId == reservationDateDTO.RoomId &&
                e.ReservationDate == reservationDateDTO.Date
            ).Count() == 0;
        }

        public bool Check(ReservationDTO reservationDTO)
        {
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
    }
}
