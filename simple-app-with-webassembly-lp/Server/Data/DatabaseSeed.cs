using BellyBox.Data;
using BellyBox.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellyBox.Server.Data
{
    public static class DatabaseSeed
    {
        public static IEnumerable<IngredientData> GenerateIngredients()
        {
            List<IngredientData> i = new();
            //No Sensitivity
            i.Add(new(1, "Ground Beef"));
            i.Add(new(2, "Red Onion"));
            i.Add(new(3, "Bun"));
            i.Add(new(4, "BBQ Sauce"));
            i.Add(new(5, "Smoked Gouda Cheese"));
            i.Add(new(6, "Chicken Breast"));
            i.Add(new(7, "Golden Potatoes"));
            i.Add(new(8, "Brussels Sprouts"));
            i.Add(new(9, "Parmesan Cheese"));
            i.Add(new(10, "Lumaca Rigata Pasta"));
            i.Add(new(11, "Broccoli"));
            i.Add(new(12, "Red Pepper Tomato Sauce"));
            i.Add(new(13, "Part-Skim Ricotta Cheese"));
            i.Add(new(14, "Pasture-Raised Eggs"));
            i.Add(new(15, "Monterey Jack Cheese"));
            i.Add(new(16, "Zucchini"));
            i.Add(new(17, "Flour Tortillas"));
            i.Add(new(18, "Sour Cream"));
            // Vegan
            i.Add(new(1001, "Unthinkable Ground Beef™"));
            i.Add(new(1002, "Unthinkable Chicken™"));
            i.Add(new(1014, "Unthinkable Egg™"));
            i.Add(new(1003, "Vegan/GF Bun"));
            i.Add(new(1005, "Smoked Gouda Vegan Cheese"));
            i.Add(new(1013, "Vegan Ricotta Cheese"));
            i.Add(new(1015, "Monterey Jack Cheese"));
            i.Add(new(1018, "Vegan Sour Cream"));

            // Gluten
            i.Add(new(2003, "(GF) Bun"));
            i.Add(new(2010, "Lumaca Rigata (GF) Pasta"));
            i.Add(new(2017, "Almod Flour Tortillas"));

            // Dairy
            // Egg
            // Nut
            return i;
        }

        public static IEnumerable<TagData> GenerateTags()
        {
            List<TagData> t = new();
            t.Add(new(1, "Vegan"));
            t.Add(new(2, "No Gluten"));
            t.Add(new(3, "No Dairy"));
            t.Add(new(4, "No Egg"));
            t.Add(new(5, "No Nut"));
            t.Add(new(6, "Unrestricted"));
            return t;
        }

        public static IEnumerable<MealData> GenerateMeals()
        {
            List<MealData> m = new();
            m.Add(new()
            {
                MealId = 5,
                Calories = 1000,
                Name = "Chipotle Onion & Smoked Gouda Burger",
                Description = "A smoky-sweet topped USDA Prime ground beef burger. Glazed red onion with a combo of barbecue sauce and chipotle chile paste a specialty condiment made from dried, smoked jalapeño peppers that lends incredible depth of flavor.",
                ImageUrl = "https://via.placeholder.com/850/f7d794",
                ThumbnailUrl = "https://via.placeholder.com/368x200/f7d794",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 1 },
                    new() { IngredientId = 2 },
                    new() { IngredientId = 3 },
                    new() { IngredientId = 4 },
                },
                MealTags = new()
                {
                    new() { TagId = 6 },
                },
            });
            m.Add(new()
            {
                MealId = 6,
                Calories = 900,
                Name = "Chipotle Onion & Vegan Smoked Gouda Burger",
                Description = "A smoky-sweet topped Unthinkable™ ground beef burger. Glazed red onion with a combo of barbecue sauce and chipotle chile paste—a specialty condiment made from dried, smoked jalapeño peppers that lends incredible depth of flavor.",
                ImageUrl = "https://via.placeholder.com/850/f5cd79",
                ThumbnailUrl = "https://via.placeholder.com/368x200/f5cd79",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 1001 },
                    new() { IngredientId = 2 },
                    new() { IngredientId = 1003 },
                    new() { IngredientId = 4 },
                    new() { IngredientId = 1005 },
                },
                MealTags = new()
                {
                    new() { TagId = 1 },
                    new() { TagId = 2 },
                    new() { TagId = 3 },
                    new() { TagId = 4 },
                }
            });
            m.Add(new()
            {
                MealId = 7,
                Calories = 1000,
                Name = "Garlic-Caper Chicken",
                Description = "In this wholesome dish, a duo of aromatic garlic and briny capers—cooked briefly together with butter and lemon juice—creates a simple, irresistible topping for our Italian-seasoned chicken. We're serving it with two hearty sides of parmesan mashed potatoes and roasted brussels sprouts finished with more bright lemon.",
                ImageUrl = "https://via.placeholder.com/850/f3a683",
                ThumbnailUrl = "https://via.placeholder.com/368x200/f3a683",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 6 },
                    new() { IngredientId = 7 },
                    new() { IngredientId = 8 },
                },
                MealTags = new()
                {
                    new() { TagId = 2 },
                    new() { TagId = 4 },
                    new() { TagId = 5 },
                }
            });
            m.Add(new()
            {
                MealId = 8,
                Calories = 980,
                Name = "Garlic-Caper Chicken (DF)",
                Description = "In this wholesome dish, a duo of aromatic garlic and briny capers cooked briefly together with butter and lemon juice creates a simple, irresistible topping for our Italian-seasoned chicken. We're serving it with two hearty sides of parmesan mashed potatoes and roasted brussels sprouts finished with more bright lemon.",
                ImageUrl = "https://via.placeholder.com/850/f19066",
                ThumbnailUrl = "https://via.placeholder.com/368x200/f19066",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 6 },
                    new() { IngredientId = 7 },
                    new() { IngredientId = 8 },
                    new() { IngredientId = 9 },
                },
                MealTags = new()
                {
                    new() { TagId = 2 },
                    new() { TagId = 3 },
                    new() { TagId = 4 },
                    new() { TagId = 5 },
                }
            });
            m.Add(new()
            {
                MealId = 9,
                Calories = 1200,
                Name = "Roasted Red Pepper Pasta",
                Description = "To give this pasta irresistible depth of flavor, you’ll make a tomato and cream sauce featuring capers, garlic, sweet roasted peppers, and just a touch of Calabrian chile paste (for a mild kick). It’s tossed with lumaca rigata, which is perfect for catching every saucy bite. It's served alongside broccoli piled atop a delightful swoosh of creamy ricotta cheese.",
                ImageUrl = "https://via.placeholder.com/850/e15f41",
                ThumbnailUrl = "https://via.placeholder.com/368x200/e15f41",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 9 },
                    new() { IngredientId = 10 },
                    new() { IngredientId = 11 },
                    new() { IngredientId = 12 },
                    new() { IngredientId = 13 },
                },
                MealTags = new()
                {
                    new() { TagId = 5 },
                }
            });
            m.Add(new()
            {
                MealId = 10,
                Calories = 1200,
                Name = "Roasted Red Pepper Pasta (GF)",
                Description = "To give this gluten-free pasta irresistible depth of flavor, you’ll make a tomato and cream sauce featuring capers, garlic, sweet roasted peppers, and just a touch of Calabrian chile paste (for a mild kick). It’s tossed with lumaca rigata, which is perfect for catching every saucy bite. It's served alongside broccoli piled atop a delightful swoosh of creamy ricotta cheese.",
                ImageUrl = "https://via.placeholder.com/850/e77f67",
                ThumbnailUrl = "https://via.placeholder.com/368x200/e77f67",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 9 },
                    new() { IngredientId = 2010 },
                    new() { IngredientId = 11 },
                    new() { IngredientId = 12 },
                    new() { IngredientId = 13 },
                },
                MealTags = new()
                {
                    new() { TagId = 5 },
                    new() { TagId = 2 },
                }
            });
            m.Add(new()
            {
                MealId = 11,
                Calories = 1200,
                Name = "Vegan Roasted Red Pepper Pasta",
                Description = "To give this gluten-free pasta irresistible depth of flavor, you’ll make a tomato and soy cream sauce featuring capers, garlic, sweet roasted peppers, and just a touch of Calabrian chile paste (for a mild kick). It’s tossed with lumaca rigata, which is perfect for catching every saucy bite. It's served alongside broccoli piled atop a delightful swoosh of creamy almosd ricotta cheese.",
                ImageUrl = "https://via.placeholder.com/850/e66767",
                ThumbnailUrl = "https://via.placeholder.com/368x200/e66767",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 9 },
                    new() { IngredientId = 2010 },
                    new() { IngredientId = 11 },
                    new() { IngredientId = 12 },
                    new() { IngredientId = 1013 },
                },
                MealTags = new()
                {
                    new() { TagId = 1 },
                    new() { TagId = 2 },
                    new() { TagId = 3 },
                    new() { TagId = 4 },
                }
            });
            m.Add(new()
            {
                MealId = 12,
                Calories = 680,
                Name = "Spicy Zucchini Quesadillas",
                Description = "To top these zesty shredded zucchini and monterey jack cheese quesadillas, we’re making a creamy topper inspired by rajas con crema, a comforting Mexican dish of smoky roasted poblano coated with smooth crema or sour cream. The rich yolks from our crispy fried eggs provide the perfect finishing touch.",
                ImageUrl = "https://via.placeholder.com/850/f5cd79",
                ThumbnailUrl = "https://via.placeholder.com/368x200/f5cd79",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 14 },
                    new() { IngredientId = 15 },
                    new() { IngredientId = 16 },
                    new() { IngredientId = 17 },
                    new() { IngredientId = 18 },
                },
                MealTags = new()
                {
                    new() { TagId = 5 },
                    new() { TagId = 6 },
                }
            });
            m.Add(new()
            {
                MealId = 13,
                Calories = 680,
                Name = "Spicy Zucchini Quesadillas (GF)",
                Description = "To top these zesty shredded zucchini and monterey jack cheese quesadillas, we’re making a creamy topper inspired by rajas con crema, a comforting Mexican dish of smoky roasted poblano coated with smooth crema or sour cream. The rich yolks from our crispy fried eggs provide the perfect finishing touch.",
                ImageUrl = "https://via.placeholder.com/850/f7d794",
                ThumbnailUrl = "https://via.placeholder.com/368x200/f7d794",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 14 },
                    new() { IngredientId = 15 },
                    new() { IngredientId = 16 },
                    new() { IngredientId = 2017 },
                    new() { IngredientId = 18 },
                },
                MealTags = new()
                {
                    new() { TagId = 2 },
                }
            });
            m.Add(new()
            {
                MealId = 14,
                Calories = 680,
                Name = "Vegan Spicy Zucchini Quesadillas",
                Description = "To top these zesty shredded zucchini and monterey jack cheese quesadillas, we’re making a creamy topper inspired by rajas con crema, a comforting Mexican dish of smoky roasted poblano coated with smooth dairy-free sour cream. Scrambled Unthinkable Eggs™ provide the perfect finishing touch.",
                ImageUrl = "https://via.placeholder.com/850/f3a683",
                ThumbnailUrl = "https://via.placeholder.com/368x200/f3a683",

                Servings = 2,
                MealIngredients = new()
                {
                    new() { IngredientId = 1014 },
                    new() { IngredientId = 1015 },
                    new() { IngredientId = 16 },
                    new() { IngredientId = 17 },
                    new() { IngredientId = 1018 },
                },
                MealTags = new()
                {
                    new() { TagId = 1 },
                    new() { TagId = 3 },
                    new() { TagId = 4 },
                    new() { TagId = 5 },
                }
            });
            return m;
        }

        public static IEnumerable<BoxData> GenerateBoxes(BellyBoxContext context)
        {
            List<BoxData> b = new();
            BoxData vb = new BoxData
            {
                BoxId = 5,
                Name = "Vegan Box",
                Description = "This is our vegan box",
                Price = 60.00,
                Meals = new()
            };
            vb.Meals.AddRange(
                context.Meals
                .Include(m => m.MealTags)
                .ThenInclude(t => t.Tag)
                .Where(m => m.MealTags.Any(t => t.TagId == 1)));
            b.Add(vb);
            BoxData sb = new BoxData
            {
                BoxId = 6,
                Name = "Standard",
                Description = "This is our standard box",
                Price = 60.00,
                Meals = new()
            };
            sb.Meals.AddRange(
            context.Meals
                .Include(m => m.MealTags)
                .ThenInclude(t => t.Tag)
                .Where(m => m.MealTags.Any(t => t.TagId == 6)));
            b.Add(sb);
            return b;

        }

        public static void Initialize(IServiceProvider services, IWebHostEnvironment environment)
        {
            var contextOptions = new DbContextOptionsBuilder<BellyBoxContext>()
     .UseSqlite(@"DataSource=mealdata.db")
     .Options;
            using (var context = new BellyBoxContext(contextOptions))
            {
                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(GenerateIngredients());
                    context.SaveChanges();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(GenerateTags());
                    context.SaveChanges();
                }
            }
            using (var context = new BellyBoxContext(contextOptions))
            {
                if (!context.Meals.Any())
                {
                    context.Meals.AddRange(GenerateMeals());
                    context.SaveChanges();
                }

            }
            using (var context = new BellyBoxContext(contextOptions))
            {
                if (!context.Boxes.Any())
                {
                    context.Boxes.AddRange(GenerateBoxes(context));
                    context.SaveChanges();
                }
            }
        }
    }
}
