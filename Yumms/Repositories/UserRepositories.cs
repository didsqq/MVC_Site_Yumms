using Yumms.Models;

namespace _4232_pp.Repositories
{
    public interface UserRepositories
    {
        User SignIn(User user);
        User GetUserByEmail(string email);
        void SaveUser(User user);
        void UpdateUser(User user); //  метод для обновления пользователя
        void DeleteUser(User user); //метод для удаления пользователя
    }
}