using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Repository
{
    public class TaskCommentRepository : ITaskCommentRepository
    {
        private readonly DataContext _context;

        public TaskCommentRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateTaskComment(Task task, Comments comments)
        {
          

            var x = new TaskComment()
            {
                Task = task,
                Comments = comments
            };
            _context.Task.Add(task);
            _context.Comments.Add(comments);
            _context.TaskComment.Add(x);
            return Save();
        }

        public bool DeleteTaskComment(Guid TaskID)
        {
            var task = _context.Task.Where(x => x.TaskId == TaskID).FirstOrDefault();

            var cid = _context.TaskComment.Where(p => p.TaskId == TaskID).Select(x => x.CommentsID).FirstOrDefault();

            var comment = _context.Comments.Where(x => x.CommentsID == cid).FirstOrDefault();
            

            _context.Remove(comment);
            return Save();
        }

        public TaskCommentDto GetCommentByTaskId(Guid TaskID)
        {

            var task = _context.Task.Where(x => x.TaskId == TaskID).FirstOrDefault();

            var cid = _context.TaskComment.Where(p => p.TaskId== TaskID).Select(x => x.CommentsID).FirstOrDefault();
            var comment = _context.Comments.Where(x => x.CommentsID == cid).FirstOrDefault();


            var res = new TaskComment()
            {
                Task = task,
                Comments = comment
            };
            var k = new TaskCommentDto()
            {
                CommentsID= cid,
                Title = task.Title,
                AssociatedProject = task.AssociatedProject,
                 Author=comment.Author,
                 Text=comment.Text


            };
            return (k);
        }

        public bool TaskCommentExist(Guid TaskID)
        {
            return _context.TaskComment.Any(x => x.TaskId == TaskID);
        }

        public bool UpdateTaskComment(Guid TaskID, TaskCommentDto taskComment)
        {
            var task = _context.Task.Where(x => x.TaskId == TaskID).FirstOrDefault();

            var Cid = _context.TaskComment.Where(p => p.TaskId == TaskID).Select(x => x.CommentsID).FirstOrDefault();

            var comment = _context.Comments.Where(x => x.CommentsID == Cid).FirstOrDefault();

            
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
