using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.IServices;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentsService commentsService,IMapper mapper)
        {
            _commentsService = commentsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            var comments = _mapper.Map<List<CommentsDto>>(_commentsService.GetAllComments());

            return Ok(comments);
        }
        [HttpGet("{id}")]
        public IActionResult GetCommentsByiD(Guid id)
        {
            if (!_commentsService.CommentsExists(id))
                return NotFound();



            var comment = _mapper.Map<CommentsDto>(_commentsService.GetCommentsByID(id));

            return Ok(comment);
        }
        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentsDto commentdto)

        {    if(!ModelState.IsValid)
            {
                return BadRequest("invalid entry");
            }



            var commentmap = _mapper.Map<Comments>(commentdto);
            if (_commentsService.CreateComments(commentmap) == false)
            {
                return Ok("This comment already  exist!");
            }

            return Ok("comment created successfully");
        }
        [HttpPut("{commentId}")]
        public ActionResult UpdateComment([FromRoute] Guid commentId, [FromBody] CommentsDto commentdto)
        {
            if (!_commentsService.CommentsExists(commentId))
                return Ok("Id not found!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _commentsService.UpdateComments(commentId, commentdto);
            return Ok("Updated sucessfully!");

        }
        [HttpDelete("{commentId}")]
        public ActionResult DeleteTask(Guid commentId)
        {
            if (!_commentsService.CommentsExists(commentId))
                return Ok("Id not found!");

            var tasktodelete = _commentsService.GetCommentsByID(commentId);

            _commentsService.DeleteComments(tasktodelete);


            return Ok("Comment Deleted");
        }
    }
}
