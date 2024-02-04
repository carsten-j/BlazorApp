using BellyBox.Server.Data;
using BellyBox.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using BellyBox.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BellyBox.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : Controller
{
    private readonly BellyBoxContext _context;

    public CartController(BellyBoxContext context) => _context = context;
    private Guid GetUserId() => Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

    [HttpGet("{ownerId}")]
    public async Task<ActionResult<Cart>> Get(Guid ownerId)
    {
        var result = await _context.Carts
                        .Include(c => c.Items)
                        .ThenInclude(c => c.Meal)
                        .AsSplitQuery()
                        .SingleOrDefaultAsync(m => m.OwnerId == ownerId);
        if (result == null) return NotFound();
        return result.ToCart();
    }

    [HttpPost("create")]
    public async Task<ActionResult<Cart>> Create()
    {
        CartData newCart = new();
        newCart.OwnerId = Guid.NewGuid();

        _context.Carts.Add(newCart);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return CreatedAtAction(nameof(Get), new { ownerId = newCart.OwnerId }, newCart);
    }

    // PUT: api/Cart/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost("add/{id:int}")]
    public async Task<IActionResult> AddToCart(int id, CartRequestData request)
    {
        if (id != request.CartId) return BadRequest();
        CartData ownedCart = await GetCartByOwner(request.CartId, request.OwnerId);

        if (ownedCart == null) return NotFound();

        var cartItem = ownedCart.Items.FirstOrDefault(item => item.Meal.MealId == request.MealId);
        if (cartItem == null)
        {
            var meal = _context.Meals.Find(request.MealId);

            if (meal == null) return BadRequest();

            cartItem = new()
            {
                Meal = meal,
                Quantity = 1,
            };
            ownedCart.Items.Add(cartItem);
        }
        else
        {
            cartItem.Quantity++;
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }

        return CreatedAtAction(nameof(GetItem), new { cartItem.Id }, cartItem.ToCartItem());

    }

    private async Task<CartData> GetCartByOwner(int cartId, Guid ownerId)
    {
        return await _context.Carts
            .Include(c => c.Items)
            .ThenInclude(c => c.Meal)
            .AsSplitQuery()
            .FirstAsync(cd => cd.Id == cartId && cd.OwnerId == ownerId);
    }

    // DELETE: api/Cart/item/5
    [HttpDelete("item/{id:int}")]
    public async Task<ActionResult> DeleteCartItem(int id)
    {
        var item = await _context.CartItems.FindAsync(id);

        if (item == null) return NotFound();

        _context.CartItems.Remove(item);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return NoContent();
    }

    [HttpGet("item/{id:int}")]
    public async Task<ActionResult<CartItem>> GetItem(int id)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item is null)
        {
            return NotFound();
        }
        return Ok(item?.ToCartItem());
    }


    [HttpPut("item/{cartId:int}")]
    public async Task<ActionResult<CartItem>> UpdateQuantity(int cartId, CartRequestData request)
    {
        bool isValidId = cartId == request.CartId;
        bool isValidItemId = request.ItemId is not null && request.ItemId != 0;
        bool isValidRequest = isValidId && isValidItemId;

        if (!isValidRequest) return BadRequest();
        var cartItem = await _context.CartItems.Include(item => item.Meal).FirstOrDefaultAsync(item => item.Id == request.ItemId);

        if (cartItem == null) return NotFound();
        if (!request.Quantity.HasValue) return BadRequest();
        
        if (request.Quantity.Value == 0)
        {
            _context.CartItems.Remove(cartItem);
            cartItem = new();
        }
        else
        {
            cartItem.Quantity = request.Quantity.Value;
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        return Ok(cartItem.ToCartItem());
    }
}



