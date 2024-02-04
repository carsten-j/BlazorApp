using BellyBox.Data;
using BellyBox.Shared;
using System.Collections.Generic;
using System.Linq;

namespace BellyBox.Data;
public class BoxData
{
    public int BoxId { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public List<MealData>? Meals { get; set; }
    public double Price { get; set; }

    public Box ToBox() => new Box()
    {
        Id = BoxId,
        Description= Description,
        Price= Price,
        Name= Name,
        Meals = Meals?.Select(m=>m.MealId)
    };
}
