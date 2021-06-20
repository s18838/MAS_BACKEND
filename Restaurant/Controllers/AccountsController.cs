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
    /// Accounts controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {

        private IAuthService _authService;

        /// <summary>
        /// AccountsController constructor
        /// </summary>
        public AccountsController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authorize method
        /// </summary>
        [HttpPost("authorize")]
        public IActionResult Authorize([FromBody] AccountDTO accountDTO)
        {
            try
            {
                return Ok(_authService.Login(accountDTO));
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        /// <summary>
        /// Create account method
        /// </summary>
        [HttpPost("create")]
        public IActionResult Create([FromBody] AccountDTO accountDTO)
        {
            try
            {
                _authService.CreateAccount(accountDTO);
                return Ok(accountDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message});
            }
        }
    }
}
