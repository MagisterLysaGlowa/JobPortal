using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface ILanguageRepository
    {
        Task<Language> AddLanguage(int userId, Language language);
        Task<List<Language>> GetLanguages(int userId);
        Task DeleteLanguage(int languageId);
    }
}
