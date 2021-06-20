using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    /// <summary>
    /// Rooms controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private IRoomDbService _roomDbService;

        /// <summary>
        /// RoomsController constructor
        /// </summary>
        public RoomsController(IRoomDbService roomDbService)
        {
            _roomDbService = roomDbService;
        }

        /// <summary>
        /// RoomsController method
        /// </summary>
        [HttpGet]
        public IEnumerable<RoomDTO> Get()
        {
            return _roomDbService.GetPartyRooms();
        }

        /// <summary>
        /// RoomsController method
        /// </summary>
        [HttpGet("{id}/reservations")]
        [Authorize(Roles = "Client")]
        public IActionResult GetReservations(int id)
        {
            try {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string user = claim.Where(e => e.Type == ClaimTypes.Name).First().Value;
                int userId = int.Parse(user);
                return Ok(_roomDbService.GetRoomReservations(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }
    }
}
