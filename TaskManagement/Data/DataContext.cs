using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User>User{ get; set; }
       public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
       public DbSet<Permission> Permission { get; set; }
       public DbSet<RolePermission> RolePermission { get; set; }
       public DbSet<Task> Task { get; set; }
       public DbSet<UserTask>UserTask { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermission>()
                .HasKey(ur => new { ur.RoleId, ur.PermissionId });
            modelBuilder.Entity<RolePermission>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.RolePermissions)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(ur => ur.Permission)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(ur => ur.PermissionId); 
            
            
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.RoleId, ur.Id });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.Id);

            modelBuilder.Entity<UserTask>()
              .HasKey(ur => new { ur.Id, ur.TaskId });
            modelBuilder.Entity<UserTask>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ur => ur.Id);

            modelBuilder.Entity<UserTask>()
                .HasOne(ur => ur.Task)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ur => ur.TaskId);



        }

    }
}
