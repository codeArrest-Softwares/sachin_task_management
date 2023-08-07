using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.IServices;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleService userRoleService, IMapper mapper)
        {
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserRolebyId(Guid id)
        {
            if (!_userRoleService.UserRoleExist(id))
                return Ok("Role doesnt exist for this user");

            var user = _userRoleService.GetUserRolebyId(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult CreateUserRole([FromBody] UserRoleDto userRoleDto)
        {
            if (userRoleDto == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          


            _userRoleService.CreateUserRole(userRoleDto);


            return Ok("Successfully created");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRolePermission([FromRoute] Guid id, [FromBody] UserRoleDto userRoleDto)
        {
            bool IsValid = true;
          bool  updateduserRole = false;

            if (userRoleDto == null)
            {
                IsValid = false;
            }
               


            if (IsValid &&!_userRoleService.UserRoleExist(id))
            {

                IsValid = false;
                ModelState.AddModelError("", "Roleperm not found");
            }
               

            if (IsValid && !ModelState.IsValid)
            {
                IsValid=false;
            }

            updateduserRole = _userRoleService.UpdateUserRole(id, userRoleDto);

            if (!updateduserRole)
            {
                ModelState.AddModelError("", "Something went wrong while updating ");

            }
            if (!IsValid)
            {
                return BadRequest(ModelState);
            }

            return updateduserRole ? Ok("updated") : StatusCode(500, ModelState);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteUserRole(Guid Id)
        {
            if (!_userRoleService.UserRoleExist(Id))
            {
                return Ok("Id not found!");
            }

           

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRoleService.DeleteUserRole(Id))
            {
                return Ok("Role can't be deleted because it has some permissions");
            }

            return Ok("Deleted");
        }

    }
}
