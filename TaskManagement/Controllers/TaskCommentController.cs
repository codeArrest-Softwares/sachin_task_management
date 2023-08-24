using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.IServices;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCommentController : Controller
    {
        private readonly ITaskCommentService _taskCommentService;

        public TaskCommentController(ITaskCommentService taskCommentService)
        {
            _taskCommentService = taskCommentService;
        }

        [HttpGet("{Taskid}")]
        public IActionResult GetCommentByTaskId(Guid Taskid)
        {
            if (!_taskCommentService.TaskCommentExist(Taskid))
                return Ok("Comments doesnt exist for this task");

            var comment = _taskCommentService.TaskCommentExist(Taskid);

            return Ok(comment);
        }
        [HttpPost]
        public IActionResult CreateTaskComment(TaskCommentDto taskcommentDto)
        {

            if (taskcommentDto == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);




            _taskCommentService.CreateTaskComment(taskcommentDto);


            return Ok("Successfully created");
        }
        [HttpPut]
        public IActionResult UpdateTaskComment(Guid id, TaskCommentDto taskcommentDto)
        {
            bool IsValid = true;
            bool updatedtc = false;

            if (taskcommentDto == null)
            {
                IsValid = false;
            }


            if (IsValid && !_taskCommentService.TaskCommentExist(id))
            {
                IsValid = false;
                ModelState.AddModelError("", " not found");
            }


            if (IsValid && !ModelState.IsValid)
            {
                IsValid = false;
            }

            updatedtc = _taskCommentService.UpdateTaskComment(id, taskcommentDto);


            if (!updatedtc)
            {
                ModelState.AddModelError("", "Something went wrong while updating ");

            }
            if (!IsValid)
            {
                return BadRequest(ModelState);
            }
            return updatedtc ? Ok("updated") : StatusCode(500, ModelState);

        }
        [HttpDelete]
        public IActionResult DeleteTaskComment(Guid id)
        {
            if (!_taskCommentService.TaskCommentExist(id))
            {
                return Ok("taskId not found!");
            }

            if (!_taskCommentService.DeleteTaskComment(id))
            {
                return Ok("comment has been deleted");
            }

            return Ok("Deleted");
        }
    }
}
