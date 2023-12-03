using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    interface IWorkRepository
    {
        Task<Work> AddWork(Work work);
        Task<Work> UpdateWork(int workId,Work work);
        Task<Work> GetWorkByUserId(int userId);
        Task DeleteWork(int workId);
    }
}
