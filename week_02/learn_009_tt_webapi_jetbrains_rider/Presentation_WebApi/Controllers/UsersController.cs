using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(UserService userService) : Controller
{
    private readonly UserService _userService = userService;

    [HttpPost]
    public async Task<IActionResult> Create(UserRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _userService.RegisterNewUserAsync(form);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userService.GetAllUsersAsync();
        return Ok(result);
    }
}