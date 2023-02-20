using Microsoft.AspNetCore.Authentication;

namespace VGLogger.API.Authorization.Development
{
    public class DevelopmentAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public string DefaultEmail { get; set; }
        public string DefaultName { get; set; }
    }
}
