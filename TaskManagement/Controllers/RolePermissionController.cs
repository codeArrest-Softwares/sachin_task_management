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
    public class RolePermissionController : Controller
    {
        private readonly IRolePermissionService _rolePermissionService;
        private readonly IMapper _mapper;

        public RolePermissionController(IRolePermissionService rolePermissionService,IMapper mapper)
        {
            _rolePermissionService = rolePermissionService;
            _mapper = mapper;
        }

        [HttpGet("{roleId}")]
        public IActionResult GetRolePermissionById(Guid roleId)
        {
            if (!_rolePermissionService.RolePermissionExist(roleId))
                return Ok("Permission is not assigned");

            var user = _mapper.Map<RolePermissionDto>(_rolePermissionService.GetRolePermissionById(roleId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult CreateRolePermission([FromBody] RolePermissionDto rolepermissionCreate)
        {
            if (rolepermissionCreate == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          //  var userMap = _mapper.Map<RolePermission>(rolepermissionCreate);


            _rolePermissionService.CreateRolePermission(rolepermissionCreate);


            return Ok("Successfully created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRolePermission([FromRoute] Guid id, [FromBody] RolePermissionDto updatedRolePermission)
        {

            if (updatedRolePermission == null)
                return BadRequest(ModelState);

            //if (id != updatedRolePermission.RoleId)
            //    return BadRequest(ModelState);

            if (!_rolePermissionService.RolePermissionExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

         //  var userMap = _mapper.Map<Role>(updatedRolePermission);

            if (!_rolePermissionService.UpdateRolePermission(id, updatedRolePermission))
            {
                ModelState.AddModelError("", "Something went wrong while updating ");
                return StatusCode(500, ModelState);
            }

            return Ok("updated Successfully");
        }

        [HttpDelete("{roleId}")]
        public IActionResult DeleteRolePermision(Guid roleId)
        {
            if (!_rolePermissionService.RolePermissionExist(roleId))
            {
                return Ok("Id not found!");
            }

          //  var userToDelete = _rolePermissionService.GetRolePermissionById(roleId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_rolePermissionService.DeleteRolePermission(roleId))
            {
                 return Ok("We can't Delete Role, assigned Some Permissions");
            }

            return Ok("Deleted");
        }



    }
}
