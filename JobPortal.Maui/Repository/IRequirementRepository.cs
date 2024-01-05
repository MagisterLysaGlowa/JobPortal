using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface IRequirementRepository
    {
        Task<Requirement> AddRequirement(int jobOfertId, Requirement requirement);
        Task AddAllRequirements(int jobOfertId, List<Requirement> requirements);
        Task<List<Requirement>> GetRequirements(int jobOfertId);
        Task DeleteRequirement(int requirementId);
        Task DeleteRequirementsByJobOfert(int jobOfertId);
    }
}
