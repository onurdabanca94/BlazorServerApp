using BlazorServerApp.Providers;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorServerApp.Data
{
    public class AuthenticationService
    {
        private MyAuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = (MyAuthenticationStateProvider)authenticationStateProvider;
        }

        public async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return await _authenticationStateProvider.GetAuthenticationStateAsync();
        }

        public void Login(string username, string password)
        {
            if (username == "onurdabanca" && password == "123123")
            {
                _authenticationStateProvider.NotifyStateChanged(true);
            }
        }

        public void Logout()
        {
            _authenticationStateProvider.NotifyStateChanged(false);
        }
    }
}
