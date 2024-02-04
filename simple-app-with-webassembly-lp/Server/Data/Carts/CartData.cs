using BellyBox.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BellyBox.Data;

public class CartData
{
    public int Id { get; set; }
    public List<CartItemData> Items { get; set; } = new();
    public Guid OwnerId { get; set; }
    public Cart ToCart() => new Cart
    {
        Id = Id,
        OwnerId = OwnerId,
        Items = Items.Select(ci => ci.ToCartItem()).ToList()
    };
}

public class CartItemData
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public MealData Meal { get; set; } = new();
    public int Quantity { get; set; }
    public double BasePrice { get; set; } = 8.99F;
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public CartData Cart { get; set; } = new();

    public CartItem ToCartItem() =>
        new CartItem()
        {
            Id = Id,
            CartId = CartId,
            Meal = Meal.ToMeal(),
            Quantity = Quantity,
            BasePrice = BasePrice,
            DateCreated = DateCreated
        };
}