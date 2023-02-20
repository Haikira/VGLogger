using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace VGLogger.API.Authorization.Development
{
    public class DevelopmentAuthenticationFilter : AuthenticationHandler<DevelopmentAuthenticationSchemeOptions>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DevelopmentAuthenticationFilter(IOptionsMonitor<DevelopmentAuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock, IHttpContextAccessor httpContextAccessor)
            : base(options, logger, encoder, clock) => _httpContextAccessor = httpContextAccessor;

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var email = Options.DefaultEmail;
            var name = Options.DefaultName;
            var claims = new[] { new Claim(ClaimTypes.Upn, email), new Claim(ClaimTypes.Name, name) };
            var identity = new ClaimsIdentity(claims, Constants.Authentication.DevAuthScheme);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Constants.Authentication.DevAuthScheme);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
