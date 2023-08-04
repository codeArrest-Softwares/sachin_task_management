using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DataContext _Context;

        public UserRoleRepository(DataContext Context)
        {

            _Context = Context;
        }

        public bool CreateUserRole(User user, Role role)
        {
            if (_Context.UserRole.Any(rp => rp.User == user && rp.Role == role))
            {
                return false;
            }

            var x = new UserRole()
            {
                Role = role,
                User = user
            };
            _Context.Role.Add(role);
            _Context.User.Add(user);
            _Context.UserRole.Add(x);
            return Save();
        }

        public bool DeleteUserRole(Guid id)
        {
            var user = _Context.User.Where(x => x.Id == id).FirstOrDefault();
            var rid = _Context.UserRole.Where(p => p.Id == id).Select(x => x.RoleId).FirstOrDefault();
            var role = _Context.Role.Where(x => x.RoleId == rid).FirstOrDefault(); 
            //if (pid != 0 && role != null) { return false; }
            _Context.Remove(role);
            return Save();
        }

        public UserRoleDto GetUserRolebyId(Guid id)
        {
            var user = _Context.User.Where(x => x.Id == id).FirstOrDefault();

            var rid = _Context.UserRole.Where(p => p.Id == id).Select(x => x.RoleId).FirstOrDefault();
            var role = _Context.Role.Where(x => x.RoleId == rid).FirstOrDefault();


            var res = new UserRole()
            {
                Role = role,
                User = user
            };
            var k = new UserRoleDto()
            {
                Id = user.Id,
                RoleId = rid,
                Username = user.Username,
                Role = role.RoleName,
                Password= user.Password,
                Email = user.Email
            

            };
            return (k);
        }

        public bool UpdateUserRole(Guid id, UserRoleDto userroleDto)
        {
            var user = _Context.User.Where(x => x.Id == id).FirstOrDefault();

            var rid = _Context.UserRole.Where(p => p.Id == id).Select(x => x.RoleId).FirstOrDefault();
            var role = _Context.Role.Where(x => x.RoleId == rid).FirstOrDefault();

            role.RoleName = userroleDto.Role;
            user.Username = userroleDto.Username;
            user.Password = userroleDto.Password;
            user.Email = userroleDto.Email;
            return Save();
        }

        public bool UserRoleExist(Guid id)
        {
            return _Context.UserRole.Any(p => p.Id == id);
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
