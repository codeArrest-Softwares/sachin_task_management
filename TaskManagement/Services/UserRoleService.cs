using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public bool CreateUserRole(UserRoleDto userRoleDto)
        {
            var user = new User()
            {
                Username = userRoleDto.Username,
                Email = userRoleDto.Email,
                Password=userRoleDto.Password

            };
            var role = new Role()
            {
                RoleName = userRoleDto.Role
            };

            return _userRoleRepository.CreateUserRole(user, role);
        }

        public bool DeleteUserRole(Guid id)
        {
           return _userRoleRepository.DeleteUserRole(id);
        }
        public UserRoleDto GetUserRolebyId(Guid id)
        {
            return _userRoleRepository.GetUserRolebyId(id);
        }

        public bool UpdateUserRole(Guid id, UserRoleDto userroleDto)
        {
           return _userRoleRepository.UpdateUserRole(id, userroleDto);
        }

        public bool UserRoleExist(Guid id)
        {
            return _userRoleRepository.UserRoleExist(id);
        }
    }
}
