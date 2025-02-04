using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorErrorHandling.Pages;

public class ErrorModel : PageModel
{
    public int? StatusCode { get; set; }
    public string ErrorMessage { get; set; }

    public void OnGet(int? code)
    {
        StatusCode = code;
        ErrorMessage = code switch
        {
            400 => "Bad request - invalid input detected",
            404 => "Resource not found",
            500 => "Internal server error",
            _ => "An unexpected error occurred",
        };
    }
}
