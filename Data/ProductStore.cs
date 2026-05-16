using ProductApi.Models;

namespace ProductApi.Data;

public static class ProductStore
{
    public static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 50000, Stock = 5 },
        new Product { Id = 2, Name = "Phone", Price = 20000, Stock = 10 }
    };
}