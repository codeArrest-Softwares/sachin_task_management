using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.IServices;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _mapper.Map<List<RoleDto>>(_roleService.GetAllRoles());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(roles);

        }
        [HttpGet("{roleId}")]
        public IActionResult GetRolebyId(Guid roleId)
        {
            if (!_roleService.RoleExists(roleId))
                return NotFound();

            var user = _mapper.Map<RoleDto>(_roleService.GetRolebyId(roleId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);

        }
        [HttpPost]
        public IActionResult CreateRole([FromBody] RoleDto roleCreate)
        {
            if (roleCreate == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<Role>(roleCreate);


            _roleService.CreateRole(userMap);


            return Ok("Successfully created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRole([FromRoute] Guid id, [FromBody] RoleDto updatedRole)
        {
            bool IsValid = true;
            bool IsUpdated = false;

            if (updatedRole == null)
            {
                IsValid = false;
                ModelState.AddModelError("", "Updated permission is null");
            }

            if (IsValid &&!_roleService.RoleExists(id))
            {
                IsValid = false;
                ModelState.AddModelError("", "Role not found");
            }


            if (IsValid && !ModelState.IsValid)
            {
                IsValid = false;
            }


            var userMap = _mapper.Map<Role>(updatedRole);
            IsUpdated = _roleService.UpdateRole(id, userMap);
            if (!IsUpdated)
            {
                ModelState.AddModelError("", "Something went wrong updating ROLE");
            
            }
            if (!IsValid)
            {
                return BadRequest(ModelState);
            }
            return IsUpdated ? Ok("updated") : StatusCode(500, ModelState);

         
        }

        [HttpDelete("{roleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(Guid roleId)
        {
            if (!_roleService.RoleExists(roleId))
            {
                return NotFound();
            }

            var userToDelete = _roleService.GetRolebyId(roleId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_roleService.DeleteRole(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting ");
            }

            return NoContent();
        }

    }
}
