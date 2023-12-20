using Microsoft.AspNetCore.Mvc;
using ReviewApplication.WebAPI.Services.AccountService;

namespace ReviewApplication.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    private IAccountService AccountService => accountService; 
    
    [HttpGet("balance")]
    public IActionResult GetBalance(string userFullName)
    {
        return Ok(AccountService.GetBalance(userFullName));
    }
    
    [HttpPatch("deposit")]
    public IActionResult MakeDeposit(string userFullName, float amount, string description)
    {
        return Ok(AccountService.MakeDeposit(userFullName, amount, description));
    }
    
    [HttpPatch("withdrawal")]
    public IActionResult MakeWithdrawal(string userFullName, float amount, string description)
    {
        return Ok(AccountService.MakeWithdrawal(userFullName, amount, description));
    }
    
    [HttpDelete("transfer")]
    public IActionResult MakeTransfer(string fromUserFullName, string toUserFullName, float amount, string description)
    {
        MakeWithdrawal(fromUserFullName, amount, description);
        MakeDeposit(toUserFullName, amount, description);
        return Ok();
    }
}