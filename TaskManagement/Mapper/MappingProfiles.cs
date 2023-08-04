using AutoMapper;
using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.Mapper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User,UserDto>();
            CreateMap<UserDto,User>();
            CreateMap<LoginDto,User>();
            CreateMap<User,LoginDto>();
            CreateMap<Role,RoleDto>();
            CreateMap<RoleDto,Role>();
            CreateMap<PermissionDto,Permission>();
            CreateMap<Permission,PermissionDto>();
            CreateMap<UserRole,UserRoleDto>();
            CreateMap<UserRoleDto,UserRole>();
            CreateMap<RolePermissionDto,RolePermission>();
            CreateMap<RolePermission,RolePermissionDto>();
        }
    }
}
