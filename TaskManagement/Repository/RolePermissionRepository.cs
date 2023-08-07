using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly DataContext _context;

        public RolePermissionRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateRolePermission(Role role, Permission permission)
        {
            if (_context.RolePermission.Any(rp => rp.Role == role && rp.Permission == permission)) { 
                return false; 
            }

            var x = new RolePermission()
            {
                Role = role,
                Permission = permission
            };
            _context.Role.Add(role);
            _context.Permission.Add(permission);
            _context.RolePermission.Add(x);
            return Save();

        }

        public bool DeleteRolePermission(Guid id)
        {
            var role = _context.Role.Where(x => x.RoleId == id).FirstOrDefault();
            var pid = _context.RolePermission.Where(p => p.RoleId == id).Select(x => x.PermissionId).FirstOrDefault();
            //var permission = _context.Permission.Where(x => x.PermissionId == pid).FirstOrDefault(); 
            if(pid!=0 && role!=null) { return false;}
            _context.Remove(role);
            return Save();

        }

        public RolePermissionDto GetRolePermissionById(Guid RoleId)
        {

            var role = _context.Role.Where(x=>x.RoleId==RoleId).FirstOrDefault();
            var pid = _context.RolePermission.Where(p => p.RoleId == RoleId).Select(x=>x.PermissionId).FirstOrDefault();
            var permission = _context.Permission.Where(x=>x.PermissionId==pid).FirstOrDefault();

            var res = new RolePermission()
            {
                Role = role,
                Permission=permission
            };
            var k = new RolePermissionDto()
            {
                RoleId = role.RoleId,
                PermissionId = pid,
                RoleName = role.RoleName,
                Permission = permission.PermissionName
            };
            return (k);

         }

        public bool RolePermissionExist(Guid id)
        {
            return _context.Role.Any(p => p.RoleId == id);
        }

        public bool UpdateRolePermission(Guid id, RolePermissionDto rolepermissionDto)
        {
            var role = _context.Role.Where(x => x.RoleId == id).FirstOrDefault();
            var pid = _context.RolePermission.Where(p => p.RoleId == id).Select(x => x.PermissionId).FirstOrDefault();
            var permission = _context.Permission.Where(x => x.PermissionId == pid).FirstOrDefault();

            role.RoleName = rolepermissionDto.RoleName;
            permission.PermissionName = rolepermissionDto.Permission;
             return Save();

        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
