using JobPortal.Maui.Model;

namespace JobPortal.Maui.ViewModels
{
    public interface IJobOfertRepository
    {
        Task<JobOfert> AddJobOfert(int userId,JobOfert jobOfert);
        Task<List<JobOfert>> GetAllJobOferts();
        Task<JobOfert> GetJobOfert(int jobOfertId);
        Task<List<JobOfert>> GetAllJobOfertsWithCategories();
        Task DeleteJobOfert(int jobOfertId);
        Task<bool> UpdateJobOfert(int jobOfertId, JobOfert jobOfert);
    }
}
