using Yumms.Models;
using System.Linq;
using System.Data.Entity;

namespace _4232_pp.Repositories
{
    public class UserRepositoriesImpl : UserRepositories
    {
        private readonly YummsContext _context;

        public UserRepositoriesImpl(YummsContext context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public void SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public User SignIn(User user)
        {
            return _context.Users.FirstOrDefault(c => c.Email == user.Email && c.Password == user.Password);
        }
    }
}