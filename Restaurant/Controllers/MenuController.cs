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
    public class MenuController : ControllerBase
    {

        private IMenuDbService _menuDbService;

        public MenuController(IMenuDbService menuDbService)
        {
            _menuDbService = menuDbService;
        }

        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return _menuDbService.GetMenu();
        }
    }
}
