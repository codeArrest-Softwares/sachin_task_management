using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;
using TaskManagement.Repository;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Services
{
    public class UserTaskService:IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public bool AssignTask(UserTaskDto task)
        {
            var user = new User()
            {
                Username=task.Username,
                Email="test@gmail.com",
                Password="123"


            };
            var tsk= new Task()
            {
                Title=task.TaskTitle,
                AssociatedProject=task.AssociatedProject,
                Description="xyx",
                Priority=task.Priority,
               Status=task.Status,
                
                
            };

            return _userTaskRepository.AssignTask(user, tsk);
        }

        public bool DeleteUserTask(Guid UserId)
        {
         return _userTaskRepository.DeleteUserTask(UserId);
        }

        public UserTaskDto GetTaskByUserId(Guid UserId)
        {
           return _userTaskRepository.GetTaskByUserId(UserId);
        }

        public bool UpdateUserTask(Guid id, UserTaskDto userTaskdto)
        {
            return _userTaskRepository.UpdateUserTask(id, userTaskdto);
        }

        public bool UserTaskExist(Guid id)
        {
           return _userTaskRepository.UserTaskExist(id);
        }
    }
}
