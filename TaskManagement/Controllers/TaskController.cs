using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.IServices;
using Task = TaskManagement.Models.Task;
namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();

            return Ok(tasks);


        }
        [HttpGet("{taskId}")]
        public ActionResult GetTaskById(Guid taskId)
        {
            if (!_taskService.TaskExists(taskId))
            {
                return Ok("ID not found!");
            }
            var task = _taskService.GetTaskById(taskId);

            return Ok(task);
        }
        [HttpPost]
        public ActionResult CreateTask([FromBody] TaskDto taskdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid entry");
            }
            //if (!DateTime.TryParse(taskdto.DueDate, out DateTime dueDate))
            //{
            //    // Handle invalid date format
            //    return BadRequest("Invalid DueDate format. Use yyyy-MM-dd format.");
            //}
            var taskmap = _mapper.Map<Task>(taskdto);

            if (!_taskService.CreateTask(taskmap))
            {
                return Ok("This Title name and Associated Project already exist!");
            }

            return Ok("Task created successfully");
        }
        [HttpPut("{taskId}")]
        public ActionResult UpdateTask([FromRoute] Guid taskId, [FromBody] TaskDto taskdto)
        {
            if (!_taskService.TaskExists(taskId))
                return Ok("Id not found!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _taskService.UpdateTask(taskId, taskdto);
            return Ok("Updated sucessfully!");

        }
        [HttpDelete("{taskId}")]
        public ActionResult DeleteTask(Guid taskId)
        {
            if (!_taskService.TaskExists(taskId))
                return Ok("Id not found!");

            var tasktodelete = _taskService.GetTaskById(taskId);

            _taskService.DeleteTask(tasktodelete);


            return Ok("Task Deleted");
        }
    }
}
