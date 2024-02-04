using BellyBox.Shared;
using System.Net.Http.Json;

namespace BellyBox.Client.Services
{
    public class BellyBoxDataService : IBellyBoxDataService
    {
        private readonly HttpClient httpClient;

        public BellyBoxDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Meal[]> GetMeals()
        {
            var meals = await httpClient.GetFromJsonAsync<Meal[]>("api/meals");
            return meals;
        }

        public async Task<Tag[]> GetTags()
        {
            var tags = await httpClient.GetFromJsonAsync<Tag[]>("api/meals/tags");
            return tags;
        }

        public async Task<Meal> GetMealById(int Id)
        {
            var response = await httpClient.GetAsync($"api/meal/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Meal>();
        }
    }
}
