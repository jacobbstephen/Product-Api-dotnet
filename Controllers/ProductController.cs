using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service = new ProductService();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _service.GetById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        _service.Add(product);
        return Ok("Product added");
    }

    [HttpGet("search")]
    public IActionResult Search(string name)
    {
        return Ok(_service.Search(name));
    }

    [HttpGet("discount/{id}")]
    public IActionResult Discount(int id)
    {
        var product = _service.GetById(id);
        if (product == null) return NotFound();

        return Ok(_service.GetDiscountedPrice(product));
    }
}