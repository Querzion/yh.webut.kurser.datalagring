using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApi.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost]
    public async Task<IActionResult> Create(CustomerRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var existing = await _customerService.GetCustomerByEmailAsync(form.Email);
        if (existing != null)
            return Conflict("Customer with same email already exists.");

        var result = await _customerService.CreateCustomerAsync(form);
        return result ? Ok() : Problem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.GetCustomersAsync();
        return customers.Any() ? Ok(customers) : NotFound(new List<Customer>());
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var customer = await _customerService.GetCustomerByEmailAsync(email);
        return customer != null ? Ok(customer) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> Update(CustomerUpdateForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var existing = await _customerService.GetCustomerByIdAsync(form.Id);
        if (existing == null)
            return NotFound();

        var customer = await _customerService.UpdateCustomerAsync(form);
        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest();

        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();

        var result = await _customerService.DeleteCustomerAsync(customer.Id);
        return result ? Ok(result) : Problem();
    }
}
