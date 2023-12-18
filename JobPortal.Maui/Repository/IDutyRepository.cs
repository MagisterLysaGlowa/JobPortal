using JobPortal.Maui.Model;

namespace JobPortal.Maui.Repository
{
    public interface IDutyRepository
    {
        Task<Duty> AddDuty(int jobOfertId, Duty duty);
        Task<List<Duty>> GetDuties(int jobOfertId);
    }
}
