using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO;
using Restaurant.Models;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {

        private IRoomDbService _roomDbService;

        public RoomsController(IRoomDbService roomDbService)
        {
            _roomDbService = roomDbService;
        }

        [HttpGet]
        public IEnumerable<RoomDTO> Get()
        {
            return _roomDbService.GetPartyRooms()
                .Select(e => new RoomDTO() {
                    Id = e.Id,
                    Level = e.Level,
                    Image = e.Image,
                    TableCount = e.Tables.Count
                });
        }
    }
}
