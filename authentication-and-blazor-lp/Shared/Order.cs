using System;
using System.Collections.Generic;

namespace BellyBox.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Line2 { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public IEnumerable<LineItem>? LineItems { get; set; }
    }
    public class LineItem
    {
        public int Id { get; set; }
        public Meal Meal { get; set; } = new();
        public int Quantity { get; set; }
        public double BasePrice { get; set; } = 8.99F;
    }

    public record OrderRequest(
        int CartId, 
        Guid CartOwnerId,
        string Phone, 
        string Email,
        string Name,
        string Address,
        string? Line2,
        string City,
        string Region,
        string PostalCode);
}
