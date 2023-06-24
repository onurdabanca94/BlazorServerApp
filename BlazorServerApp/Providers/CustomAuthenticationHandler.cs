using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace BlazorServerApp.Providers
{
    public class CustomAuthenticationHandlerOptions : AuthenticationSchemeOptions
    {

    }
    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationHandlerOptions>
    {
        public CustomAuthenticationHandler(IOptionsMonitor<CustomAuthenticationHandlerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {

        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return AuthenticateResult.Fail("Invalid User");
            string token = null;
            if (Request.Headers.ContainsKey("Authorization"))
            {
                string headerValue = Request.Headers["Authorization"];
                if (headerValue.StartsWith("Bearer "))
                {
                    token = headerValue.Substring("Bearer ".Length);
                }
            }
            if (string.IsNullOrEmpty(token))
            {
                return AuthenticateResult.Fail("Invalid User");
            }
            ClaimsIdentity identity = null;

            identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "onurdabanca"),
            }, "CustomScheme");

            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), "CustomScheme");
            return AuthenticateResult.Success(ticket);
        }
    }
}
