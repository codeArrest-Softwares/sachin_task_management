namespace TaskManagement.Models
{
    public class UserRole
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }

    }
}
