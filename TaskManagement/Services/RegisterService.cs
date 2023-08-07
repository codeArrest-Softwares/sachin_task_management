using Microsoft.EntityFrameworkCore;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;
using TaskManagement.Repository;

namespace TaskManagement.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _userRepository;

        public RegisterService(IRegisterRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CreateUser(User userDto)
        {
            var user = new User
            {
                Email = userDto.Email,
                Username = userDto.Username,
                Password = userDto.Password,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
             };
            return _userRepository.CreateUser(user);
        }

        public bool DeleteUser(User user)
        {
            return _userRepository.DeleteUser(user);
           
        }
        bool UserExists(Guid userId)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAllUsers()
        {
             return _userRepository.GetAllUsers();
        }

        public User GetUserbyId(Guid id)
        {
            return _userRepository.GetUserbyId(id);
        }

        public bool UpdateUser(Guid id, User userDto)
        {
            return _userRepository.UpdateUser(id,userDto);
        }

        bool IRegisterService.UserExists(Guid userId)
        {
            return _userRepository.UserExists(userId);
        }

       
    }
}
