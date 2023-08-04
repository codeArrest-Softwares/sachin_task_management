using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _Context;

        public LoginRepository(DataContext Context)
        {
            _Context = Context;
        }

        public User GetUserFromLogin(Guid id)
        {
            return _Context.User.Where(x => x.Id == id).FirstOrDefault();

        }

        public ICollection<User> GetUsersFromLogin()
        {
            return _Context.User.ToList();
        }

        public bool UserDelete(Guid id)
        {
            var user = _Context.User.Find(id);
            if (user != null)
            {
                _Context.Remove(user);
                _Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UserExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public string UserLogin(LoginDto logindto)
        {
          var user = _Context.User.Where(x => x.Email == logindto.Email && x.Password == logindto.Password).FirstOrDefault();
            if (user == null)
            {
                return "Invalid User";
            }
            return "valid";

        }

        public string UserUpdate(Guid id, LoginDto logindto)
        {
            var user = _Context.User.Find(id);
            if (user != null)
            {
                user.Email = logindto.Email;
                user.Password = logindto.Password;
                user.ModifiedDate = DateTime.UtcNow;
                _Context.SaveChanges();
                return "user_update ";
            }
            return "Invalid";
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
       


    
}
