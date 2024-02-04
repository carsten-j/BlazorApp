using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellyBox.Shared
{
    public class Cart
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public List<CartItem> Items { get; set; } = new();
    }
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Meal Meal { get; set; } = new();
        
        [Required]
        public int Quantity { get; set; }
        public double BasePrice { get; set; } = 8.99F;
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }

    public record CartRequestData(
        int CartId, 
        Guid OwnerId, 
        int? MealId = null,
        int? ItemId = null,
        int? Quantity = null );

}