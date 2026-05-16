using ProductApi.Models;
using ProductApi.Services;
using Xunit;

namespace ProductApi.Tests;

public class ProductServiceTests
{
    private readonly ProductService _service = new ProductService();

    [Fact]
    public void GetAll_ShouldReturnProducts()
    {
        var result = _service.GetAll();

        Assert.NotNull(result);
        Assert.True(result.Count > 0);
    }

    [Fact]
    public void Add_Product_ShouldIncreaseCount()
    {
        var initialCount = _service.GetAll().Count;

        _service.Add(new Product
        {
            Name = "Test Product",
            Price = 100,
            Stock = 1
        });

        var newCount = _service.GetAll().Count;

        Assert.Equal(initialCount + 1, newCount);
    }

    [Fact]
    public void Search_ShouldReturnMatchingProduct()
    {
        var result = _service.Search("Laptop");

        Assert.All(result, p =>
            Assert.Contains("Laptop", p.Name));
    }

    [Fact]
    public void Discount_ShouldReturnReducedPrice()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Test",
            Price = 1000,
            Stock = 1
        };

        var discounted = _service.GetDiscountedPrice(product);

        Assert.Equal(800, discounted);
    }
}