using Data.Entities;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_WebApi.Controllers;

[Route("api/orderstatus")]
[ApiController]
public class OrderStatusController(OrderStatusRepository orderStatusRepository) : Controller
{
    private readonly OrderStatusRepository _orderStatusRepository = orderStatusRepository;

    [HttpPost]
    // Use this type of string to add a status when using a string to the Create.
    // https://localhost:7117/api/orderstatus?orderStatus=Pågår
    // public async Task<IActionResult> Create(string orderStatus)
    
    // Otherwise use a RegistrationForm (DTO) and it will act differently at the Add/Create/Post.
    public async Task<IActionResult> Create(OrderStatusRegistrationForm form)
    {
        if (!ModelState.IsValid) 
            return BadRequest();

        var orderStatusEntity = await _orderStatusRepository.GetAsync(x => x.Status == form.OrderStatus);
        if (orderStatusEntity != null)
            return Conflict(new { ErrorMessage = "Order status already exists." });
        
        orderStatusEntity = new OrderStatusEntity
        {
            Status = form.OrderStatus
        };
        
        var result = await _orderStatusRepository.AddAsync(orderStatusEntity);
        return result != null ? Created("", result) : Problem("Failed to add order status.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _orderStatusRepository.GetAsync();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _orderStatusRepository.GetAsync(x => x.Id == id);
        return result != null ? Ok(result) : NotFound(new { ErrorMessage = "Order status was not found." });
    }
    
    // [HttpPut]
    //
    //
    // [HttpDelete]
    
    
}