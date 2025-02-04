using RazorErrorHandling.Models;

namespace RazorErrorHandling.Services;

public class ProductService
{
    private readonly List<Product> _products = [];
    private int _nextId = 1;

    public int CreateProduct(Product product)
    {
        // Validation
        if (string.IsNullOrEmpty(product.Name))
            throw new ArgumentException("Product name is required");

        if (product.Price <= 0)
            throw new ArgumentException("Invalid price value");

        // Concurrency simulation
        if (_products.Any(p => p.Name == product.Name))
            throw new ConcurrencyException("Product already exists");

        // Unexpected error simulation
        if (product.Name == "error")
            throw new InvalidOperationException("Simulated server error");

        product.Id = _nextId++;
        _products.Add(product);
        return product.Id;
    }

    public Product GetProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return product ?? throw new CustomServiceException("Product not found");
    }
}
