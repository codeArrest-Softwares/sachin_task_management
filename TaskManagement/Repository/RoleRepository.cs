using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class RoleRepository:IRoleRepository
    {
        private readonly DataContext _Context;

        public RoleRepository(DataContext Context)
        {
            _Context = Context;
        }

        public bool CreateRole(Role roleDto)
        {
            _Context.Role.Add(roleDto);
            return Save();
        }

        public bool DeleteRole(Role role)
        {
            _Context.Role.Remove(role);
            return Save();
        }

        public ICollection<Role> GetAllRoles()
        {
            return _Context.Role.ToList();
        }

        public Role GetRolebyId(Guid id)
        {
            return _Context.Role.Where(p => p.RoleId == id).FirstOrDefault();
        }

        public bool RoleExists(Guid userId)
        {
            return _Context.Role.Any(p => p.RoleId == userId);
        }

        public bool UpdateRole(Guid id, Role roleDto)
        {
            _Context.Update(roleDto);
           return Save();
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
