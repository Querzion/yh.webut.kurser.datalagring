using Business.Dtos;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_WebApi.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductController(IProductService productService) : Controller
{
    private readonly IProductService _productService = productService;

    [HttpPost]
    public async Task<IActionResult> Create(ProductRegistrationForm form)
    {
        // Version 1
        // if (!ModelState.IsValid)
        //     return BadRequest();
        //
        // var product = await _productService.CreateProductAsync(form);
        // if (product != null)
        //     return Ok(product);
        //
        // return BadRequest();
        
        // Version 2
        if (!ModelState.IsValid)
        {
            if (await _productService.CheckIfProductExistsAsync(x => x.Name == form.Name))
                return Conflict("Product with the same name already exists");
            
            var product = await _productService.CreateProductAsync(form);
            if (product != null)
                return Ok(product);
        }
        
        return BadRequest();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetAllProductsAsync();
        return Ok(result);
    }
}