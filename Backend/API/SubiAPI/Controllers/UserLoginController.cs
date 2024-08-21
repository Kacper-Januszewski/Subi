using Npgsql;
using Microsoft.AspNetCore.Mvc;
using SubiAPI.DTOs;
using SubiAPI.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
        public async Task<IActionResult> GetAllUsers()
        {
            var response = new List<GetUsersResponse>();

            try
            {
                // Create and open the connection asynchronously
                await using (var npgsqlConnection = new NpgsqlConnection(_configuration.GetConnectionString("Default")))
                {
                    await npgsqlConnection.OpenAsync();

                    // Use parameterized queries to avoid SQL injection
                    var npgsqlCommand = new NpgsqlCommand("SELECT * FROM \"User\"", npgsqlConnection);

                    // Execute the query asynchronously
                    await using (var reader = await npgsqlCommand.ExecuteReaderAsync())
                    {
                        // Read the data asynchronously
                        while (await reader.ReadAsync())
                        {
                            response.Add(new GetUsersResponse(
                                reader.GetInt32(0),   // Assuming first column is an integer (User ID)
                                reader.GetString(1),  // Assuming second column is a string (Username)
                                reader.GetString(2)   // Assuming third column is a string (Other field)
                            ));
                        }
                    }
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (logging is recommended in real-world scenarios)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
