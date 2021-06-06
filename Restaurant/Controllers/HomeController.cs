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
    public class HomeController : ControllerBase
    {

        private IHomeDbService _homeDbService;

        public HomeController(IHomeDbService homeDbService)
        {
            _homeDbService = homeDbService;
        }

        [HttpGet]
        public IEnumerable<NewsDTO> Get()
        {
            return _homeDbService.GetNews();
        }
    }
}
