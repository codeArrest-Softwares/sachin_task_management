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
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService ,IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GetAllProjects()
        {
           var p= _projectService.GetProjects();

            
            return Ok(p) ;

        }
        [HttpGet("{projectId}")]
        public IActionResult GetProjectebyId(Guid projectId)
        {
            if (!_projectService.ProjectExists(projectId))
                return NotFound();

            // var user = _mapper.Map<RoleDto>(_roleService.GetRolebyId(roleId));
            var p = _projectService.GetProjectById(projectId);

            return Ok(p);

        }
        [HttpPost]
        public IActionResult CreateProject( [FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid entry");
            }



            var map = _mapper.Map<Project>(projectDto);
            _projectService.CreateProject(map);
           

            return Ok("Project created successfully");
        }
        [HttpPut("{projectId}")]
        public ActionResult UpdateTask([FromRoute] Guid projectId, [FromBody] ProjectDto projectDto)
        {
            if (!_projectService.ProjectExists(projectId))
                return Ok("Id not found!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var map = _mapper.Map<Project>(projectDto);
            _projectService.UpdateProject(projectId, map);
            return Ok("Updated sucessfully!");

        }
        [HttpDelete("{projectId}")]
        public ActionResult DeleteProject(Guid projectId)
        {
            if (!_projectService.ProjectExists(projectId))
                return Ok("Id not found!");

            var projecttodelete = _projectService.GetProjectById(projectId);

            _projectService.DeleteProject(projecttodelete);


            return Ok("Project Deleted");
        }




    }
}
