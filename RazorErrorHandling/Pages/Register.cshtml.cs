using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorErrorHandling.Models;
using RazorErrorHandling.Services;

namespace RazorErrorHandling.Pages;

public class RegisterModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ILogger<RegisterModel> _logger;

    [BindProperty]
    public UserRegistration Registration { get; set; }

    public string ErrorMessage { get; set; }
    public string SuccessMessage { get; set; }

    public RegisterModel(IUserService userService, ILogger<RegisterModel> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _userService.RegisterUserAsync(Registration);

            if (!result.Success)
            {
                switch (result.ErrorType)
                {
                    case ErrorType.Validation:
                        ModelState.AddModelError("", result.ErrorMessage);
                        return Page();

                    case ErrorType.Conflict:
                        ErrorMessage = result.ErrorMessage;
                        return Page();

                    case ErrorType.System:
                        _logger.LogError(
                            "System error during registration: {Message}",
                            result.ErrorMessage
                        );
                        throw new ApplicationException("Registration failed");

                    default:
                        throw new NotSupportedException(
                            $"Unsupported error type: {result.ErrorType}"
                        );
                }
            }

            SuccessMessage = "Registration successful!";
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled error during registration");
            return RedirectToPage("/Error");
        }
    }
}
