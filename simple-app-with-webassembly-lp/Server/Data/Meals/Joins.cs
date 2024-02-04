using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellyBox.Data
{
    public class MealIngredient
    {
        public int MealId { get; set; }
        public MealData? Meal { get; set; }
        public int IngredientId { get; set; }
        public IngredientData? Ingredient { get; set; }
    }

    public class MealTag
    {
        public int MealId { get; set; }
        public MealData? Meal { get; set; }
        public int TagId { get; set; }
        public TagData? Tag { get; set; }
    }
}
