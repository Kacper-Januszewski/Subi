using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using SubiAPI.DTOs;
using Microsoft.Extensions.Configuration;

namespace SubiAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {

        // This uses connectionstring from appsettings I think
        private readonly IConfiguration _configuration;
        public UserLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers([FromQuery] string orderBy = "Username")
        {
            var response = new List<GetUsersResponse>();

            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("Default"))) ;
        }
    }
}
