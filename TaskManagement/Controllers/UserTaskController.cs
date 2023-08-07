using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.IServices;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : Controller
    {
        private readonly IUserTaskService _userTaskService;
        private readonly IMapper _mapper;

        public UserTaskController(IUserTaskService userTaskService,IMapper mapper)
        {
            _userTaskService = userTaskService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetTaskByUserId(Guid id)
        {
            if (!_userTaskService.UserTaskExist(id))
                return Ok("Task is not assigned for this user");

            var user = _userTaskService.GetTaskByUserId(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AssignTask(UserTaskDto taskDto)
        {

            if (taskDto == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);


           

            _userTaskService.AssignTask(taskDto);


            return Ok("Successfully created");
        }
        [HttpPut]
        public IActionResult UpdateUserTask(Guid id, UserTaskDto taskDto)
        {
            bool IsValid = true;
            bool updatedut = false;

            if (taskDto == null)
            {
                IsValid = false;
            }


            if (IsValid && !_userTaskService.UserTaskExist(id))
            {
                IsValid = false;
                ModelState.AddModelError("", "Task not assigned not found");
            }


            if (IsValid && !ModelState.IsValid)
            {
                IsValid = false;
            }

            updatedut = _userTaskService.UpdateUserTask(id, taskDto);


            if (!updatedut)
            {
                ModelState.AddModelError("", "Something went wrong while updating ");

            }
            if (!IsValid)
            {
                return BadRequest(ModelState);
            }
            return updatedut ? Ok("updated") : StatusCode(500, ModelState);

        }
        [HttpDelete]
        public IActionResult DeleteUserTask(Guid id)
        {
            if (!_userTaskService.UserTaskExist(id))
            {
                return Ok("userId not found!");
            }

            if (!_userTaskService.DeleteUserTask(id))
            {
                return Ok("Task has been deleted");
            }

            return Ok("Deleted");
        }
    }
}
