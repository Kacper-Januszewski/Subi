using Microsoft.EntityFrameworkCore;
using SubiAPI.Models;

namespace SubiAPI.Services
{
    public class AuthService
    {
        private readonly UserContext _context;

        public AuthService(UserContext context)
        {
            _context = context;
        }

        //this method gets the id of user where the username from input equals username in database and checks if credentials are ok. if they are it returns true
        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            var user = await _context.User
                .Where(u => u.username == username)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return false;
            }

            // Add hashing and secure comparison here
            return user.username == username && user.password == password;
        }

        //this is template method, but might be useful later
        public bool UserExists(int id)
        {
            return _context.User.Any(e => e.id == id);
        }
    }

}
