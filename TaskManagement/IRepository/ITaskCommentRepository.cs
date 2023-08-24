using TaskManagement.Dto;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.IRepository
{
    public interface ITaskCommentRepository
    {
        TaskCommentDto GetCommentByTaskId(Guid TaskID);
        bool TaskCommentExist(Guid TaskID);
        public bool CreateTaskComment(Task task, Comments comments);
        public bool UpdateTaskComment(Guid TaskID, TaskCommentDto taskComment);
        public bool DeleteTaskComment(Guid TaskID);


    }
}
