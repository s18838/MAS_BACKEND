using System;
using Restaurant.DTO;

namespace Restaurant.Services
{
    public interface IReservationDbService
    {
        public bool Check(ReservationDateDTO reservationDateDTO);
        public bool Check(ReservationDTO reservationDTO);
        public void Reserve(ReservationDTO reservationDTO, int userId);
    }
}
