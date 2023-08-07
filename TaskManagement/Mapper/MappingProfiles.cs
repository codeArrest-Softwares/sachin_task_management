using AutoMapper;
using TaskManagement.Dto;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

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
            CreateMap<Task,TaskDto>();
            CreateMap<TaskDto,Task>();
            CreateMap<UserTaskDto,UserTask>();
            CreateMap<UserTask,UserTaskDto>();

        }
    }
}
