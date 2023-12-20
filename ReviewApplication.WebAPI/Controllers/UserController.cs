using Microsoft.AspNetCore.Mvc;
using ReviewApplication.WebAPI.Models;
using ReviewApplication.WebAPI.Services.UserService;

namespace ReviewApplication.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private IUserService UserService => userService;
    
    [HttpGet]
    public IActionResult GetUser(string userName, string password)
    {
        return Ok(userService.GetUser(userName, password));
    }
    
    [HttpPost]
    public IActionResult AddUser(User user)
    {
        return Ok(UserService.AddUser(user));
    }
}