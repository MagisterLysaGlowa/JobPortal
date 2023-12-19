using JobPortal.Maui.Model;

namespace JobPortal.Maui.Repository
{
    public interface IUserRepository
    {
        Task<User> Login(string email, string password);
        Task<User> Register(User user);
        Task<User> PostUserJobOfertApplication(int userId,JobOfert jobOfert);
        Task<List<UserJobOfertApplication>> GetUserJobOfertApplications(int userId);
        Task<User> PostUserJobOfertFavourite(int userId, JobOfert jobOfert);
        Task<List<UserJobOfertFavourite>> GetUserJobOfertFavourites(int userId);
        Task<User> GetUser(int userId);
        Task<User> UpdateUser(int id, User user);
        Task<bool> CheckIfEmailIsFree(string email);
        Task<bool> CheckIfPhoneIsFree(string phone);
        Task RemoveUserJobOfertApplication(int userId, int jobOfertId);
        Task RemoveUserJobOfertFavourite(int userId, int jobOfertId);
    }
}
