using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorErrorHandling.Models;
using RazorErrorHandling.Services;

namespace RazorErrorHandling.Pages;

public class CreateProductModel : PageModel
{
    private readonly ProductService _productService;

    public CreateProductModel(ProductService productService)
    {
        _productService = productService;
    }

    [BindProperty]
    public Product Product { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            _productService.CreateProduct(Product);
            return RedirectToPage("/Index");
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return Page();
        }
        catch (ConcurrencyException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return Page();
        }
        catch (Exception)
        {
            return RedirectToPage("/Error", new { code = 500 });
        }
    }
}
