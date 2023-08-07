using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.IServices
{
    public interface IRegisterService
    {
        ICollection<User> GetAllUsers();
        User GetUserbyId(Guid id);
        bool UserExists(Guid userId);
      // UserDto GetUserTrimToUpper(UserDto userCreate);
        bool CreateUser(User userDto);
        bool UpdateUser(Guid id, User userDto);
        bool DeleteUser(User user);
    }
}
