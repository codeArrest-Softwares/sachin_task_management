using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;
using TaskManagement.Repository;

namespace TaskManagement.Services
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public bool CreateRole(Role roleDto)
        {
            var role= new Role
            {
                
                RoleName = roleDto.RoleName,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
              //  IsActive = true
            };
            return _roleRepository.CreateRole(role);
        }

        public bool DeleteRole(Role role)
        {
            return _roleRepository.DeleteRole(role);
        }

        public ICollection<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public Role GetRolebyId(Guid id)
        {
            return _roleRepository.GetRolebyId(id);
        }

        public bool RoleExists(Guid userId)
        {
            return _roleRepository.RoleExists(userId);      
        }

        public bool UpdateRole(Guid id, Role roleDto)
        {
            return _roleRepository.UpdateRole(id, roleDto);
        }
    }
}
