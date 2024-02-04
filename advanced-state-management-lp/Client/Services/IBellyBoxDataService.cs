using BellyBox.Shared;

namespace BellyBox.Client.Services
{
    public interface IBellyBoxDataService
    {
        Task<Meal> GetMealById(int id);
        Task<Meal[]> GetMeals();
        Task<Tag[]> GetTags();
    }
}