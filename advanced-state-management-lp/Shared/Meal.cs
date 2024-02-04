using System.Collections.Generic;

namespace BellyBox.Shared
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
        public int Servings { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

    }
}
