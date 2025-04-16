using CustomClothing.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CustomClothingApp.Server.Models;
namespace CustomClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CustomClothingDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthController(CustomClothingDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Имя пользователя и пароль обязательны.");
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            if (user == null || user.PasswordHash != loginDto.Password) // Прямое сравнение пароля
            {
                return Unauthorized("Неверное имя пользователя или пароль.");
            }
            var token = GenerateJwtToken(user);
            var response = new UserResponseDto
            {
                UserId = user.Userid,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Userrole = user.Userrole,
                Createddate = user.Createddate ?? DateTime.UtcNow
            };
            return Ok(new { token, user = response });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == registerDto.Username || u.Email == registerDto.Email);
            if (existingUser != null)
            {
                return BadRequest("Пользователь с таким именем или email уже существует.");
            }
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = registerDto.Password,
                Createddate = DateTime.UtcNow,
                Userrole = "user"
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var token = GenerateJwtToken(user);
            var response = new UserResponseDto
            {
                UserId = user.Userid,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Userrole = user.Userrole,
                Createddate = user.Createddate ?? DateTime.UtcNow
            };
            return Ok(new { token, user = response });
        }
        private string GenerateJwtToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("UserId", user.Userid.ToString()),
                new Claim("Userrole", user.Userrole ?? "")
            };
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
