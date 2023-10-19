using JobPortal.Maui.Model;

namespace JobPortal.Maui.Repository
{
    public interface IUserRepository
    {
        Task<User> Login(string email, string password);
    }
}
