using BellyBox.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BellyBox.Data
{
    public class OrderData
    {
        public int OrderId { get; set; }
        public Guid OwnerId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Line2 { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public List<LineItemData> LineItems { get; set; } = new();

        public Order ToOrder() => new Order()
        {
            Id = OrderId,
            Phone = Phone,
            Email = Email,
            Name = Name,
            Address = Address,
            Line2 = Line2,
            City = City,
            Region = Region,
            PostalCode = PostalCode,
            DateCreated = DateCreated,
            LineItems = LineItems.Select(li => li.ToLineItem())
        };
    }
    public class LineItemData
    {
        public int LineItemId { get; set; }
        public MealData Meal { get; set; } = new();
        public int Quantity { get; set; }
        public double BasePrice { get; set; } = 8.99F;

        public int OrderId { get; set; }
        public OrderData Order { get; set; } = new();

        public LineItem ToLineItem() => new LineItem()
        {
            Id = LineItemId,
            Meal = Meal.ToMeal(),
            Quantity = Quantity,
            BasePrice = BasePrice
        };

    }

}
