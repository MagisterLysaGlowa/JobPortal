using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface IExperienceRepository
    {
        Task<Experience> AddExperience(int userId, Experience experience);
    }
}
