using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<CustomAuthenticationStateProvider> _logger;
    private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor, ILogger<CustomAuthenticationStateProvider> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_currentUser));
    }
    public async Task<ClaimsPrincipal> GetCurrentUser()
    {
        var user = _httpContextAccessor.HttpContext.User;
        return user;
    }
    public async Task MarkUserAsAuthenticated(ClaimsPrincipal user)
    {
        _currentUser = user;
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        _logger.LogInformation("User authenticated: {0}", user.Identity.Name);
    }

    public async Task MarkUserAsLoggedOut()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));

        if (_httpContextAccessor.HttpContext != null)
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // clear cookies so user logs out
        }

        _logger.LogInformation("User logged out");
    }
}
