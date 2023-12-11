using JobPortal.Maui.Model;

namespace JobPortal.Maui.ViewModels
{
    public interface IJobOfertRepository
    {
        Task<JobOfert> AddJobOfert(int userId,JobOfert jobOfert);
        Task<List<JobOfert>> GetAllJobOferts();
        Task<List<JobOfert>> GetAllJobOfertsWithCategories();
    }
}
