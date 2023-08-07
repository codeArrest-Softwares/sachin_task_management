using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.IServices;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsersFromLogin()
        {
            var users = _mapper.Map<List<LoginDto>>(_loginService.GetUsersFromLogin());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);

        }

        [HttpGet("{UserId}")]
        public IActionResult GetUserById(Guid UserId)
        {
            if (!_loginService.UserExists(UserId))
                return NotFound();



            var user = _mapper.Map<LoginDto>(_loginService.GetUserFromLogin(UserId));

             if (!ModelState.IsValid)
                return BadRequest(ModelState);

               return Ok(user);
        }



       


        [HttpPost]
        public IActionResult LoginUser([FromBody] LoginDto user)
        {

            if (user == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _loginService.UserLogin(user);
            if (result == "Invalid User")
            {
                // ModelState.AddModelError("", "Something went wrong while Login");
                // return StatusCode(500, ModelState);
                return Ok("invalid email");

            }
            return Ok(result);



        }



        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] LoginDto user)
        {



            if (user == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _loginService.UserUpdate(id, user);
            if (result == "Invalid")
            {
                ModelState.AddModelError("", "Something went wrong while Updating");
                return StatusCode(500, ModelState);
            }
            return Ok("User Update Successfully");
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {

                    if (id==null)
                return BadRequest(ModelState);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _loginService.UserDelete(id);
            if (!result)
            {
                ModelState.AddModelError("", "Something went wrong while Deleting");
                return StatusCode(500, ModelState);
            }
            return Ok("User Deleted Successfully");
        }



    }
}

    

