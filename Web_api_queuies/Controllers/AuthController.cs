using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clean.Core.Data;
using Clean.Core.Entities;
using Clean.Core.DTOs; // ודאי שהקובץ UserRegisterDto נמצא בתיקייה זו
using Web_api_queuies.Models;

namespace TipatCholAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // --- 1. הרשמה (Register) ---
        // משתמש ב-UserRegisterDto כדי להציג רק UserName, Password, Email
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            // בדיקה אם המשתמש כבר קיים
            if (await _context.Users.AnyAsync(u => u.UserName == registerDto.UserName))
                return BadRequest(new { message = "User already exists." });

            // יצירת ישות המשתמש מהנתונים שהתקבלו ב-DTO
            var newUser = new User
            {
                UserName = registerDto.UserName,
                Password = registerDto.Password,
                Email = registerDto.Email,
                Role = "User" // הגדרת תפקיד ברירת מחדל באופן פנימי
            };

            // שמירת המשתמש החדש בבסיס הנתונים
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // הפקת טוקן עבור המשתמש שנרשם
            var token = GenerateJwtToken(newUser);

            return Ok(new
            {
                message = "User registered successfully!",
                token = token
            });
        }

        // --- 2. התחברות (Login) ---
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            // בדיקה מול בסיס הנתונים
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.UserName == loginModel.UserName && u.Password == loginModel.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid username or password." });

            // הפקת טוקן למשתמש קיים
            var token = GenerateJwtToken(user);

            return Ok(new { token = token });
        }

        // --- פונקציית עזר ליצירת ה-JWT ---
        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role ?? "User"),
                new Claim("UserId", user.Id.ToString())
            };

            var keyString = _configuration["Jwt:Key"] ?? "DefaultSuperSecretKey1234567890";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}