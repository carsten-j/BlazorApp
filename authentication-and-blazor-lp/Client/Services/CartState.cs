using BellyBox.Shared;
namespace BellyBox.Client.Services;

public class CartState
{
    public event Action? OnChange;
    public int CartId { get; private set; }
    public Guid OwnerId { get; private set; }
    public Dictionary<int, CartItem> Items { get; private set; } = new Dictionary<int, CartItem>();
    public int TotalItems => Items.Sum(item => item.Value.Quantity);
    public void SetState(Cart cart)
    {
        CartId = cart.Id;
        OwnerId = cart.OwnerId;
        Items = cart.Items.ToDictionary(k => k.Id, v => v);
        OnChange?.Invoke();
    }

    public void UpdateCart(CartItem cartItem)
    {
        Items[cartItem.Id] = cartItem;
        OnChange?.Invoke();
    }

    public void RemoveCartItem(int cartId)
    {
        Items.Remove(cartId);
        OnChange?.Invoke();
    }
}
