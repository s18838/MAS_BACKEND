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
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private IReservationDbService _reservationDbService;

        public ReservationsController(IReservationDbService reservationDbService)
        {
            _reservationDbService = reservationDbService;
        }

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

        [HttpPost()]
        [Authorize(Roles = "Client")]
        public IActionResult Post([FromBody] ReservationDTO reservationDTO)
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
    }
}
