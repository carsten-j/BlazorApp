using BellyBox.Shared;
using System.Net.Http.Json;

namespace BellyBox.Client.Services;

public class CartDataService : ICartDataService
{
    private readonly HttpClient httpClient;

    public CartDataService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<CartItem> AddCartItem(int cartId, Guid ownerId, Meal meal)
    {
        CartRequestData data = new(cartId, ownerId, meal.Id);

        var response = await httpClient.PostAsJsonAsync($"api/cart/add/{cartId}", data);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw new Exception("Something went wrong while adding an item to your cart.");
        }

        var cartItem = await response.Content.ReadFromJsonAsync<CartItem>();

        if (cartItem is null)
            throw new Exception("Something went wrong while adding an item to your cart.");

        return cartItem;
    }

    public async Task<Cart> CreateCart()
    {
        var result = await httpClient.PostAsync("api/cart/create", null);

        try
        {
            result.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw new Exception("Something went wrong while fetching your cart.");
        }

        var cart = await result.Content.ReadFromJsonAsync<Cart>();

        if (cart is null)
            throw new Exception("Something went wrong while fetching your cart.");

        return cart;
    }

    public async Task RemoveCartItemById(int cartItemId)
    {
        var response = await httpClient.DeleteAsync($"api/cart/item/{cartItemId}");

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw new Exception("Item could not be deleted.");
        }
    }

    public async Task<CartItem> UpdateCartItemQuantity(int cartId, Guid ownerId, CartItem cartItem)
    {
        CartRequestData data = new CartRequestData(cartId, ownerId, null, cartItem.Id, cartItem.Quantity);

        var response = await httpClient.PutAsJsonAsync($"api/cart/item/{cartId}", data);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw new Exception("Something went wrong while updating an item in your cart.");
        }

        var res = await response.Content.ReadFromJsonAsync<CartItem>();

        if (res is null)
            throw new Exception("Something went wrong while updating an item in your cart.");

        return res;
    }
}

