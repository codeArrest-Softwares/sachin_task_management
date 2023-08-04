using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.IRepository
{
    public interface IRegisterRepository
    {
        ICollection<User> GetAllUsers();
        User  GetUserbyId(Guid id);
       
        bool UserExists(Guid userId);
        //  UserDto GetUserTrimToUpper(User userCreate);
        bool CreateUser(User userDto);
        bool UpdateUser( Guid id,User userDto);
        bool DeleteUser( User user);


    }
}
