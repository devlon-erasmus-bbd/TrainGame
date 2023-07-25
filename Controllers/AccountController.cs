using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = Url.Action(nameof(HandleGoogleResponse), "Account")
        };

        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("google-response")]
    public async Task<IActionResult> HandleGoogleResponse()
    {
        var authenticateResult = await HttpContext.AuthenticateAsync();

        if (authenticateResult.Succeeded)
        {
            // Get the Google username from the user claims
            var googleUsername = HttpContext.User.FindFirstValue(ClaimTypes.Name);

            // Store the userName in Claims
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, googleUsername),
                };

            var identity = new ClaimsIdentity(claims, GoogleDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            // Redirect to the required screen or URL
            return Redirect("/");
        }

        // Handle authentication failure if needed
        return BadRequest("Authentication failed.");
    }
}
