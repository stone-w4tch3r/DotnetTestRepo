using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorErrorHandling.Models;
using RazorErrorHandling.Services;

namespace RazorErrorHandling.Pages;

public class ViewProductModel : PageModel
{
    private readonly ProductService _productService;

    public ViewProductModel(ProductService productService)
    {
        _productService = productService;
    }

    public Product Product { get; private set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            Product = _productService.GetProduct(id);
            return Page();
        }
        catch (CustomServiceException)
        {
            return NotFound();
        }
    }
}
