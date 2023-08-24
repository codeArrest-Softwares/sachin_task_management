using TaskManagement.Dto;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.IServices
{
    public interface ITaskCommentService
    {
        TaskCommentDto GetCommentByTaskId(Guid TaskID);
        bool TaskCommentExist(Guid TaskID);
        public bool CreateTaskComment(TaskCommentDto taskCommentDto);
        public bool UpdateTaskComment(Guid TaskID, TaskCommentDto taskComment);
        public bool DeleteTaskComment(Guid TaskID);




    }
}
