using TaskManagement.Dto;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.IRepository
{
    public interface IUserTaskRepository
    {

       // ICollection<UserTask> GetAllAssignedTask();
        UserTaskDto GetTaskByUserId(Guid UserId);
        bool UserTaskExist(Guid id);
        public bool AssignTask(User user, Task task);
        public bool UpdateUserTask(Guid id,UserTaskDto userTask);
        public bool DeleteUserTask(Guid UserId);
    }
}
