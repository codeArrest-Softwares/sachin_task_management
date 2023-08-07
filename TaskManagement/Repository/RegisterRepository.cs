using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Dto;
using TaskManagement.IRepository;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly DataContext _Context;

        public RegisterRepository(DataContext Context)
        {
            _Context = Context;
        }

        public bool CreateUser(User user)
        {
            _Context.User.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _Context.User.Remove(user);
            return Save();
        }
       

        public ICollection<User> GetAllUsers()
        {
            return _Context.User.ToList();
        }

        public User GetUserbyId(Guid id)
        {   

            return _Context.User.Where(p => p.Id == id).FirstOrDefault();
        }

    

     

        bool IRegisterRepository.UserExists(Guid userId)
        {
            return _Context.User.Any(p => p.Id == userId);
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(Guid id, User userDto)
        {
           var x=_Context.User.Where(x=>x.Id == id).FirstOrDefault();

            x.Email=userDto.Email;
            x.Username=userDto.Username;
            x.Password=userDto.Password;
            x.ModifiedDate=DateTime.Now;
            return Save();
        }
    }
}
