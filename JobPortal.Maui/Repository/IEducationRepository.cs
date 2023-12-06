using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface IEducationRepository
    {
        Task<Education> AddEducation(Education education, int userId);
        Task<List<Education>> GetEducations(int userId);
        Task DeleteEducation(int educationId);
    }
}
