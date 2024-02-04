﻿using BellyBox.Shared;

namespace BellyBox.Client.Services
{
    public interface ICartDataService
    {
        Task<Cart> CreateCart();

        Task<CartItem> AddCartItem(int cartId, Guid ownerId, Meal meal);

        Task RemoveCartItemById(int cartItemId);

        Task<CartItem> UpdateCartItemQuantity(int cartId, Guid ownerId, CartItem cartItem);
    }
}