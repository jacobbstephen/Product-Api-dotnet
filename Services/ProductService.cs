using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Services;

public class ProductService
{
    public List<Product> GetAll()
    {
        return ProductStore.Products;
    }

    public Product? GetById(int id)
    {
        return ProductStore.Products.FirstOrDefault(p => p.Id == id);
    }

    public void Add(Product product)
    {
        product.Id = ProductStore.Products.Count + 1;
        ProductStore.Products.Add(product);
    }

    public List<Product> Search(string name)
    {
        return ProductStore.Products
            .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // ⚠️ intentional “bug for future Phase 3”
    public double GetDiscountedPrice(Product product)
    {
        return product.Price - (product.Price * 0.2); // fixed 20% discount
    }
}