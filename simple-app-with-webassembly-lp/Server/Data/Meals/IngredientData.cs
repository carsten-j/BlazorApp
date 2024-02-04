using System.Collections.Generic;

namespace BellyBox.Data
{
    public class IngredientData
    {
        public IngredientData()
        {

        }
        public IngredientData(int id, string name)
        {
            IngredientId = id;
            Name = name;
        }
        public int IngredientId { get; set; }
        public string Name { get; set; } = "";

        public ICollection<MealIngredient> MealIngredients { get; set; } = null!;
    }

}