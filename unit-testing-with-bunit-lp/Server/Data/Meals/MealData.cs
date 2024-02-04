using BellyBox.Shared;
using System.Collections.Generic;
using System.Linq;

namespace BellyBox.Data
{
    public class MealData
    {
        public int MealId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Calories { get; set; }
        public int Servings { get; set; }
        public string ImageUrl { get; set; } = "https://via.placeholder.com/368x200/f7d794?text=No%20Image";
        public string ThumbnailUrl { get; set; } = "https://via.placeholder.com/368x200/f7d794?text=No%20Image";
        public List<MealTag> MealTags { get; set; } = new();
        public List<MealIngredient> MealIngredients { get; set; } = new();

        public Meal ToMeal() => new Meal()
        {
            Id = MealId,
            Calories = Calories,
            Description = Description,
            ImageUrl = ImageUrl,
            ThumbnailUrl = ThumbnailUrl,
            Name = Name,
            Servings = Servings,
            Ingredients = MealIngredients.Select(i => new Ingredient()
            {
                Id = i.IngredientId,
                Name = i?.Ingredient?.Name
            }),
            Tags = MealTags.Select(t => new Tag()
            {
                Id = t.TagId,
                Text = t?.Tag?.Text
            })
        };
    }
}
