using BellyBox.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BellyBox.Server.Data
{
    public class BellyBoxContext : DbContext
    {
        public BellyBoxContext(DbContextOptions<BellyBoxContext> options)
               : base(options)
        { }
        public DbSet<MealData> Meals { get; set; } = null!; // Set by EF

        public DbSet<IngredientData> Ingredients { get; set; } = null!; // Set by EF
        public DbSet<TagData> Tags { get; set; } = null!; // Set by EF
        public DbSet<MealIngredient> MealIngredients { get; set; } = null!; // Set by EF
        public DbSet<CartData> Carts { get; set; } = null!; // Set by EF
        public DbSet<CartItemData> CartItems { get; set; } = null!; // Set by EF
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealData>().HasKey(m => m.MealId);
            modelBuilder.Entity<IngredientData>().HasKey(i => i.IngredientId);
            modelBuilder.Entity<TagData>().HasKey(t => t.TagId);
            modelBuilder.Entity<MealIngredient>()
                .HasKey(mi => new { mi.MealId, mi.IngredientId });
            modelBuilder.Entity<MealTag>()
                .HasKey(mt => new { mt.MealId, mt.TagId });
            modelBuilder.Entity<MealIngredient>()
                .HasOne(mi => mi.Ingredient)
                .WithMany(i => i.MealIngredients)
                .HasForeignKey(mi => mi.IngredientId);

            modelBuilder.Entity<MealIngredient>()
                .HasOne(mi => mi.Meal)
                .WithMany(i => i.MealIngredients)
                .HasForeignKey(mi => mi.MealId);
           
            modelBuilder.Entity<MealTag>()
                .HasOne(mi => mi.Tag)
                .WithMany(i => i.MealTags)
                .HasForeignKey(mi => mi.TagId);

            modelBuilder.Entity<MealTag>()
                .HasOne(mi => mi.Meal)
                .WithMany(i => i.MealTags)
                .HasForeignKey(mi => mi.MealId);

            modelBuilder.Entity<CartData>().HasKey(cd => cd.Id);
            modelBuilder.Entity<CartItemData>().HasKey(cd => cd.Id);

            modelBuilder.Entity<CartData>()
                .HasMany(cd => cd.Items)
                .WithOne(c => c.Cart)
                .HasForeignKey(c => c.CartId);
            
            modelBuilder.Entity<CartItemData>()
                .HasOne(ci =>ci.Cart)
                .WithMany(ci => ci.Items)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<OrderData>().HasKey(o => o.OrderId);
            modelBuilder.Entity<LineItemData>().HasKey(li => li.LineItemId);

            modelBuilder.Entity<OrderData>()
                .HasMany(li => li.LineItems)
                .WithOne(o => o.Order);

            modelBuilder.Entity<LineItemData>()
                .HasOne(o => o.Order)
                .WithMany(o => o.LineItems)
                .HasForeignKey(o => o.OrderId);
        }

        public async Task InitializeContainerAsync()
        {
            await Database.EnsureCreatedAsync();
            Ingredients.AddRange(DatabaseSeed.GenerateIngredients());
            Tags.AddRange(DatabaseSeed.GenerateTags());
            Meals.AddRange(DatabaseSeed.GenerateMeals());
            var changed = await SaveChangesAsync();
            Console.WriteLine($"created {changed} records");
        }

        public DbSet<BellyBox.Data.OrderData> OrderData { get; set; }
    }
}
