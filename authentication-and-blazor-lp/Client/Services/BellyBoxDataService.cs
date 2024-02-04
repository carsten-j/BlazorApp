using BellyBox.Shared;
using System.Net.Http.Json;

namespace BellyBox.Client.Services;

public class BellyBoxDataService : IBellyBoxDataService
{
    private readonly HttpClient _http;

    public BellyBoxDataService(HttpClient http) => _http = http;
    public Task<Meal[]?> GetMeals() => _http.GetFromJsonAsync<Meal[]>("api/meals");
    public Task<Tag[]?> GetTags() => _http.GetFromJsonAsync<Tag[]>("api/meals/tags");
    public async Task<Meal?> GetMealById(int id)
    {
        var response = await _http.GetAsync($"api/meal/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Meal>();
    }

}

