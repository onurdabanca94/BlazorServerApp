using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorServerApp.Providers
{
    public class MyAuthenticationStateProvider : AuthenticationStateProvider
    {
        private bool _isAuthenticated;
        public void NotifyStateChanged(bool isAuthenticated)
        {
            _isAuthenticated = isAuthenticated;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity;
            if (_isAuthenticated)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,"onurdabanca"),
                }, "CustomScheme");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}
