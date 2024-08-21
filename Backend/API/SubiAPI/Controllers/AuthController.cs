using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubiAPI.Models;
using System.ServiceModel;
using NuGet.Common;
using SubiAPI.Services;

namespace SubiAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        //this sends a POST request and uses Auth Service logic to check if username and password are correct. Then it returns Ok with auth token or Unauthorized with message.
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            bool isAuthenticated = await _authService.AuthenticateUserAsync(username, password);

            if (isAuthenticated)
            {
                //generate token
                return Ok("token");
            }
            else
            {
                return Unauthorized("Invalid username or password");
            }
        }
    }
}
