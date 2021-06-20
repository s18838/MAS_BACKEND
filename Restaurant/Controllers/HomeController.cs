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
    /// Home controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private IHomeDbService _homeDbService;

        /// <summary>
        /// HomeController constructor
        /// </summary>
        public HomeController(IHomeDbService homeDbService)
        {
            _homeDbService = homeDbService;
        }

        /// <summary>
        /// HomeController method
        /// </summary>
        [HttpGet]
        public IEnumerable<NewsDTO> Get()
        {
            return _homeDbService.GetNews();
        }
    }
}
