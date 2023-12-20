using Microsoft.EntityFrameworkCore;
using ReviewApplication.WebAPI.Models;

namespace ReviewApplication.WebAPI.Services.AccountService;

public class AccountService(ApiDbContext context) : IAccountService
{
    private ApiDbContext Context => context;
    
    public Deposit MakeDeposit(string userFullName, float amount, string description)
    {
        var deposit = new Deposit
        {
            Amount = amount,
            Description =  description,
            UserFullName = userFullName,
        };
        
        Context.Deposits.Add(deposit);
        Context.SaveChanges();
        return deposit;
    }

    public Withdrawal MakeWithdrawal(string userFullName, float amount, string description)
    {
        var withdrawal = new Withdrawal()
        {
            Amount = amount,
            Description =  description,
            UserFullName = userFullName,
        };
        
        Context.Withdrawals.Add(withdrawal);
        Context.SaveChanges();
        return withdrawal;
    }

    public float GetBalance(string userFullName)
    {
        var deposits = Context.Deposits.Where(deposit => deposit.UserFullName == userFullName);
        var withdrawals = Context.Withdrawals.Where(withdrawal => withdrawal.UserFullName == userFullName);
        return deposits.Sum(deposit => deposit.Amount) - withdrawals.Sum(withdrawal => withdrawal.Amount);
    }
}