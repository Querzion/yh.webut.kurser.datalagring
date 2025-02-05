using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_WebApi.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController(ICustomerService customerService) : Controller
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost]
    public async Task<IActionResult> Create(CustomerRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var existing = await _customerService.GetCustomerAsync(form.Email);
        if (existing != null)
            return Conflict("Customer already exists.");

        var result = await _customerService.CreateCustomerAsync(form);
        return result ? Ok() : Problem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.GetCustomersAsync();
        return customers.Any() ? Ok(customers) : NotFound(new List<Customer>());
    }
    
    
}