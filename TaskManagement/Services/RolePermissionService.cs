using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.IServices;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class RolePermissionService:IRolePermissionService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public bool CreateRolePermission(RolePermissionDto rolepermission)
        {
            var role = new Role()
            {
               RoleName=rolepermission.RoleName,
               
            };
            var permission = new Permission()
            {
                PermissionName=rolepermission.Permission
            };

          return  _rolePermissionRepository.CreateRolePermission(role, permission);

        }

        public bool DeleteRolePermission(Guid id)
        {
            return _rolePermissionRepository.DeleteRolePermission(id);
        }

        public RolePermissionDto GetRolePermissionById(Guid RoleId)
        {
           return _rolePermissionRepository.GetRolePermissionById(RoleId);
        }

        public bool RolePermissionExist(Guid id)
        {
           return  _rolePermissionRepository.RolePermissionExist(id);
        }

        public bool UpdateRolePermission(Guid id, RolePermissionDto rolepermissionDto)
        {   
            
           return _rolePermissionRepository.UpdateRolePermission(id, rolepermissionDto);
        }
    }
}
