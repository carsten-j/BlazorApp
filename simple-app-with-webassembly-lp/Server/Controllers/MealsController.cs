using BellyBox.Server.Data;
using BellyBox.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellyBox.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : Controller
    {
        private readonly BellyBoxContext _context;
        public MealsController(BellyBoxContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetMeals()
        {
            var result = await _context.Meals
                .Include(m => m.MealTags)
                .ThenInclude(t => t.Tag)
                .Include(m => m.MealIngredients)
                .ThenInclude(i => i.Ingredient)
                .AsSplitQuery()
                .ToListAsync();
            return Ok(result.Select(m => m.ToMeal()));

        }

        [HttpGet("ingredients")]
        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {
            var result = await _context.Ingredients.ToListAsync();
            return result.Select(i => new Ingredient()
            {
                Id = i.IngredientId,
                Name = i.Name
            });
        }

        [HttpGet("tags")]
        public async Task<IEnumerable<Tag>> GetTags()
        {
            var result = await _context.Tags.ToListAsync();
            return result.Select(i => new Tag()
            {
                Id = i.TagId,
                Text = i.Text
            });
        }
    }
}
