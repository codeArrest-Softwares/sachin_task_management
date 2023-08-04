using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.IServices;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly IRegisterService _userService;
        private readonly IMapper _mapper;

        public RegistrationController(IRegisterService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users= _mapper.Map<List<UserDto>>(_userService.GetAllUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);

        }

        [HttpGet("{userId}")]
        public IActionResult GetUserbyId(Guid userId)
        {
            if (!_userService.UserExists(userId))
                return NotFound();

            var user= _mapper.Map<UserDto>(_userService.GetUserbyId(userId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);

        }
        [HttpPost]
        public IActionResult CreateUser( [FromBody] UserDto userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

   

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);


            _userService.CreateUser(userMap);
         

            return Ok("Successfully created");
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(Guid userId,[FromBody] UserDto updatedUser)
        {
            if (updatedUser == null)
                return BadRequest(ModelState);

            if (userId != updatedUser.Id)
                return BadRequest(ModelState);

            if (!_userService.UserExists(userId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var userMap = _mapper.Map<User>(updatedUser);

            if (!_userService.UpdateUser(userId,userMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(Guid userId)
        {
            if (!_userService.UserExists(userId))
            {
                return NotFound();
            }

      var userToDelete =_userService.GetUserbyId(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userService.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

    }
}
