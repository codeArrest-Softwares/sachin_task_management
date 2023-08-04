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
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionService PermissionService, IMapper mapper)
        {
            _permissionService = PermissionService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPermissions()
        {
            var roles = _mapper.Map<List<PermissionDto>>(_permissionService.GetAllPermissions());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(roles);

        }
        [HttpGet("{Id}")]
        public IActionResult GetPermissionbyId(int Id)
        {
            if (!_permissionService.PermissionExists(Id))
                return NotFound();

            var user = _mapper.Map<PermissionDto>(_permissionService.GetPermissionbyId(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);

        }
        [HttpPost]
        public IActionResult CreatePermission([FromBody] PermissionDto permissionCreate)
        {
            if (permissionCreate == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<Permission>(permissionCreate);


            _permissionService.CreatePermission(userMap);


            return Ok("Successfully created");
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePermission([FromRoute] int id, [FromBody] PermissionDto updatedPermission)
        {

            if (updatedPermission == null)
                return BadRequest(ModelState);

            if (id != updatedPermission.PermissionId)
                return BadRequest(ModelState);

            if (!_permissionService.PermissionExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var userMap = _mapper.Map<Permission>(updatedPermission);

            if (!_permissionService.UpdatePermission(id, userMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

            [HttpDelete("{Id}")]
            [ProducesResponseType(400)]
            [ProducesResponseType(204)]
            [ProducesResponseType(404)]
            public IActionResult DeletePermission(int Id)
            {
                if (!_permissionService.PermissionExists(Id))
                {
                    return NotFound();
                }

                var userToDelete = _permissionService.GetPermissionbyId(Id);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (_permissionService.DeletePermission(userToDelete))
                {
                    ModelState.AddModelError("", "Something went wrong deleting owner");
                }

                return NoContent();
            }
        
    }
}
