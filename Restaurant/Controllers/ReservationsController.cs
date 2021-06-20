using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    /// <summary>
    /// Reservations controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private IReservationDbService _reservationDbService;

        /// <summary>
        /// ReservationsController constructor
        /// </summary>
        public ReservationsController(IReservationDbService reservationDbService)
        {
            _reservationDbService = reservationDbService;
        }

        /// <summary>
        /// Checks if date is free for room
        /// </summary>
        /// <param name="reservationDateDTO">Date and room to check</param>
        /// <response code="200">If date is free</response>
        /// <response code="400">If date is reserved</response> 
        /// <response code="401">Unauthorized</response>
        [HttpPost("check")]
        [Authorize(Roles = "Client")]
        public IActionResult Check([FromBody] ReservationDateDTO reservationDateDTO)
        {
            if (_reservationDbService.Check(reservationDateDTO))
            {
                return Ok(reservationDateDTO);
            }
            return BadRequest();
        }

        /// <summary>
        /// Create new reservation for room
        /// </summary>
        /// <param name="reservationDTO"></param>
        /// <response code="200">Reservation created</response>
        /// <response code="400">Bad request</response> 
        /// <response code="401">Unauthorized</response>
        [HttpPost()]
        [Authorize(Roles = "Client")]
        public IActionResult Create([FromBody] ReservationDTO reservationDTO)
        {
            if (_reservationDbService.Check(reservationDTO))
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string user = claim.Where(e => e.Type == ClaimTypes.Name).First().Value;
                int userId = int.Parse(user);
                _reservationDbService.Reserve(reservationDTO, userId);
                return Ok(reservationDTO);
            }
            return BadRequest();
        }


        /// <summary>
        /// Get reservated room for user
        /// </summary>
        /// <response code="200">Reservated rooms returned</response>
        /// <response code="400">Bad request</response> 
        /// <response code="401">Unauthorized</response>
        [HttpGet("rooms")]
        [Authorize(Roles = "Client")]
        public IActionResult GetRooms()
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string user = claim.Where(e => e.Type == ClaimTypes.Name).First().Value;
                int userId = int.Parse(user);
                return Ok(_reservationDbService.GetReservedRooms(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
