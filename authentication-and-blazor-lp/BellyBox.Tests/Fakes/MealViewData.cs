using System.Collections.Generic;
using System.Linq;
using BellyBox.Shared;

namespace BellyBox.Tests;

public static class MealViewData
{
    /// <summary>
    /// Creates an array of test meals using a template where n is the item number:
    /// </summary>
    /// <returns>
    public static Meal[] GetFakeMeals(int records) =>
        Enumerable.Range(1, records).Select(n => new Meal
        {
            Id = n,
            Name = $"Meal {n}",
            Calories = n,
            Description = $"Meal {n} Description",
            Servings = n,
            ImageUrl = $"Image {n}",
            ThumbnailUrl = $"TnImage {n}",
            Tags = GetFakeTags(n, 2),
            Ingredients = GetFakeIngredients(n)
        }).ToArray();

    public static Tag[] GetFakeTags(int start, int count) =>
        Enumerable.Range(start, count).Select(i => new Tag
        {
            Id = i,
            Text = $"Tag {i}"
        }).ToArray();

    private static IEnumerable<Ingredient> GetFakeIngredients(int n) =>
        Enumerable.Range(0, n).Select(i => new Ingredient
        {
            Id = i,
            Name = $"Ingredient {n}-{i}"
        });
}

