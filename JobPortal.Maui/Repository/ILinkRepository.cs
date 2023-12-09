using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface ILinkRepository
    {
        Task<Link> AddLink(int userId, Link link);
        Task<List<Link>> GetLinks(int userId);
        Task DeleteLink(int linkId);
    }
}
