using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(int jobOfertId, Category category);
        Task<List<Category>> GetCategories();
        Task<List<string>> GetCategoriesAsString();
        Task<List<Category>> GetCategories(int jobOfertId);
    }
}
