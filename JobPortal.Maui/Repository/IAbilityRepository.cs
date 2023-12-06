using JobPortal.Maui.Model;

namespace JobPortal.Maui.Repository
{
    public interface IAbilityRepository
    {
        Task<Ability> AddAbility(int userId, Ability ability);
        Task<List<Ability>> GetAbilities(int userId);
        Task DeleteAbility(int abilityId);
    }
}
