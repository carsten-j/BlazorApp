using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BellyBox.Data;
using BellyBox.Server.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BellyBox.Shared;

namespace BellyBox.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BellyBoxContext _context;
        public OrderController(BellyBoxContext context) => _context = context;
        private Guid GetUserId() => Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        // GET: api/Order/history
        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderHistory()
        {
            var result = await _context.OrderData
                .Where(od => od.OwnerId == GetUserId())
                .Include(od => od.LineItems)
                .ThenInclude(li => li.Meal)
                .AsSplitQuery()
                .ToListAsync();
            return Ok(result.Select(od => od.ToOrder()));
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderData>> GetOrderData(int id)
        {
            var orderData = await _context.OrderData.FindAsync(id);

            if (orderData == null || orderData.OwnerId == GetUserId())
            {
                return NotFound();
            }

            return Ok(orderData.ToOrder());
        }


        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderData>> PostOrderData(OrderRequest orderRequest)
        {

            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(c => c.Meal)
                .AsSplitQuery()
                .SingleOrDefaultAsync(m => m.OwnerId == orderRequest.CartOwnerId);

            if (cart == null) return BadRequest();

            OrderData newOrder = MapRequestToOrderData(orderRequest);
            _context.OrderData.Add(newOrder);

            await _context.SaveChangesAsync();

            foreach (var item in cart.Items)
            {
                newOrder.LineItems.Add(new()
                {
                    BasePrice = item.BasePrice,
                    Meal = item.Meal,
                    Quantity = item.Quantity
                });
            }

            cart.Items.Clear();

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderData", new { id = newOrder.OrderId }, newOrder.ToOrder());
        }

        private OrderData MapRequestToOrderData(OrderRequest orderRequest) => new OrderData()
        {
            City = orderRequest.City,
            Address = orderRequest.Address,
            Email = orderRequest.Email,
            Line2 = orderRequest.Line2,
            Name = orderRequest.Name,
            Phone = orderRequest.Phone,
            OwnerId = GetUserId(),
            PostalCode = orderRequest.PostalCode,
            Region = orderRequest.Region,

        };

        //private OrderData MapCartToOrder(CartData cart)
        //{
        //    //LineItems = cart.Items.Select(ci => new LineItemData
        //    //{
        //    //    BasePrice = ci.BasePrice,
        //    //    Meal = ci.Meal,
        //    //    Quantity = ci.Quantity
        //    //}).ToList()
        //}
    }
}
