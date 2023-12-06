using Microsoft.AspNetCore.Mvc;
using TFTDirecting.Commands;
using TFTDirecting.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFTDirecting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[Actor]
        [HttpGet("{actorId}")] // 2. Glumac; a. Pregled vlastitih podataka
        public IActionResult GetUserData(int actorId)
        {
            return Ok(_userService.GetUserData(actorId));
        }

        //[SuperAdmin]
        [HttpPost()] 
        public IActionResult Post([FromBody] AddUserCommand command)
        {
            _userService.AddUser(command);
            return Ok();
        }

        //[Actor]
        [HttpPut("{actorId}")] // 2. Glumac; b. Ažuriranje vlastitih podataka
        public IActionResult Put(int actorId, [FromBody] UpdateUserCommand command)
        {
            _userService.UpdateUserData(actorId, command);
            return Ok();
        }
    }
}
