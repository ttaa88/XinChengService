using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace XinChengService
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public CustomAuthOptions()
        {

        }
    }

    internal class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            // store custom services here...
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // build the claims and put them in "Context"; you need to import the Microsoft.AspNetCore.Authentication package
            return AuthenticateResult.NoResult();
        }
    }

    public static class CustomAuthExtensions
    {
        public static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder, Action<CustomAuthOptions> configureOptions)
        {
            return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>("Custom Scheme", "Custom Auth", configureOptions);
        }
    }
}
