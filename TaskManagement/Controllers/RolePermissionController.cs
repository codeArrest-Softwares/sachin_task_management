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
            bool IsValid = true;
            bool updatedrole = false;

            if (updatedRolePermission == null)
            {
                IsValid = false;
            }
                

            if (IsValid &&!_rolePermissionService.RolePermissionExist(id))
            {
                ModelState.AddModelError(" ", "ID NOT FOUND");

            }

               

            if (IsValid &&!ModelState.IsValid)
            {
                IsValid=false;
            }


            updatedrole = _rolePermissionService.UpdateRolePermission(id, updatedRolePermission);

            if (!updatedrole)
            {  

                ModelState.AddModelError("", "Something went wrong while updating ");
             
            }

            if (!IsValid)
            {
                return BadRequest(ModelState);
            }
            return updatedrole ? Ok("updated") : StatusCode(500, ModelState);


           
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
