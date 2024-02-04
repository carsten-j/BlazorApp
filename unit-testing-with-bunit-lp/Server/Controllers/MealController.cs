using BellyBox.Server.Data;
using BellyBox.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BellyBox.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : Controller
    {
        private readonly BellyBoxContext _context;
        public MealController(BellyBoxContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Meal>> GetMeal(int id)
        {
            var result = await _context.Meals
                .Include(m => m.MealTags)
                .ThenInclude(t => t.Tag)
                .Include(m => m.MealIngredients)
                .ThenInclude(i => i.Ingredient)
                .AsSplitQuery()
                .SingleOrDefaultAsync(m => m.MealId == id);
            if (result == null) return NotFound();
            return result.ToMeal();
        }

    }
}
