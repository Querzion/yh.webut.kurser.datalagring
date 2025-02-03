using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_WebApi.Controllers;

[Route("api/orderstatus")]
[ApiController]
public class OrderStatusController(OrderStatusRepository orderStatusRepository) : Controller
{
    private readonly OrderStatusRepository _orderStatusRepository = orderStatusRepository;

    [HttpPost]
    public async Task<IActionResult> Create(string orderStatus)
    {
        if (!ModelState.IsValid) 
            return BadRequest();

        var orderStatusEntity = await _orderStatusRepository.GetAsync(x => x.Status == orderStatus);
        if (orderStatusEntity != null)
            return Conflict(new { ErrorMessage = "Order status already exists." });
        
        orderStatusEntity = new OrderStatusEntity
        {
            Status = orderStatus
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