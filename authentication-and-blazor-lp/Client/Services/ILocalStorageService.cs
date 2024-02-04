namespace BellyBox.Client.Services
{
    public interface ILocalStorageService
    {
        Task<Guid> GetItem(string key);
        Task SetItem(string key, Guid value);
    }
}
