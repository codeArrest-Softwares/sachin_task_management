using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.IServices;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : Controller
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IMapper _mapper;


        public ProjectTaskController(IProjectTaskService projectTaskService,IMapper mapper)
        {
            _projectTaskService = projectTaskService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProjectTask(){
           var p= _projectTaskService.GetProjectTask();

            return Ok(p);
        }
        [HttpPost]

       public IActionResult CreateProjectTask(Guid id ,TaskDto ptDto) {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!_projectTaskService.CreateProjectTask(id, ptDto))
                return Ok("Id not Found!");

            return Ok("Successfully  Created");
        }
        [HttpPut("{Taskid}")]
        public IActionResult UpdateProjectTask(Guid Taskid, TaskDto ptDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!_projectTaskService.UpdateProjectTask(Taskid, ptDto))
                return Ok("Id not Found!");

            return Ok("Successfully Updated");
        }
        [HttpDelete("{Projectid}")]
        public IActionResult DeleteProjectTask(Guid Projectid)
        {



            if (!_projectTaskService.DeleteProjectTask(Projectid))
                return Ok("Id not Found!");

            return Ok("Deleted");
        }
    }
}
