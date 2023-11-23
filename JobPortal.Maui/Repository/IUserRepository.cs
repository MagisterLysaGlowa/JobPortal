using JobPortal.Maui.Model;

namespace JobPortal.Maui.Repository
{
    public interface IUserRepository
    {
        Task<User> Login(string email, string password);
        Task<User> Register(User user);
        Task<User> UpdateUser(int id, User user);
        Task<bool> CheckIfEmailIsFree(string email);
        Task<bool> CheckIfPhoneIsFree(string phone);
    }
}
