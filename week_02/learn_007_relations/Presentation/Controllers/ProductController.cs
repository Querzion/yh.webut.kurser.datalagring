using Business.Dtos;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("/api/products")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpPost]
    public IActionResult Create(ProductRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var result = _productService.CreateProduct(form);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);
    }
}