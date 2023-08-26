using DataAccess.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Text;
using LogicalLayer;
using DataAccess.Helpers;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Modal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        public readonly AService _service;
        private readonly StudentAPIDbContext _DbContext;

        public AuthController(AService service, StudentAPIDbContext DbContext)
        {
            _service = service;
            _DbContext = DbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _service.loginRequest(userObj);

            if (user == null)
                return NotFound(new { Message = "User Not Found!" });

            if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect" });
            }

            user.Token = CreateJwt(user);

            return Ok(new 
            { 
                Token = user.Token,
                Message = "Login Success" 
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            if (await _service.RequestCheckUserNameExistAsync(userObj.UserName))
                return BadRequest(new { Message = "Username is already exist!" });

            if (await _service.RequestCheckEmailExistAsync(userObj.Email))
                return BadRequest(new { Message = "Email is already exist!" });

            var pass = _service.RequestCheckPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });

            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";

            var user = await _service.signupRequest(userObj);

            return Ok(new { Message = "User Registered!" });
        }


        [HttpGet]
        public List<User> GellAllUsers()
        {
            return _service.RequestGetAll();
        }

        private string CreateJwt(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryscerettoken.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
       
    }
}
