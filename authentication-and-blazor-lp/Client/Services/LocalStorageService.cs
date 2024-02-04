using Microsoft.JSInterop;

namespace BellyBox.Client.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _js;

        public LocalStorageService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task SetItem(string key, Guid value)
        {
            await _js.InvokeVoidAsync("localStorage.setItem", key, value.ToString());
        }

        public async Task<Guid> GetItem(string key)
        {
            var res = await _js.InvokeAsync<string>("localStorage.getItem", key);

            if (Guid.TryParse(res, out var guid))
            {
                return guid;
            }
            return Guid.Empty;
        }
    }
}
