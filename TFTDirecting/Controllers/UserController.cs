using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.CustomAttributes;
using TFTDirecting.Database;
using TFTDirecting.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFTDirecting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _config;

        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [RoleAuthorize(Role.Actor)]
        [HttpGet("{actorId}")] // 2. Glumac; a. Pregled vlastitih podataka
        public IActionResult GetUserData(int actorId)
        {
            return Ok(_userService.GetUserData(actorId));
        }

        [RoleAuthorize(Role.SuperAdmin)]
        [HttpPost()]
        public IActionResult Post([FromBody] AddUserCommand command)
        {
            _userService.AddUser(command);
            return Ok();
        }

        [RoleAuthorize(Role.Actor)]
        [HttpPut("{actorId}")] // 2. Glumac; b. Ažuriranje vlastitih podataka
        public IActionResult Put(int actorId, [FromBody] UpdateUserCommand command)
        {
            _userService.UpdateUserData(actorId, command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginCommand login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            else
            {
                response = BadRequest();
            }

            return response;
        }

        private string GenerateJSONWebToken(UserDto userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userInfo.Role.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserDto AuthenticateUser(UserLoginCommand login)
        {
            UserDto user = _userService.GetUserByCredentials(login.UserName, login.Password);

            return user;
        }

        [AllowAnonymous]
        [HttpPost("sa")]
        public IActionResult CreateSuperAdmin()
        {
            _userService.AddUser(new AddUserCommand
            {
                Username = "admin",
                Password = "admin",
                Role = (int)Role.SuperAdmin,
                Name = "admin",
                Surname = "admin",
                Address = "admin",
                ExpectedSalary = 0
            });
            return Ok(new
            {
                token = GenerateJSONWebToken(
                    AuthenticateUser(
                        new UserLoginCommand
                        {
                            UserName = "admin",
                            Password = "admin"
                        }))
            });
            
        }
    }
}
