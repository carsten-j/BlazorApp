using System.Collections.Generic;

namespace BellyBox.Tests.Fakes
{
	public static class MealViewData
	{
		public static IEnumerable<BellyBox.Shared.Ingredient> GetFakeIngredients(int n)
		{
			List<BellyBox.Shared.Ingredient> ingredients = new();

			for (int i = 0; i < n; i++)
            {
				ingredients.Add(new BellyBox.Shared.Ingredient() { Id = i, Name = $"Ingredient {n}-{i}" });
            }

			return ingredients;
		}

		public static List<BellyBox.Shared.Tag> GetFakeTags(int start, int n)
		{
			List<BellyBox.Shared.Tag> tags = new();

			for (int i = start; i < start + n; i++)
            {
				BellyBox.Shared.Tag tag = new()
				{
					Id = i,
					Text = $"Tag {n-start+i}"
				};
				tags.Add(tag);
			}

			return tags;
		}

		public static List<BellyBox.Shared.Meal> GetFakeMeals(int n)
		{
			List<BellyBox.Shared.Meal> meals = new();

			for (int i = 0; i < n; i++)
            {
				BellyBox.Shared.Meal meal = new()
                {
					Id = n,
					Name = $"Meal {n}",
					Calories = n,
					Description = $"Meal {n} Description",
					Servings = n,
					ImageUrl = $"Image {n}",
					ThumbnailUrl = $"TnImage {n}",
					Tags = GetFakeTags(2, n),
					Ingredients = GetFakeIngredients(n)
				};
				meals.Add(meal);
            }

			return meals;
		}
	}
}

