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
            bool isValid = true;
            bool isUpdated = false;

            if (updatedUser == null)
            {
                isValid = false;
                ModelState.AddModelError("", "Updated user is null");
            }

            if (isValid && !_userService.UserExists(userId))
            {
                isValid = false;
                ModelState.AddModelError("", "User not found");
            }

            if (isValid && !ModelState.IsValid)
            {
                isValid = false;
            }

            if (isValid)
            {
                var userMap = _mapper.Map<User>(updatedUser);
                isUpdated = _userService.UpdateUser(userId, userMap);

                if (!isUpdated)
                {
                    ModelState.AddModelError("", "Something went wrong while updating user");
                }
            }

            if (!isValid)
            {
                return BadRequest(ModelState);
            }

            if (!isUpdated)
            {
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
                ModelState.AddModelError("", "Something went wrong deleting user");
            }

            return NoContent();
        }

    }
}
