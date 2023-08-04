using System.Collections.ObjectModel;
using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.IRepository
{
    public interface ILoginRepository
    {
        ICollection<User> GetUsersFromLogin();
        User GetUserFromLogin(Guid id);
       
        bool UserExists(Guid id);
        
        public string UserLogin(LoginDto logindto);
        public string UserUpdate(Guid id, LoginDto logindto);
        public bool UserDelete(Guid id);

        
    }
}
