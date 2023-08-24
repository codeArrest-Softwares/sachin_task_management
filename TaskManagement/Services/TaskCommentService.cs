using System.Threading.Tasks;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;
using TaskManagement.Repository;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Services
{
    public class TaskCommentService : ITaskCommentService
    {
        private readonly ITaskCommentRepository _taskCommentRepository;

        public TaskCommentService(ITaskCommentRepository taskCommentRepository)
        {
             _taskCommentRepository = taskCommentRepository;
        }
        public bool CreateTaskComment(TaskCommentDto taskCommentDto)
        {
            var comment = new Comments()
            {
               Author=taskCommentDto.Author,
               Text=taskCommentDto.Text,
             



            };
            var tsk = new Task()
            {
                Title = taskCommentDto.Title,
                AssociatedProject = taskCommentDto.AssociatedProject,
                Description = "xyx",
                


            };

            return _taskCommentRepository.CreateTaskComment( tsk,comment);
        }

        public bool DeleteTaskComment(Guid TaskID)
        {
           return _taskCommentRepository.DeleteTaskComment(TaskID);
        }

        public TaskCommentDto GetCommentByTaskId(Guid TaskID)
        {
           return _taskCommentRepository.GetCommentByTaskId(TaskID);
        }

        public bool TaskCommentExist(Guid TaskID)
        {
            return _taskCommentRepository.TaskCommentExist(TaskID);
        }

        public bool UpdateTaskComment(Guid TaskID, TaskCommentDto taskComment)
        {
           return _taskCommentRepository.UpdateTaskComment(TaskID, taskComment);
        }
    }
}
