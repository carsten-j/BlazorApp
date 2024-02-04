using BellyBox.Shared;
using System.Net.Http.Json;

namespace BellyBox.Client.Services;
public class CartDataService : ICartDataService
{
    private readonly HttpClient _http;

    public CartDataService(HttpClient http) => _http = http;
    public async Task<Cart> CreateCart()
    {
        var httpResponseMessage = await _http.PostAsync("api/cart/create", null);

        try
        {
            httpResponseMessage.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw new Exception("Something went wrong fetching your cart");
        }

        Cart? newCart = await httpResponseMessage.Content.ReadFromJsonAsync<Cart>();
        if (newCart == null)
        {
            throw new Exception("Something went wrong fetching your cart");
        }
        return newCart;
    }

    public async Task<CartItem> AddCartItem(int cartId, Guid ownerId, Meal meal)
    {
        CartRequestData cartRequest = new(cartId, ownerId, meal.Id);

        var httpResponse = await _http.PostAsJsonAsync($"api/cart/add/{cartRequest.CartId}", cartRequest);

        try
        {
            httpResponse.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw new Exception("Something went adding an item to your cart.");
        }

        CartItem? newItem = await httpResponse.Content.ReadFromJsonAsync<CartItem>();
        if (newItem == null)
        {
            throw new Exception("Something went adding an item to your cart.");
        }
        return newItem;
    }

    public async Task RemoveCartItemById(int cartId)
    {
        var httpResponse = await _http.DeleteAsync($"api/cart/item/{cartId}");
        try
        {
            httpResponse.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw new Exception("Item could not be deleted.");
        }
    }

    public async Task<CartItem> UpdateCartItemQuantity(int cartId, Guid ownerId, CartItem cartItem)
    {
        CartRequestData cartRequest = new(cartId,ownerId, null, cartItem.Id, cartItem.Quantity);
        var httpResponse = await _http.PutAsJsonAsync($"api/cart/item/{cartId}", cartRequest);
        try
        {
            httpResponse.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw new Exception("Something went updating an item to your cart.");
        }
        CartItem? updatedItem = await httpResponse.Content.ReadFromJsonAsync<CartItem>();
        if (updatedItem == null)
        {
            throw new Exception("Something went updating an item to your cart.");
        }
        return updatedItem;
    }

    public async Task<Cart> GetCart(Guid ownerId)
    {
        var ownerIds = ownerId.ToString("N");
        var httpResponse = await _http.GetAsync($"api/cart/{ownerIds}");
        try
        {
            httpResponse.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw new Exception("Something went wrong while fetching your cart.");
        }
        Cart? cart = await httpResponse.Content.ReadFromJsonAsync<Cart>();
        if (cart == null)
        {
            throw new Exception("Something went wrong while fetching your cart.");
        }
        return cart;
    }

}
