using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel() : PageModel
{

	[BindProperty]
	public string Username { get; set; } = "";
	[BindProperty]
	public string Password { get; set; } = "";

	public void OnGet()
	{
		
	}

	public IActionResult OnPost()
	{
		var user = AuthDemo.User.Validate(Username, Password);
		if (user is null)
		{
			ModelState.AddModelError("", "Invalid username or password.");
			return Page();
		}

		var claims = new[]
		{
			new Claim(ClaimTypes.Name, user.Username)
		};

		var identity = new ClaimsIdentity(
			claims, CookieAuthenticationDefaults.AuthenticationScheme);

		HttpContext.SignInAsync(
			CookieAuthenticationDefaults.AuthenticationScheme,
			new ClaimsPrincipal(identity));
	
		return Page();
	}
}