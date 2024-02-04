using BellyBox.Shared;

namespace BellyBox.Client.Services;

public class CartState
{
    public int CartId { get; private set; }

    public Guid OwnerId { get; private set; }

    public Dictionary<int, CartItem> Items { get; private set; } = new();

    public void SetState(Cart cart)
    {
        CartId = cart.Id;
        OwnerId = cart.OwnerId;
        Items = cart.Items.ToDictionary(x => x.Id, x => x);
        OnChange.Invoke();
    }

    public void UpdateCart(CartItem item)
    {
        Items[item.Id] = item;
        OnChange.Invoke();
    }

    public void RemoveCartItem(int cartId)
    {
        Items.Remove(cartId);
        OnChange.Invoke();
    }

    public int TotalItems()
    {
        return Items.Values.Sum(x => x.Quantity);
    }

    public event Action? OnChange;
}
