using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;

namespace WmBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;

        public AuthController(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        [HttpPost("register")] // , Authorize(Roles = "Admin")
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Role role = _dataContext.Roles.Find(request.RoleId);

            var user = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = role
            };

            // Add the user to the database and save the changes
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            // Return the list of users (just for demonstration purposes)
            return Ok($"User {user.Username} has been added");

        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {

            var dbUser = await _dataContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == request.Username);
            if (dbUser == null)
            {
                return BadRequest("User not found");
            }

            // If the password is incorrect
            if (!VerifyPasswordHash(dbUser, request.Password, dbUser.PasswordHash, dbUser.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }

            // If everything seems okay
            string token = CreateToken(dbUser);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(User user, string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
