using ReviewApplication.WebAPI.Models;

namespace ReviewApplication.WebAPI.Services.AccountService;

public interface IAccountService
{
    Deposit MakeDeposit(string userFullName, float amount, string description);
    Withdrawal MakeWithdrawal(string userFullName, float amount, string description);
    float GetBalance(string userFullName);
}