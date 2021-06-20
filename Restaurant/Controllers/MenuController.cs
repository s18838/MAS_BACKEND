using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO;
using Restaurant.Models;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    /// <summary>
    /// Menu controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private IMenuDbService _menuDbService;

        /// <summary>
        /// MenuController construtor
        /// </summary>
        public MenuController(IMenuDbService menuDbService)
        {
            _menuDbService = menuDbService;
        }

        /// <summary>
        /// MenuController method
        /// </summary>
        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return _menuDbService.GetMenu();
        }
    }
}
