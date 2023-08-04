namespace TaskManagement.Dto
{
    public class UserRoleDto
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
     

        public string Role { get ; set; }    



    }
}
