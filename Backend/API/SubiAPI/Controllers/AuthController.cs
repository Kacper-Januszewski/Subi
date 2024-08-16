// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using SubiAPI.Classes;
using SubiAPI.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Replace this with your actual authentication logic
            if (AuthenticateUser(model.Username, model.Password))
            {
                // Generate a JWT token
                var token = GenerateJwtToken(model.Username);

                // Return the token to the client
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid login attempt.");
        }
        return BadRequest("Invalid request.");
    }

    private bool AuthenticateUser(string username, string password)
    {
        // Implement your authentication logic here
        // For example, check against a database or a list of users
        return username == "admin" && password == "password"; // Example condition
    }

    private string GenerateJwtToken(string username)
    {
        // Implement JWT token generation logic here
        // You can use a library like System.IdentityModel.Tokens.Jwt
        return "your-jwt-token"; // Replace this with actual token generation
    }
}
