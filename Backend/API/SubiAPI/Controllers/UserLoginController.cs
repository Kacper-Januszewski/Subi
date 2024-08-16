using Npgsql;
using Microsoft.AspNetCore.Mvc;
using SubiAPI.DTOs;

namespace SubiAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var response = new List<GetUsersResponse>();

            // Replace SqlConnection with NpgsqlConnection
            using (var npgsqlConnection = new NpgsqlConnection(_configuration.GetConnectionString("Default")))
            {
                // Use NpgsqlCommand instead of SqlCommand
                var npgsqlCommand = new NpgsqlCommand($"SELECT * FROM \"User\"", npgsqlConnection);
                npgsqlCommand.Connection.Open();
                var reader = npgsqlCommand.ExecuteReader();

                // Read the data using NpgsqlDataReader
                while (reader.Read())
                {
                    response.Add(new GetUsersResponse(
                        reader.GetInt32(0),   // Assuming first column is an integer (User ID)
                        reader.GetString(1),  // Assuming second column is a string (Username)
                        reader.GetString(2)   // Assuming third column is a string (Other field)
                    ));
                }
            }
            return Ok(response);
        }
    }
}
